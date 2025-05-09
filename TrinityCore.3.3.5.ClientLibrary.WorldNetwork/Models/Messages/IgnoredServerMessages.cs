using TrinityCore._3._3._5.ClientLibrary.Network.Core.Packets;
using TrinityCore._3._3._5.ClientLibrary.Shared.Enums;

namespace TrinityCore._3._3._5.ClientLibrary.WorldNetwork.Models.Messages;

public class IgnoredServerMessage : ParsedPacket<WorldCommands>
{
    public IgnoredServerMessage(WorldCommands command, byte[]? data = null) : base(command, data)
    {
    }

    public static IgnoredServerMessage Parse(RawPacket<WorldCommands> rawPacket)
    {
        IgnoredServerMessage packet = new(rawPacket.Opcode, rawPacket.Payload);
        packet.ReadBytes(packet.DataLeftLength());
        return packet;
    }
}