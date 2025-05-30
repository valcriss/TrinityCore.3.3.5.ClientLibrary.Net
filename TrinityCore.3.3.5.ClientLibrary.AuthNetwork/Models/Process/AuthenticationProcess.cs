using TrinityCore._3._3._5.ClientLibrary.AuthNetwork.Enums;
using TrinityCore._3._3._5.ClientLibrary.AuthNetwork.Models.Messages;
using TrinityCore._3._3._5.ClientLibrary.AuthNetwork.Models.Results;
using TrinityCore._3._3._5.ClientLibrary.AuthNetwork.Models.Security;
using TrinityCore._3._3._5.ClientLibrary.Network;

namespace TrinityCore._3._3._5.ClientLibrary.AuthNetwork.Models.Process;

public class AuthenticationProcess : IDisposable
{
    private const int AUTHENTIFICATION_TIMEOUT = 3000;
    private readonly ManualResetEvent _authenticateDone;
    private readonly AuthenticationResult _authenticationResult;
    private readonly AuthCredentials _credentials;

    private readonly NetworkClient<AuthCommands> _networkClient;

    public AuthenticationProcess(NetworkClient<AuthCommands> networkClient, AuthCredentials credentials)
    {
        _authenticateDone = new ManualResetEvent(false);
        _networkClient = networkClient;
        _credentials = credentials;
        _authenticationResult = new AuthenticationResult(credentials.Username, credentials.SessionKey);
    }

    public void Dispose()
    {
        _networkClient.Dispose();
        _authenticateDone.Dispose();
    }

    public async Task<AuthenticationResult> AuthenticateAsync()
    {
        try
        {
            _authenticationResult.Fail(ConnexionResult.AUTHENTIFICATION_FAILED);
            await _networkClient.ConnectAsync();
            _authenticateDone.WaitOne(AUTHENTIFICATION_TIMEOUT);
            return _authenticationResult;
        }
        catch
        {
            _authenticationResult.Fail(ConnexionResult.AUTHENTIFICATION_FAILED);
            _authenticateDone.Set();
            return _authenticationResult;
        }
    }

    public void OnLogonChallengeResponse(LogonChallengeResponse logonChallengeResponse)
    {
        if (logonChallengeResponse.Error != AuthResult.SUCCESS)
        {
            _authenticationResult.Fail(ConnexionResult.LOGON_CHALLENGE_FAILED);
            _authenticateDone.Set();
            return;
        }

        _credentials.ComputeAuthProof(logonChallengeResponse);
        _authenticationResult.SessionKey = _credentials.SessionKey;

        if (_credentials.Y == null || _credentials.M1Hash == null)
            throw new Exception("Y or M1Hash is null");

        _networkClient.SendAsync(new AuthProofRequest(_credentials.Y, _credentials.M1Hash, new byte[20])).Wait();
    }

    public void OnAuthProofResponse(AuthProofResponse authProofResponse)
    {
        if (authProofResponse.Error != AuthResult.SUCCESS)
        {
            _authenticationResult.Fail(ConnexionResult.AUTH_PROOF_FAILED);
            _authenticateDone.Set();
            return;
        }

        if (!_credentials.IsProofValid(authProofResponse.M2))
        {
            _authenticationResult.Fail(ConnexionResult.AUTH_INVALID_PROOF);
            _authenticateDone.Set();
            return;
        }

        _authenticationResult.Success();
        _authenticateDone.Set();
    }
}