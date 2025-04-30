using TrinityCore._3._3._5.ClientLibrary.Network.Core.Packets;
using TrinityCore._3._3._5.ClientLibrary.Shared.Enums;
using TrinityCore._3._3._5.ClientLibrary.WorldNetwork.Models.Enums;

namespace TrinityCore._3._3._5.ClientLibrary.WorldNetwork.Models.Messages;

public class ClientCharacterLoginRequest : OutgoingPacket<WorldCommands>
{
    public ClientCharacterLoginRequest(ulong characterGuid) : base(WorldCommands.CMSG_PLAYER_LOGIN)
    {
        Append(characterGuid);
    }
}