using TrinityCore._3._3._5.ClientLibrary.Network.Core.Packets;
using TrinityCore._3._3._5.ClientLibrary.Shared.Enums;
using TrinityCore._3._3._5.ClientLibrary.WorldNetwork.Models.Enums;

namespace TrinityCore._3._3._5.ClientLibrary.WorldNetwork.Models.Messages;

public class ServerTimeSyncRequest : ParsedPacket<WorldCommands>
{
    private ServerTimeSyncRequest(byte[]? data = null) : base(WorldCommands.SMSG_TIME_SYNC_REQ, data)
    {
    }

    public uint SyncNextCounter { get; set; }

    public static ServerTimeSyncRequest? Parse(RawPacket<WorldCommands> rawPacket)
    {
        ServerTimeSyncRequest packet = new(rawPacket.Payload);
        packet.SyncNextCounter = packet.ReadUInt32();
        return packet;
    }
}