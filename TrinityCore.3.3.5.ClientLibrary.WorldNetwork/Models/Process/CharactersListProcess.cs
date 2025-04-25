using TrinityCore._3._3._5.ClientLibrary.Network;
using TrinityCore._3._3._5.ClientLibrary.WorldNetwork.Models.Enums;
using TrinityCore._3._3._5.ClientLibrary.WorldNetwork.Models.Messages;
using TrinityCore._3._3._5.ClientLibrary.WorldNetwork.Models.Results;

namespace TrinityCore._3._3._5.ClientLibrary.WorldNetwork.Models.Process;

public class CharactersListProcess : IDisposable
{
    private const int CHARACTER_LIST_TIMEOUT = 5000;
    
    private readonly ManualResetEvent _characterListDone;
    private readonly NetworkClient<WorldCommands> _networkClient;
    private Character[] _characters = [];
    
    public CharactersListProcess(NetworkClient<WorldCommands> networkClient)
    {
        _networkClient = networkClient;
        _characterListDone = new ManualResetEvent(false);
    }
    
    public async Task<Character[]> GetCharacterListAsync()
    {
        try
        {
            await _networkClient.SendAsync(new ClientCharactersListRequest());
            _characters = [];
            _characterListDone.Reset();
            _characterListDone.WaitOne(CHARACTER_LIST_TIMEOUT);
            return _characters;
        }
        catch
        {
            _characterListDone.Set();
            return [];
        }
    }
    
    public void OnServerCharactersListResponse(ServerCharactersListResponse serverCharactersListResponse)
    {
        _characters = serverCharactersListResponse.Characters;
        _characterListDone.Set();
    }

    public void Dispose()
    {
        _characterListDone.Dispose();
        _networkClient.Dispose();
    }
}