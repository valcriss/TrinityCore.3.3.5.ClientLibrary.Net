using TrinityCore._3._3._5.ClientLibrary.Network.Core.Registry;
using TrinityCore._3._3._5.ClientLibrary.Shared.Enums;
using TrinityCore._3._3._5.ClientLibrary.WorldNetwork.Models.Enums;
using TrinityCore._3._3._5.ClientLibrary.WorldNetwork.Models.Messages;
using TrinityCore._3._3._5.ClientLibrary.WorldNetwork.Models.Messages.States.Account;
using TrinityCore._3._3._5.ClientLibrary.WorldNetwork.Models.Messages.States.Environment;
using TrinityCore._3._3._5.ClientLibrary.WorldNetwork.Models.Messages.States.Player;
using TrinityCore._3._3._5.ClientLibrary.WorldNetwork.Models.Messages.States.Server;
using TrinityCore._3._3._5.ClientLibrary.WorldNetwork.Models.Messages.States.Social;

namespace TrinityCore._3._3._5.ClientLibrary.WorldNetwork.Models.Registry;

public class WorldOpcodeRegistryFactory
{
    public OpcodeRegistry<WorldCommands> Create()
    {
        OpcodeRegistry<WorldCommands> registry = new();

        // Ignored commands
        registry.Register(WorldCommands.SMSG_LEARNED_DANCE_MOVES, IgnoredServerMessage.Parse);
        registry.Register(WorldCommands.SMSG_ADDON_INFO, IgnoredServerMessage.Parse);
        registry.Register(WorldCommands.SMSG_AURA_UPDATE_ALL, IgnoredServerMessage.Parse);
        registry.Register(WorldCommands.SMSG_AURA_UPDATE, IgnoredServerMessage.Parse);
        // Movement Update commands
        registry.Register(WorldCommands.MSG_MOVE_START_FORWARD, ServerMoveUpdate.Parse);
        registry.Register(WorldCommands.MSG_MOVE_START_BACKWARD, ServerMoveUpdate.Parse);
        registry.Register(WorldCommands.MSG_MOVE_STOP, ServerMoveUpdate.Parse);
        registry.Register(WorldCommands.MSG_MOVE_START_STRAFE_LEFT, ServerMoveUpdate.Parse);
        registry.Register(WorldCommands.MSG_MOVE_START_STRAFE_RIGHT, ServerMoveUpdate.Parse);
        registry.Register(WorldCommands.MSG_MOVE_STOP_STRAFE, ServerMoveUpdate.Parse);
        registry.Register(WorldCommands.MSG_MOVE_JUMP, ServerMoveUpdate.Parse);
        registry.Register(WorldCommands.MSG_MOVE_START_TURN_LEFT, ServerMoveUpdate.Parse);
        registry.Register(WorldCommands.MSG_MOVE_START_TURN_RIGHT, ServerMoveUpdate.Parse);
        registry.Register(WorldCommands.MSG_MOVE_STOP_TURN, ServerMoveUpdate.Parse);
        registry.Register(WorldCommands.MSG_MOVE_START_PITCH_UP, ServerMoveUpdate.Parse);
        registry.Register(WorldCommands.MSG_MOVE_START_PITCH_DOWN, ServerMoveUpdate.Parse);
        registry.Register(WorldCommands.MSG_MOVE_STOP_PITCH, ServerMoveUpdate.Parse);
        registry.Register(WorldCommands.MSG_MOVE_SET_RUN_MODE, ServerMoveUpdate.Parse);
        registry.Register(WorldCommands.MSG_MOVE_SET_WALK_MODE, ServerMoveUpdate.Parse);
        registry.Register(WorldCommands.MSG_MOVE_FALL_LAND, ServerMoveUpdate.Parse);
        registry.Register(WorldCommands.MSG_MOVE_START_SWIM, ServerMoveUpdate.Parse);
        registry.Register(WorldCommands.MSG_MOVE_STOP_SWIM, ServerMoveUpdate.Parse);
        registry.Register(WorldCommands.MSG_MOVE_SET_FACING, ServerMoveUpdate.Parse);
        registry.Register(WorldCommands.MSG_MOVE_SET_PITCH, ServerMoveUpdate.Parse);
        registry.Register(WorldCommands.MSG_MOVE_HEARTBEAT, ServerMoveUpdate.Parse);
        registry.Register(WorldCommands.MSG_MOVE_START_ASCEND, ServerMoveUpdate.Parse);
        registry.Register(WorldCommands.MSG_MOVE_STOP_ASCEND, ServerMoveUpdate.Parse);
        registry.Register(WorldCommands.MSG_MOVE_START_DESCEND, ServerMoveUpdate.Parse);
        // Client commands
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
        registry.Register(WorldCommands.SMSG_INITIALIZE_FACTIONS, ServerInitializeFactionsInfo.Parse);
        registry.Register(WorldCommands.SMSG_TIME_SYNC_REQ, ServerTimeSyncRequest.Parse);
        registry.Register(WorldCommands.SMSG_ACTION_BUTTONS, ServerActionButtons.Parse);
        registry.Register(WorldCommands.SMSG_WEATHER, ServerWeather.Parse);
        registry.Register(WorldCommands.SMSG_EQUIPMENT_SET_LIST, ServerEquipmentSetList.Parse);
        registry.Register(WorldCommands.SMSG_SET_FORCED_REACTIONS, ServerForcedReactions.Parse);
        registry.Register(WorldCommands.SMSG_INIT_WORLD_STATES, ServerInitWorldStates.Parse);
        registry.Register(WorldCommands.SMSG_UPDATE_WORLD_STATE, ServerUpdateWorldState.Parse);
        registry.Register(WorldCommands.SMSG_SET_PROFICIENCY, ServerProficiency.Parse);
        registry.Register(WorldCommands.SMSG_UPDATE_OBJECT, ServerUpdateObjectInfo.Parse);
        registry.Register(WorldCommands.SMSG_MONSTER_MOVE, ServerMonsterMove.Parse);
        registry.Register(WorldCommands.SMSG_SPELL_GO, ServerSpellGo.Parse);
        registry.Register(WorldCommands.SMSG_QUESTGIVER_STATUS_MULTIPLE, ServerQuestGiverStatusMultiple.Parse);
        registry.Register(WorldCommands.SMSG_DESTROY_OBJECT, ServerDestroyObject.Parse);
        registry.Register(WorldCommands.SMSG_HIGHEST_THREAT_UPDATE, ServerHighestThreatUpdate.Parse);
        registry.Register(WorldCommands.SMSG_AI_REACTION, ServerAiReaction.Parse);
        registry.Register(WorldCommands.SMSG_ATTACKSTART, ServerAttackStartInfo.Parse);
        registry.Register(WorldCommands.SMSG_ATTACKSTOP, ServerAttackStopInfo.Parse);
        registry.Register(WorldCommands.SMSG_THREAT_CLEAR, ServerThreatClear.Parse);
        
        return registry;
    }
}