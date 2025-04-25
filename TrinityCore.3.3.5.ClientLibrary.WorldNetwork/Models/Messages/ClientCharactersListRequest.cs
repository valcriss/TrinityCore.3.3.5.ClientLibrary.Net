using TrinityCore._3._3._5.ClientLibrary.Network.Core.Packets;
using TrinityCore._3._3._5.ClientLibrary.WorldNetwork.Models.Enums;

namespace TrinityCore._3._3._5.ClientLibrary.WorldNetwork.Models.Messages;

public class ClientCharactersListRequest : OutgoingPacket<WorldCommands>
{
    public ClientCharactersListRequest() : base(WorldCommands.CMSG_CHAR_ENUM)
    {
    }
}