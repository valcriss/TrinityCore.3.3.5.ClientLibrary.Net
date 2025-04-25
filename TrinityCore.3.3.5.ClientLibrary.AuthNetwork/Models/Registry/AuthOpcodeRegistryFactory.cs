using TrinityCore._3._3._5.ClientLibrary.AuthNetwork.Enums;
using TrinityCore._3._3._5.ClientLibrary.AuthNetwork.Models.Messages;
using TrinityCore._3._3._5.ClientLibrary.Network.Core.Registry;

namespace TrinityCore._3._3._5.ClientLibrary.AuthNetwork.Models.Registry;

public class AuthOpcodeRegistryFactory
{
    public OpcodeRegistry<AuthCommands> Create()
    {
        OpcodeRegistry<AuthCommands> registry = new();
        registry.Register(AuthCommands.LOGON_CHALLENGE, LogonChallengeResponse.Parse);
        registry.Register(AuthCommands.LOGON_PROOF, AuthProofResponse.Parse);
        registry.Register(AuthCommands.REALM_LIST, RealmListResponse.Parse);
        return registry;
    }
}