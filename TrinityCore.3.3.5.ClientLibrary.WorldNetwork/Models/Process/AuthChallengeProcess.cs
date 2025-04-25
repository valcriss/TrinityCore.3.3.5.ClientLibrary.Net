using TrinityCore._3._3._5.ClientLibrary.Network;
using TrinityCore._3._3._5.ClientLibrary.WorldNetwork.Models.Enums;
using TrinityCore._3._3._5.ClientLibrary.WorldNetwork.Models.Messages;
using TrinityCore._3._3._5.ClientLibrary.WorldNetwork.Models.Security;

namespace TrinityCore._3._3._5.ClientLibrary.WorldNetwork.Models.Process;

public class AuthChallengeProcess : IDisposable
{
    private const int AUTHENTIFICATION_TIMEOUT = 5000;

    private readonly ManualResetEvent _authenticateDone;
    private readonly AuthenticationCrypto _crypto;
    private readonly NetworkClient<WorldCommands> _networkClient;
    private readonly uint _realmId;
    private readonly byte[] _sessionKey;
    private readonly string _username;
    private bool _authenticated;

    public AuthChallengeProcess(NetworkClient<WorldCommands> networkClient, uint realmId, string username, byte[] sessionKey, AuthenticationCrypto crypto)
    {
        _networkClient = networkClient;
        _realmId = realmId;
        _username = username;
        _sessionKey = sessionKey;
        _crypto = crypto;
        _authenticateDone = new ManualResetEvent(false);
    }

    public void Dispose()
    {
        _authenticateDone.Dispose();
        _networkClient.Dispose();
    }

    public async Task<bool> AuthenticateAsync()
    {
        try
        {
            _authenticated = false;
            await _networkClient.ConnectAsync();
            _authenticateDone.Reset();
            _authenticateDone.WaitOne(AUTHENTIFICATION_TIMEOUT);
            return _authenticated;
        }
        catch
        {
            return false;
        }
    }

    public void OnServerAuthChallengeRequest(ServerAuthChallengeRequest serverAuthChallenge)
    {
        _networkClient.SendAsync(new ServerAuthChallengeResponse(_realmId, _username, _sessionKey, serverAuthChallenge.ServerSeed)).Wait();
        _crypto.Activate();
    }

    public void OnServerAuthChallengeResult(ServerAuthChallengeResult serverAuthChallengeResult)
    {
        _authenticated = serverAuthChallengeResult.Success;
        _authenticateDone.Set();
    }
}