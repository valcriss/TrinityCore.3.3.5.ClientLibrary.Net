using TrinityCore._3._3._5.ClientLibrary.Network;
using TrinityCore._3._3._5.ClientLibrary.Network.Core;
using TrinityCore._3._3._5.ClientLibrary.Network.Core.Parsers;
using TrinityCore._3._3._5.ClientLibrary.Network.Core.Writers;
using TrinityCore._3._3._5.ClientLibrary.WorldNetwork.Models.Enums;
using TrinityCore._3._3._5.ClientLibrary.WorldNetwork.Models.Handlers;
using TrinityCore._3._3._5.ClientLibrary.WorldNetwork.Models.Messages;
using TrinityCore._3._3._5.ClientLibrary.WorldNetwork.Models.Messages.States.Account;
using TrinityCore._3._3._5.ClientLibrary.WorldNetwork.Models.Messages.States.Environment;
using TrinityCore._3._3._5.ClientLibrary.WorldNetwork.Models.Messages.States.Player;
using TrinityCore._3._3._5.ClientLibrary.WorldNetwork.Models.Messages.States.Server;
using TrinityCore._3._3._5.ClientLibrary.WorldNetwork.Models.Messages.States.Social;
using TrinityCore._3._3._5.ClientLibrary.WorldNetwork.Models.Network;
using TrinityCore._3._3._5.ClientLibrary.WorldNetwork.Models.Process;
using TrinityCore._3._3._5.ClientLibrary.WorldNetwork.Models.Registry;
using TrinityCore._3._3._5.ClientLibrary.WorldNetwork.Models.Results;
using TrinityCore._3._3._5.ClientLibrary.WorldNetwork.Models.Security;
using TrinityCore._3._3._5.ClientLibrary.WorldState;

namespace TrinityCore._3._3._5.ClientLibrary.WorldNetwork;

public class WorldNetworkClient : IDisposable
{
    private readonly AccountStateHandler _accountStateHandler;
    private readonly AuthChallengeProcess _authChallengeProcess;
    private readonly CharacterLoginProcess _characterLoginProcess;
    private readonly CharactersListProcess _charactersListProcess;
    private readonly EnvironmentStateHandler _environmentStateHandler;
    private readonly NetworkEventBus<WorldCommands> _eventBus;
    private readonly InternalProcess _internalProcess;

    private readonly NetworkClient<WorldCommands> _networkClient;
    private readonly WorldOpcodeRegistryFactory _opcodeRegistryFactory = new();
    private readonly PlayerStateHandler _playerStateHandler;
    private readonly ServerStateHandler _serverStateHandler;
    private readonly SocialStateHandler _socialStateHandler;

    public Action? Connected;
    public Action? Disconnected;

    public WorldNetworkClient(string host, int port, uint realmId, string username, byte[] sessionKey, WorldStateEventBus worldStateEventBus)
    {
        _eventBus = new NetworkEventBus<WorldCommands>();
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
        _internalProcess = new InternalProcess(_networkClient);

        _serverStateHandler = new ServerStateHandler(worldStateEventBus);
        _accountStateHandler = new AccountStateHandler(worldStateEventBus);
        _socialStateHandler = new SocialStateHandler(worldStateEventBus);
        _playerStateHandler = new PlayerStateHandler(worldStateEventBus);
        _environmentStateHandler = new EnvironmentStateHandler(worldStateEventBus);

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

    public async Task DisconnectAsync()
    {
        await _networkClient.DisconnectAsync();
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
        _eventBus.Subscribe<ClientCacheVersionInfo>(WorldCommands.SMSG_CLIENTCACHE_VERSION, _serverStateHandler.OnClientCacheVersionInfo);
        _eventBus.Subscribe<ServerTutorialFlagsInfo>(WorldCommands.SMSG_TUTORIAL_FLAGS, _accountStateHandler.OnTutorialFlags);
        _eventBus.Subscribe<ServerAccountDataTimesInfo>(WorldCommands.SMSG_ACCOUNT_DATA_TIMES, _accountStateHandler.OnAccountDataTimesInfo);
        _eventBus.Subscribe<ServerMessageOfTheDayInfo>(WorldCommands.SMSG_MOTD, _serverStateHandler.OnServerMessageOfTheDayInfo);
        _eventBus.Subscribe<ServerLoginSetTimeSpeedInfo>(WorldCommands.SMSG_LOGIN_SETTIMESPEED, _serverStateHandler.OnServerLoginSetTimeSpeedInfo);
        _eventBus.Subscribe<ServerFeatureSystemStatusInfo>(WorldCommands.SMSG_FEATURE_SYSTEM_STATUS, _serverStateHandler.OnServerFeatureSystemStatusInfo);
        _eventBus.Subscribe<ServerContactListInfo>(WorldCommands.SMSG_CONTACT_LIST, _socialStateHandler.OnServerContactListInfo);
        _eventBus.Subscribe<ServerAllAchievementDataInfo>(WorldCommands.SMSG_ALL_ACHIEVEMENT_DATA, _playerStateHandler.OnServerAllAchievementDataInfo);
        _eventBus.Subscribe<ServerBindPointUpdate>(WorldCommands.SMSG_BINDPOINTUPDATE, _playerStateHandler.OnServerBindPointUpdate);
        _eventBus.Subscribe<ServerDungeonDifficultyInfo>(WorldCommands.MSG_SET_DUNGEON_DIFFICULTY, _playerStateHandler.OnServerDungeonDifficultyInfo);
        _eventBus.Subscribe<ServerInstanceDifficultyInfo>(WorldCommands.SMSG_INSTANCE_DIFFICULTY, _playerStateHandler.OnServerInstanceDifficultyInfo);
        _eventBus.Subscribe<ServerTalentsInfo>(WorldCommands.SMSG_TALENTS_INFO, _playerStateHandler.OnServerTalentsInfo);
        _eventBus.Subscribe<ServerInitialSpellsInfo>(WorldCommands.SMSG_INITIAL_SPELLS, _playerStateHandler.OnServerInitialSpellsInfo);
        _eventBus.Subscribe<ServerUnlearnedSpellsInfo>(WorldCommands.SMSG_SEND_UNLEARN_SPELLS, _playerStateHandler.OnServerUnlearnedSpellsInfo);
        _eventBus.Subscribe<ServerPowerUpdateInfo>(WorldCommands.SMSG_POWER_UPDATE, _playerStateHandler.OnServerPowerUpdateInfo);
        _eventBus.Subscribe<ServerInitializeFactionsInfo>(WorldCommands.SMSG_INITIALIZE_FACTIONS, _playerStateHandler.OnServerInitializeFactionsInfo);
        _eventBus.Subscribe<ServerTimeSyncRequest>(WorldCommands.SMSG_TIME_SYNC_REQ, _internalProcess.OnServerTimeSyncRequest);
        _eventBus.Subscribe<ServerActionButtons>(WorldCommands.SMSG_ACTION_BUTTONS, _playerStateHandler.OnServerActionButtons);
        _eventBus.Subscribe<ServerWeather>(WorldCommands.SMSG_WEATHER, _environmentStateHandler.OnServerWeather);
        _eventBus.Subscribe<ServerEquipmentSetList>(WorldCommands.SMSG_EQUIPMENT_SET_LIST, _playerStateHandler.OnServerEquipmentSetList);
        _eventBus.Subscribe<ServerForcedReactions>(WorldCommands.SMSG_SET_FORCED_REACTIONS, _playerStateHandler.OnServerForcedReactions);
        _eventBus.Subscribe<ServerInitWorldStates>(WorldCommands.SMSG_INIT_WORLD_STATES, _playerStateHandler.OnServerInitWorldStates);
        _eventBus.Subscribe<ServerUpdateWorldState>(WorldCommands.SMSG_UPDATE_WORLD_STATE, _playerStateHandler.OnServerUpdateWorldState);
        _eventBus.Subscribe<ServerProficiency>(WorldCommands.SMSG_SET_PROFICIENCY, _playerStateHandler.OnServerProficiency);
        _eventBus.Subscribe<ServerUpdateObjectInfo>(WorldCommands.SMSG_UPDATE_OBJECT, _environmentStateHandler.OnServerUpdateObjectInfo);
    }

    private void ReleaseEventBus()
    {
        _eventBus.Unsubscribe<ServerAuthChallengeRequest>(WorldCommands.SERVER_AUTH_CHALLENGE, _authChallengeProcess.OnServerAuthChallengeRequest);
        _eventBus.Unsubscribe<ServerAuthChallengeResult>(WorldCommands.SERVER_AUTH_RESPONSE, _authChallengeProcess.OnServerAuthChallengeResult);
        _eventBus.Unsubscribe<ServerCharactersListResponse>(WorldCommands.SMSG_CHAR_ENUM, _charactersListProcess.OnServerCharactersListResponse);
        _eventBus.Unsubscribe<ServerCharacterLoginResponse>(WorldCommands.SMSG_LOGIN_VERIFY_WORLD, _characterLoginProcess.OnServerCharacterLoginResponse);
        _eventBus.Unsubscribe<ClientCacheVersionInfo>(WorldCommands.SMSG_CLIENTCACHE_VERSION, _serverStateHandler.OnClientCacheVersionInfo);
        _eventBus.Unsubscribe<ServerTutorialFlagsInfo>(WorldCommands.SMSG_TUTORIAL_FLAGS, _accountStateHandler.OnTutorialFlags);
        _eventBus.Unsubscribe<ServerAccountDataTimesInfo>(WorldCommands.SMSG_ACCOUNT_DATA_TIMES, _accountStateHandler.OnAccountDataTimesInfo);
        _eventBus.Unsubscribe<ServerMessageOfTheDayInfo>(WorldCommands.SMSG_MOTD, _serverStateHandler.OnServerMessageOfTheDayInfo);
        _eventBus.Unsubscribe<ServerLoginSetTimeSpeedInfo>(WorldCommands.SMSG_LOGIN_SETTIMESPEED, _serverStateHandler.OnServerLoginSetTimeSpeedInfo);
        _eventBus.Unsubscribe<ServerFeatureSystemStatusInfo>(WorldCommands.SMSG_FEATURE_SYSTEM_STATUS, _serverStateHandler.OnServerFeatureSystemStatusInfo);
        _eventBus.Unsubscribe<ServerContactListInfo>(WorldCommands.SMSG_CONTACT_LIST, _socialStateHandler.OnServerContactListInfo);
        _eventBus.Unsubscribe<ServerAllAchievementDataInfo>(WorldCommands.SMSG_ALL_ACHIEVEMENT_DATA, _playerStateHandler.OnServerAllAchievementDataInfo);
        _eventBus.Unsubscribe<ServerBindPointUpdate>(WorldCommands.SMSG_BINDPOINTUPDATE, _playerStateHandler.OnServerBindPointUpdate);
        _eventBus.Unsubscribe<ServerDungeonDifficultyInfo>(WorldCommands.MSG_SET_DUNGEON_DIFFICULTY, _playerStateHandler.OnServerDungeonDifficultyInfo);
        _eventBus.Unsubscribe<ServerInstanceDifficultyInfo>(WorldCommands.SMSG_INSTANCE_DIFFICULTY, _playerStateHandler.OnServerInstanceDifficultyInfo);
        _eventBus.Unsubscribe<ServerTalentsInfo>(WorldCommands.SMSG_TALENTS_INFO, _playerStateHandler.OnServerTalentsInfo);
        _eventBus.Unsubscribe<ServerInitialSpellsInfo>(WorldCommands.SMSG_INITIAL_SPELLS, _playerStateHandler.OnServerInitialSpellsInfo);
        _eventBus.Unsubscribe<ServerUnlearnedSpellsInfo>(WorldCommands.SMSG_SEND_UNLEARN_SPELLS, _playerStateHandler.OnServerUnlearnedSpellsInfo);
        _eventBus.Unsubscribe<ServerPowerUpdateInfo>(WorldCommands.SMSG_POWER_UPDATE, _playerStateHandler.OnServerPowerUpdateInfo);
        _eventBus.Unsubscribe<ServerInitializeFactionsInfo>(WorldCommands.SMSG_INITIALIZE_FACTIONS, _playerStateHandler.OnServerInitializeFactionsInfo);
        _eventBus.Unsubscribe<ServerTimeSyncRequest>(WorldCommands.SMSG_TIME_SYNC_REQ, _internalProcess.OnServerTimeSyncRequest);
        _eventBus.Unsubscribe<ServerActionButtons>(WorldCommands.SMSG_ACTION_BUTTONS, _playerStateHandler.OnServerActionButtons);
        _eventBus.Unsubscribe<ServerWeather>(WorldCommands.SMSG_WEATHER, _environmentStateHandler.OnServerWeather);
        _eventBus.Unsubscribe<ServerEquipmentSetList>(WorldCommands.SMSG_EQUIPMENT_SET_LIST, _playerStateHandler.OnServerEquipmentSetList);
        _eventBus.Unsubscribe<ServerForcedReactions>(WorldCommands.SMSG_SET_FORCED_REACTIONS, _playerStateHandler.OnServerForcedReactions);
        _eventBus.Unsubscribe<ServerInitWorldStates>(WorldCommands.SMSG_INIT_WORLD_STATES, _playerStateHandler.OnServerInitWorldStates);
        _eventBus.Unsubscribe<ServerUpdateWorldState>(WorldCommands.SMSG_UPDATE_WORLD_STATE, _playerStateHandler.OnServerUpdateWorldState);
        _eventBus.Unsubscribe<ServerProficiency>(WorldCommands.SMSG_SET_PROFICIENCY, _playerStateHandler.OnServerProficiency);
        _eventBus.Unsubscribe<ServerUpdateObjectInfo>(WorldCommands.SMSG_UPDATE_OBJECT, _environmentStateHandler.OnServerUpdateObjectInfo);
    }
}