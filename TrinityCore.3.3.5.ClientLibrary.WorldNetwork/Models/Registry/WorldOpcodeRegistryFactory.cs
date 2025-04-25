using TrinityCore._3._3._5.ClientLibrary.Network.Core.Registry;
using TrinityCore._3._3._5.ClientLibrary.WorldNetwork.Models.Enums;
using TrinityCore._3._3._5.ClientLibrary.WorldNetwork.Models.Messages;

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
        return registry;
    }
}