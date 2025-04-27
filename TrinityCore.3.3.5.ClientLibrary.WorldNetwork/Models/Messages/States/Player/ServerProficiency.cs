using TrinityCore._3._3._5.ClientLibrary.Network.Core.Packets;
using TrinityCore._3._3._5.ClientLibrary.WorldNetwork.Models.Enums;
using TrinityCore._3._3._5.ClientLibrary.WorldState.Enums;
using TrinityCore._3._3._5.ClientLibrary.WorldState.Models.Player;

namespace TrinityCore._3._3._5.ClientLibrary.WorldNetwork.Models.Messages.States.Player;

public class ServerProficiency : ParsedPacket<WorldCommands>
{
    public ServerProficiency(byte[]? data = null) : base(WorldCommands.SMSG_SET_PROFICIENCY, data)
    {
    }

    public Proficiency Proficiency { get; set; } = new();

    public static ServerProficiency Parse(RawPacket<WorldCommands> rawPacket)
    {
        ServerProficiency packet = new(rawPacket.Payload);
        packet.Proficiency.ItemClass = (ItemClass)packet.ReadByte();
        packet.Proficiency.ProficiencyMask = packet.ReadUInt32();
        return packet;
    }
}