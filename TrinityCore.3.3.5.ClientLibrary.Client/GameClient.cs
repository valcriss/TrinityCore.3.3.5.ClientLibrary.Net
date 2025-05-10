using TrinityCore._3._3._5.ClientLibrary.AuthNetwork;
using TrinityCore._3._3._5.ClientLibrary.AuthNetwork.Enums;
using TrinityCore._3._3._5.ClientLibrary.AuthNetwork.Models.Results;
using TrinityCore._3._3._5.ClientLibrary.Client.Exceptions;
using TrinityCore._3._3._5.ClientLibrary.Dbc;
using TrinityCore._3._3._5.ClientLibrary.WorldNetwork;
using TrinityCore._3._3._5.ClientLibrary.WorldNetwork.Models.Results;
using TrinityCore._3._3._5.ClientLibrary.WorldState;

namespace TrinityCore._3._3._5.ClientLibrary.Client;

public class GameClient
{
    private readonly AuthNetworkClient _authNetworkClient;
    private readonly string _username;
    private WorldNetworkClient? _worldNetworkClient;

    public GameClient(
        string host,
        string username,
        string password,
        string dbcPath
    )
    {
        _username = username;
        DbcDirectory.Initialize(dbcPath);
        GameState = new GameState();
        _authNetworkClient = new AuthNetworkClient(host, AuthPort, username, password);
    }

    public GameState GameState { get; }

    public int AuthPort { get; set; } = 3724;
    public int WorldPort { get; set; } = 8085;
    public Func<Realm[], Realm?> SelectRealm { get; set; } = realms => realms.Length > 0 ? realms[0] : null;
    public Func<Character[], Character?> SelectCharacter { get; set; } = characters => characters.Length > 0 ? characters[0] : null;

    public async Task<bool> Connect()
    {
        AuthenticationResult authenticationResult = await _authNetworkClient.AuthenticateAsync();
        if (authenticationResult.ConnexionResult != ConnexionResult.SUCCESS) throw new AuthenticationException(authenticationResult.ConnexionResult.ToString());

        Realm[]? realms = await _authNetworkClient.GetRealmListAsync();
        if (realms == null) throw new WorldSelectionException("No realms available");

        Realm? realm = SelectRealm(realms);
        if (realm == null) throw new WorldSelectionException("No realm selected");

        _worldNetworkClient = new WorldNetworkClient(realm.Address, WorldPort, realm.Id, _username, authenticationResult.SessionKey.ToByteArray(), GameState.GetWorldStateEventBus());

        bool worldConnectionResult = await _worldNetworkClient.AuthenticateAsync();
        if (!worldConnectionResult) throw new WorldConnexionFailedException("World connection failed");

        Character[] characterList = await _worldNetworkClient.GetCharacterListAsync();
        if (characterList == null) throw new CharacterSelectionException("No characters available");
        Character? character = SelectCharacter(characterList);
        if (character == null) throw new CharacterSelectionException("No character selected");

        bool characterLoginResult = await _worldNetworkClient.LoginCharacter(character.Guid);
        if (!characterLoginResult) throw new CharacterLoginException("Character login failed");

        return true;
    }

    public async Task<bool> Disconnect()
    {
        if (_worldNetworkClient != null)
        {
            await _worldNetworkClient.DisconnectAsync();
            _worldNetworkClient.Dispose();
            _worldNetworkClient = null;
        }

        await _authNetworkClient.DisconnectAsync();
        _authNetworkClient.Dispose();
        return true;
    }
}