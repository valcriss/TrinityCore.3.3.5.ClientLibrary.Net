using TrinityCore._3._3._5.ClientLibrary.Network.Core.Registry;
using TrinityCore._3._3._5.ClientLibrary.WorldNetwork.Models.Enums;
using TrinityCore._3._3._5.ClientLibrary.WorldNetwork.Models.Messages;
using TrinityCore._3._3._5.ClientLibrary.WorldNetwork.Models.Messages.States.Account;
using TrinityCore._3._3._5.ClientLibrary.WorldNetwork.Models.Messages.States.Player;
using TrinityCore._3._3._5.ClientLibrary.WorldNetwork.Models.Messages.States.Server;
using TrinityCore._3._3._5.ClientLibrary.WorldNetwork.Models.Messages.States.Social;

namespace TrinityCore._3._3._5.ClientLibrary.WorldNetwork.Models.Registry;

public class WorldOpcodeRegistryFactory
{
    public OpcodeRegistry<WorldCommands> Create()
    {
        OpcodeRegistry<WorldCommands> registry = new();
        registry.Register(WorldCommands.SERVER_AUTH_CHALLENGE, ServerAuthChallengeRequest.Parse);
        registry.Register(WorldCommands.SERVER_AUTH_RESPONSE, ServerAuthChallengeResult.Parse);
        registry.Register(WorldCommands.SMSG_CHAR_ENUM, ServerCharactersListResponse.Parse);
        registry.Register(WorldCommands.SMSG_LOGIN_VERIFY_WORLD, ServerCharacterLoginResponse.Parse);
        registry.Register(WorldCommands.SMSG_CLIENTCACHE_VERSION, ClientCacheVersionInfo.Parse);
        registry.Register(WorldCommands.SMSG_TUTORIAL_FLAGS, ServerTutorialFlagsInfo.Parse);
        registry.Register(WorldCommands.SMSG_MOTD, ServerMessageOfTheDayInfo.Parse);
        registry.Register(WorldCommands.SMSG_LOGIN_SETTIMESPEED, ServerLoginSetTimeSpeedInfo.Parse);
        registry.Register(WorldCommands.SMSG_ACCOUNT_DATA_TIMES, ServerAccountDataTimesInfo.Parse);
        registry.Register(WorldCommands.SMSG_FEATURE_SYSTEM_STATUS, ServerFeatureSystemStatusInfo.Parse);
        registry.Register(WorldCommands.SMSG_CONTACT_LIST, ServerContactListInfo.Parse);
        registry.Register(WorldCommands.SMSG_ALL_ACHIEVEMENT_DATA, ServerAllAchievementDataInfo.Parse);
        registry.Register(WorldCommands.SMSG_BINDPOINTUPDATE, ServerBindPointUpdate.Parse);
        registry.Register(WorldCommands.MSG_SET_DUNGEON_DIFFICULTY, ServerDungeonDifficultyInfo.Parse);
        registry.Register(WorldCommands.SMSG_INSTANCE_DIFFICULTY, ServerInstanceDifficultyInfo.Parse);
        registry.Register(WorldCommands.SMSG_TALENTS_INFO, ServerTalentsInfo.Parse);
        registry.Register(WorldCommands.SMSG_INITIAL_SPELLS, ServerInitialSpellsInfo.Parse);
        registry.Register(WorldCommands.SMSG_SEND_UNLEARN_SPELLS, ServerUnlearnedSpellsInfo.Parse);
        registry.Register(WorldCommands.SMSG_POWER_UPDATE, ServerPowerUpdateInfo.Parse);

        return registry;
    }
}