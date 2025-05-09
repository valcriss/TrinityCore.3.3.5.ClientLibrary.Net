using TrinityCore._3._3._5.ClientLibrary.Network.Core.Packets;
using TrinityCore._3._3._5.ClientLibrary.Shared.Enums;
using TrinityCore._3._3._5.ClientLibrary.WorldState.Models.Environment;

namespace TrinityCore._3._3._5.ClientLibrary.WorldNetwork.Models.Messages.States.Environment;

public class ServerAttackStopInfo : ParsedPacket<WorldCommands>
{
    public ServerAttackStopInfo(byte[]? data = null) : base(WorldCommands.SMSG_ATTACKSTOP, data)
    {
    }

    public AttackStopInfo AttackStopInfo { get; set; } = new();

    public static ServerAttackStopInfo Parse(RawPacket<WorldCommands> rawPacket)
    {
        ServerAttackStopInfo packet = new(rawPacket.Payload);
        packet.AttackStopInfo.Guid = packet.ReadPackedGuid();
        if (packet.IsDataLeft())
        {
            packet.AttackStopInfo.TargetGuid = packet.ReadPackedGuid();
            packet.AttackStopInfo.IsDead = packet.ReadUInt32() > 0;
        }

        return packet;
    }
}