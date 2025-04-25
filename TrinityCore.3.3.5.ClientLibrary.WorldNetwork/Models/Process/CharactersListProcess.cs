using TrinityCore._3._3._5.ClientLibrary.Network;
using TrinityCore._3._3._5.ClientLibrary.WorldNetwork.Models.Enums;
using TrinityCore._3._3._5.ClientLibrary.WorldNetwork.Models.Messages;
using TrinityCore._3._3._5.ClientLibrary.WorldNetwork.Models.Results;

namespace TrinityCore._3._3._5.ClientLibrary.WorldNetwork.Models.Process;

public class CharactersListProcess : IDisposable
{
    private const int CHARACTERS_LIST_TIMEOUT = 5000;

    private readonly ManualResetEvent _charactersListDone;
    private readonly NetworkClient<WorldCommands> _networkClient;
    private Character[] _characters = [];

    public CharactersListProcess(NetworkClient<WorldCommands> networkClient)
    {
        _networkClient = networkClient;
        _charactersListDone = new ManualResetEvent(false);
    }

    public void Dispose()
    {
        _charactersListDone.Dispose();
        _networkClient.Dispose();
    }

    public async Task<Character[]> GetCharacterListAsync()
    {
        try
        {
            await _networkClient.SendAsync(new ClientCharactersListRequest());
            _characters = [];
            _charactersListDone.Reset();
            _charactersListDone.WaitOne(CHARACTERS_LIST_TIMEOUT);
            return _characters;
        }
        catch
        {
            _charactersListDone.Set();
            return [];
        }
    }

    public void OnServerCharactersListResponse(ServerCharactersListResponse serverCharactersListResponse)
    {
        _characters = serverCharactersListResponse.Characters;
        _charactersListDone.Set();
    }
}