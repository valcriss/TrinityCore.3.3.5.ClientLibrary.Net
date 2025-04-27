using TrinityCore._3._3._5.ClientLibrary.Network.Core.Packets;
using TrinityCore._3._3._5.ClientLibrary.WorldNetwork.Models.Enums;

namespace TrinityCore._3._3._5.ClientLibrary.WorldNetwork.Models.Messages;

public class ClientTimeSyncResponse: OutgoingPacket<WorldCommands>
{
    public ClientTimeSyncResponse(uint counter) : base(WorldCommands.CMSG_TIME_SYNC_RESP)
    {
        Append(counter);
        Append((uint)DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc)).TotalSeconds);
    }
}