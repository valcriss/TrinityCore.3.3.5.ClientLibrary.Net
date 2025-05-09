using TrinityCore._3._3._5.ClientLibrary.Network.Core.Packets;
using TrinityCore._3._3._5.ClientLibrary.Shared.Enums;
using TrinityCore._3._3._5.ClientLibrary.WorldState.Enums;
using TrinityCore._3._3._5.ClientLibrary.WorldState.Models.Player;

namespace TrinityCore._3._3._5.ClientLibrary.WorldNetwork.Models.Messages.States.Player;

public class ServerPowerUpdateInfo : ParsedPacket<WorldCommands>
{
    public ServerPowerUpdateInfo(byte[]? data = null) : base(WorldCommands.SMSG_POWER_UPDATE, data)
    {
    }

    public PowerUpdate PowerUpdate { get; set; } = new();

    public static ServerPowerUpdateInfo Parse(RawPacket<WorldCommands> rawPacket)
    {
        ServerPowerUpdateInfo packet = new(rawPacket.Payload);
        packet.PowerUpdate.Guid = packet.ReadPackedGuid();
        packet.PowerUpdate.Power = (Powers)packet.ReadSByte();
        packet.PowerUpdate.Value = packet.ReadUInt32();
        return packet;
    }
}