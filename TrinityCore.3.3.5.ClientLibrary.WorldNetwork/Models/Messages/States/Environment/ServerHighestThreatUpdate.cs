using TrinityCore._3._3._5.ClientLibrary.Network.Core.Packets;
using TrinityCore._3._3._5.ClientLibrary.Shared.Enums;
using TrinityCore._3._3._5.ClientLibrary.WorldState.Models.Environment;

namespace TrinityCore._3._3._5.ClientLibrary.WorldNetwork.Models.Messages.States.Environment;

public class ServerHighestThreatUpdate : ParsedPacket<WorldCommands>
{
    public ServerHighestThreatUpdate(byte[]? data = null) : base(WorldCommands.SMSG_HIGHEST_THREAT_UPDATE, data)
    {
    }

    public ThreatData ThreatData { get; set; } = new();

    public static ServerHighestThreatUpdate Parse(RawPacket<WorldCommands> rawPacket)
    {
        ServerHighestThreatUpdate packet = new(rawPacket.Payload);
        packet.ThreatData.Guid = packet.ReadPackedGuid();
        packet.ThreatData.HighestThreatGuid = packet.ReadPackedGuid();
        uint count = packet.ReadUInt32();
        for (uint i = 0; i < count; i++)
            packet.ThreatData.ThreatItems.Add(new ThreatItem
            {
                Target = packet.ReadPackedGuid(),
                Value = packet.ReadUInt32()
            });
        return packet;
    }
}