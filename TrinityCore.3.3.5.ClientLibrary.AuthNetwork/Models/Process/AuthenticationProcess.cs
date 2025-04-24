using TrinityCore._3._3._5.ClientLibrary.AuthNetwork.Enums;
using TrinityCore._3._3._5.ClientLibrary.AuthNetwork.Models.Messages;
using TrinityCore._3._3._5.ClientLibrary.AuthNetwork.Models.Security;
using TrinityCore._3._3._5.ClientLibrary.Network;
using TrinityCore._3._3._5.ClientLibrary.Shared.Enums;
using TrinityCore._3._3._5.ClientLibrary.Shared.Logger;

namespace TrinityCore._3._3._5.ClientLibrary.AuthNetwork.Models.Process;

public class AuthenticationProcess : IDisposable
{
    public Action<ConnexionResult>? AuthenticationFailed;
    public Action<ConnexionResult>? AuthenticationSucceeded;

    public bool IsAuthenticated { get; private set; }
    
    private readonly NetworkClient<AuthCommands> _networkClient;
    private readonly AuthCredentials _credentials;
    private readonly ManualResetEvent _authenticateDone;
    
    public AuthenticationProcess(NetworkClient<AuthCommands> networkClient, AuthCredentials credentials,ManualResetEvent authenticateDone)
    {
        _authenticateDone = authenticateDone;
        _networkClient = networkClient;
        _credentials = credentials;
        IsAuthenticated = false;
    }

    public void OnLogonChallengeResponse(LogonChallengeResponse logonChallengeResponse)
    {
        Log.Debug("OnLogonChallengeResponse");
        if (logonChallengeResponse.Error != AuthResult.SUCCESS)
        {
            AuthenticationFailed?.Invoke(ConnexionResult.LOGON_CHALLENGE_FAILED);
            IsAuthenticated = false;
            _authenticateDone.Set();
            return;
        }

        _credentials.ComputeAuthProof(logonChallengeResponse);

        if (_credentials.Y == null || _credentials.M1Hash == null)
            throw new Exception("Y or M1Hash is null");

        _networkClient.SendAsync(new AuthProofRequest(_credentials.Y, _credentials.M1Hash, new byte[20])).Wait();
    }

    public void OnAuthProofResponse(AuthProofResponse authProofResponse)
    {
        Log.Debug("OnAuthProofResponse");
        if (authProofResponse.Error != AuthResult.SUCCESS)
        {
            AuthenticationFailed?.Invoke(ConnexionResult.AUTH_PROOF_FAILED);
            IsAuthenticated = false;
            _authenticateDone.Set();
            return;
        }

        if (!_credentials.IsProofValid(authProofResponse.M2))
        {
            AuthenticationFailed?.Invoke(ConnexionResult.AUTH_INVALID_PROOF);
            IsAuthenticated = false;
            _authenticateDone.Set();
            return;
        }

        AuthenticationSucceeded?.Invoke(ConnexionResult.SUCCESS);
        IsAuthenticated = true;
        _authenticateDone.Set();
    }

    public void Dispose()
    {
        _networkClient.Dispose();
        _authenticateDone.Dispose();
    }
}