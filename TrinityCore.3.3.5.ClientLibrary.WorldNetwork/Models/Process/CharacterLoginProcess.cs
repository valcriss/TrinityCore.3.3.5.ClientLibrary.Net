using System.Timers;
using TrinityCore._3._3._5.ClientLibrary.Network;
using TrinityCore._3._3._5.ClientLibrary.WorldNetwork.Models.Enums;
using TrinityCore._3._3._5.ClientLibrary.WorldNetwork.Models.Messages;
using Timer = System.Timers.Timer;

namespace TrinityCore._3._3._5.ClientLibrary.WorldNetwork.Models.Process;

public class CharacterLoginProcess : IDisposable
{
    private const int CHARACTER_LOGIN_TIMEOUT = 5000;
    private const int CHARACTER_KEEP_ALIVE_INTERVAL = 15000;

    private readonly ManualResetEvent _characterLoginDone;
    private readonly NetworkClient<WorldCommands> _networkClient;
    private readonly Timer _timer;
    private PlayerState _playerState;

    public CharacterLoginProcess(NetworkClient<WorldCommands> networkClient)
    {
        _networkClient = networkClient;
        _characterLoginDone = new ManualResetEvent(false);
        _playerState = PlayerState.NOT_LOGGED_IN;
        _timer = new Timer(CHARACTER_KEEP_ALIVE_INTERVAL);
        _timer.Enabled = true;
        _timer.Elapsed += OnTimerElapsed;
        _timer.Start();
    }

    public void Dispose()
    {
        _timer.Stop();
        _timer.Dispose();
        _playerState = PlayerState.NOT_LOGGED_IN;
        _characterLoginDone.Dispose();
        _networkClient.Dispose();
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

    private void OnTimerElapsed(object? sender, ElapsedEventArgs e)
    {
        if (_playerState != PlayerState.LOGGED_IN) return;
        _networkClient.SendAsync(new ClientKeepAliveRequest()).Wait();
    }
}