using TrinityCore._3._3._5.ClientLibrary.Network.Core.Packets;
using TrinityCore._3._3._5.ClientLibrary.Shared.Enums;

namespace TrinityCore._3._3._5.ClientLibrary.WorldNetwork.Models.Messages;

public class ClientKeepAliveRequest : OutgoingPacket<WorldCommands>
{
    public ClientKeepAliveRequest() : base(WorldCommands.CMSG_KEEP_ALIVE)
    {
    }
}