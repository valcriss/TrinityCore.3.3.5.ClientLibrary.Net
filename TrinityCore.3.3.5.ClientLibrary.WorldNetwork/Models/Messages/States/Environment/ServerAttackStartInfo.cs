using TrinityCore._3._3._5.ClientLibrary.Network.Core.Packets;
using TrinityCore._3._3._5.ClientLibrary.Shared.Enums;
using TrinityCore._3._3._5.ClientLibrary.WorldState.Models.Environment;

namespace TrinityCore._3._3._5.ClientLibrary.WorldNetwork.Models.Messages.States.Environment;

public class ServerAttackStartInfo: ParsedPacket<WorldCommands>
{
    public AttackStartInfo AttackStartInfo { get; set; } = new();
    public ServerAttackStartInfo(byte[]? data = null) : base(WorldCommands.SMSG_ATTACKSTART, data)
    {
    }
    
    public static ServerAttackStartInfo Parse(RawPacket<WorldCommands> rawPacket)
    {
        ServerAttackStartInfo packet = new(rawPacket.Payload);
        packet.AttackStartInfo.Guid = packet.ReadUInt64();
        packet.AttackStartInfo.TargetGuid = packet.ReadUInt64();
        return packet;
    }
}