using TrinityCore._3._3._5.ClientLibrary.Network.Core.Packets;
using TrinityCore._3._3._5.ClientLibrary.Shared.Enums;
using TrinityCore._3._3._5.ClientLibrary.WorldNetwork.Models.Enums;
using TrinityCore._3._3._5.ClientLibrary.WorldState.Enums;
using TrinityCore._3._3._5.ClientLibrary.WorldState.Models.Environment;

namespace TrinityCore._3._3._5.ClientLibrary.WorldNetwork.Models.Messages.States.Environment;

public class ServerWeather : ParsedPacket<WorldCommands>
{
    private ServerWeather(byte[]? data = null) : base(WorldCommands.SMSG_WEATHER, data)
    {
    }

    public Weather Weather { get; set; } = new();

    public static ServerWeather Parse(RawPacket<WorldCommands> rawPacket)
    {
        ServerWeather packet = new(rawPacket.Payload);
        packet.Weather.WeatherState = (WeatherState)packet.ReadUInt32();
        packet.Weather.Intensity = packet.ReadSingle();
        packet.Weather.Abrupt = packet.ReadByte() != 0;
        return packet;
    }
}