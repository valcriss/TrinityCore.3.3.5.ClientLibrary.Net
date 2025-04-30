using TrinityCore._3._3._5.ClientLibrary.Network.Core.Packets;
using TrinityCore._3._3._5.ClientLibrary.Shared.Enums;
using TrinityCore._3._3._5.ClientLibrary.WorldNetwork.Models.Enums;
using TrinityCore._3._3._5.ClientLibrary.WorldState.Models.Server;

namespace TrinityCore._3._3._5.ClientLibrary.WorldNetwork.Models.Messages.States.Server;

public class ServerLoginSetTimeSpeedInfo : ParsedPacket<WorldCommands>
{
    private ServerLoginSetTimeSpeedInfo(byte[]? data = null) : base(WorldCommands.SMSG_LOGIN_SETTIMESPEED, data)
    {
    }

    public TimeSpeedInfo TimeSpeedInfo { get; set; } = new();

    public static ServerLoginSetTimeSpeedInfo Parse(RawPacket<WorldCommands> rawPacket)
    {
        ServerLoginSetTimeSpeedInfo packet = new(rawPacket.Payload);
        packet.TimeSpeedInfo.GameTime = packet.ReadPackedDate();
        packet.TimeSpeedInfo.TimeSpeed = packet.ReadSingle();
        packet.TimeSpeedInfo.TimeHolidayOffset = packet.ReadInt32();
        return packet;
    }
}