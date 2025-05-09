using System.Text;
using TrinityCore._3._3._5.ClientLibrary.Network.Core.Packets;
using TrinityCore._3._3._5.ClientLibrary.Shared.Enums;
using TrinityCore._3._3._5.ClientLibrary.WorldState.Models.Account;

namespace TrinityCore._3._3._5.ClientLibrary.WorldNetwork.Models.Messages.States.Server;

public class ServerMessageOfTheDayInfo : ParsedPacket<WorldCommands>
{
    private ServerMessageOfTheDayInfo(byte[]? data = null) : base(WorldCommands.SMSG_MOTD, data)
    {
    }

    public MessageOfTheDay MessageOfTheDay { get; set; } = new();

    public static ServerMessageOfTheDayInfo Parse(RawPacket<WorldCommands> rawPacket)
    {
        ServerMessageOfTheDayInfo packet = new(rawPacket.Payload);
        uint lines = packet.ReadUInt32();
        StringBuilder builder = new();
        for (int i = 0; i < lines; i++) builder.Append(packet.ReadCString() + (i != lines - 1 ? "\n" : null));
        packet.MessageOfTheDay.Message = builder.ToString();
        return packet;
    }
}