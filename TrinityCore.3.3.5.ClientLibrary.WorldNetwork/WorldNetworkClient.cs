using TrinityCore._3._3._5.ClientLibrary.Network;
using TrinityCore._3._3._5.ClientLibrary.Network.Core;
using TrinityCore._3._3._5.ClientLibrary.Network.Core.Parsers;
using TrinityCore._3._3._5.ClientLibrary.Network.Core.Readers;
using TrinityCore._3._3._5.ClientLibrary.Network.Core.Writers;
using TrinityCore._3._3._5.ClientLibrary.WorldNetwork.Models.Enums;
using TrinityCore._3._3._5.ClientLibrary.WorldNetwork.Models.Messages;
using TrinityCore._3._3._5.ClientLibrary.WorldNetwork.Models.Network;
using TrinityCore._3._3._5.ClientLibrary.WorldNetwork.Models.Process;
using TrinityCore._3._3._5.ClientLibrary.WorldNetwork.Models.Registry;
using TrinityCore._3._3._5.ClientLibrary.WorldNetwork.Models.Results;
using TrinityCore._3._3._5.ClientLibrary.WorldNetwork.Models.Security;

namespace TrinityCore._3._3._5.ClientLibrary.WorldNetwork;

public class WorldNetworkClient : IDisposable
{
    private readonly AuthChallengeProcess _authChallengeProcess;
    private readonly CharacterLoginProcess _characterLoginProcess;
    private readonly CharactersListProcess _charactersListProcess;
    private readonly NetworkEventBus<WorldCommands> _eventBus;

    private readonly NetworkClient<WorldCommands> _networkClient;
    private readonly WorldOpcodeRegistryFactory _opcodeRegistryFactory = new();
    public Action? Connected;
    public Action? Disconnected;

    public WorldNetworkClient(string host, int port, uint realmId, string username, byte[] sessionKey, NetworkEventBus<WorldCommands> eventBus)
    {
        _eventBus = eventBus;
        AuthenticationCrypto crypto = new(sessionKey);
        WorldFrameReader frameReader = new(new WorldFrameHeaderReader(crypto));
        FrameWriter<WorldCommands> frameWriter = new(new WorldFrameHeaderWriter(crypto));
        PacketParser<WorldCommands> authPacketParser = new(_opcodeRegistryFactory.Create());

        _networkClient = new NetworkClient<WorldCommands>(host, port, frameReader, frameWriter, authPacketParser, _eventBus);
        _networkClient.Connected += OnConnected;
        _networkClient.Disconnected += OnDisconnected;

        _authChallengeProcess = new AuthChallengeProcess(_networkClient, realmId, username, sessionKey, crypto);
        _charactersListProcess = new CharactersListProcess(_networkClient);
        _characterLoginProcess = new CharacterLoginProcess(_networkClient);

        InitializeEventBus();
    }

    public void Dispose()
    {
        _networkClient.Connected -= OnConnected;
        _networkClient.Disconnected -= OnDisconnected;
        _networkClient.Dispose();
        _authChallengeProcess.Dispose();
        _charactersListProcess.Dispose();
        ReleaseEventBus();
    }

    public async Task<bool> AuthenticateAsync()
    {
        return await _authChallengeProcess.AuthenticateAsync();
    }

    public async Task<Character[]> GetCharacterListAsync()
    {
        return await _charactersListProcess.GetCharacterListAsync();
    }

    public async Task<bool> LoginCharacter(ulong guid)
    {
        return await _characterLoginProcess.LoginCharacter(guid);
    }

    private void OnConnected()
    {
        Connected?.Invoke();
    }

    private void OnDisconnected()
    {
        Disconnected?.Invoke();
    }

    private void InitializeEventBus()
    {
        _eventBus.Subscribe<ServerAuthChallengeRequest>(WorldCommands.SERVER_AUTH_CHALLENGE, _authChallengeProcess.OnServerAuthChallengeRequest);
        _eventBus.Subscribe<ServerAuthChallengeResult>(WorldCommands.SERVER_AUTH_RESPONSE, _authChallengeProcess.OnServerAuthChallengeResult);
        _eventBus.Subscribe<ServerCharactersListResponse>(WorldCommands.SMSG_CHAR_ENUM, _charactersListProcess.OnServerCharactersListResponse);
        _eventBus.Subscribe<ServerCharacterLoginResponse>(WorldCommands.SMSG_LOGIN_VERIFY_WORLD, _characterLoginProcess.OnServerCharacterLoginResponse);
    }

    private void ReleaseEventBus()
    {
        _eventBus.Unsubscribe<ServerAuthChallengeRequest>(WorldCommands.SERVER_AUTH_CHALLENGE, _authChallengeProcess.OnServerAuthChallengeRequest);
        _eventBus.Unsubscribe<ServerAuthChallengeResult>(WorldCommands.SERVER_AUTH_RESPONSE, _authChallengeProcess.OnServerAuthChallengeResult);
        _eventBus.Unsubscribe<ServerCharactersListResponse>(WorldCommands.SMSG_CHAR_ENUM, _charactersListProcess.OnServerCharactersListResponse);
        _eventBus.Unsubscribe<ServerCharacterLoginResponse>(WorldCommands.SMSG_LOGIN_VERIFY_WORLD, _characterLoginProcess.OnServerCharacterLoginResponse);
    }
}