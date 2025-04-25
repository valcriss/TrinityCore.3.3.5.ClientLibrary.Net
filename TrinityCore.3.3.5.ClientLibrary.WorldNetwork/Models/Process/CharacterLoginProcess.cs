using TrinityCore._3._3._5.ClientLibrary.Network;
using TrinityCore._3._3._5.ClientLibrary.WorldNetwork.Models.Enums;
using TrinityCore._3._3._5.ClientLibrary.WorldNetwork.Models.Messages;

namespace TrinityCore._3._3._5.ClientLibrary.WorldNetwork.Models.Process;

public class CharacterLoginProcess
{
    private const int CHARACTER_LOGIN_TIMEOUT = 5000;

    private readonly ManualResetEvent _characterLoginDone;
    private readonly NetworkClient<WorldCommands> _networkClient;
    private PlayerState _playerState;

    public CharacterLoginProcess(NetworkClient<WorldCommands> networkClient)
    {
        _networkClient = networkClient;
        _characterLoginDone = new ManualResetEvent(false);
    }

    public async Task<bool> LoginCharacter(ulong characterGuid)
    {
        try
        {
            _playerState = PlayerState.NOT_LOGGED_IN;
            await _networkClient.SendAsync(new ClientCharacterLoginRequest(characterGuid));
            _characterLoginDone.Reset();
            _characterLoginDone.WaitOne(CHARACTER_LOGIN_TIMEOUT);
            return _playerState == PlayerState.LOGGED_IN;
        }
        catch
        {
            return false;
        }
    }

    public void OnServerCharacterLoginResponse(ServerCharacterLoginResponse serverCharacterLoginResponse)
    {
        _playerState = PlayerState.LOGGED_IN;
        _characterLoginDone.Set();
    }
}