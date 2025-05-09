using TrinityCore._3._3._5.ClientLibrary.Network.Core.Packets;
using TrinityCore._3._3._5.ClientLibrary.Shared.Enums;
using TrinityCore._3._3._5.ClientLibrary.WorldState.Models.Environment;

namespace TrinityCore._3._3._5.ClientLibrary.WorldNetwork.Models.Messages.States.Environment;

public class ServerThreatClear : ParsedPacket<WorldCommands>
{
    public ServerThreatClear(byte[]? data = null) : base(WorldCommands.SMSG_THREAT_CLEAR, data)
    {
    }

    public ThreatClear ThreatClear { get; set; } = new();

    public static ServerThreatClear Parse(RawPacket<WorldCommands> rawPacket)
    {
        ServerThreatClear packet = new(rawPacket.Payload);
        packet.ThreatClear.Guid = packet.ReadPackedGuid();
        return packet;
    }
}