using TrinityCore._3._3._5.ClientLibrary.Network.Core.Packets;
using TrinityCore._3._3._5.ClientLibrary.WorldNetwork.Models.Enums;

namespace TrinityCore._3._3._5.ClientLibrary.WorldNetwork.Models.Results;

public class Item
{
    internal Item(ParsedPacket<WorldCommands> packet)
    {
        DisplayId = packet.ReadUInt32();
        InventoryType = packet.ReadByte();
        packet.ReadUInt32();
    }

    public uint DisplayId { get; set; }
    public byte InventoryType { get; set; }
}