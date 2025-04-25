using TrinityCore._3._3._5.ClientLibrary.Network.Core.Packets;
using TrinityCore._3._3._5.ClientLibrary.WorldNetwork.Models.Enums;

namespace TrinityCore._3._3._5.ClientLibrary.WorldNetwork.Models.Results;

public class Character
{
    public byte[] Bytes { get; }
    public Class Class { get; set; }
    public uint Flags { get; set; }
    public Gender Gender { get; set; }
    public ulong GUID { get; set; }
    public uint GuildId { get; set; }
    public Item[] Items { get; set; }
    public byte Level { get; set; }
    public uint MapId { get; set; }
    public string Name { get; set; }
    public float O { get; set; }
    public uint PetFamilyId { get; set; }
    public uint PetInfoId { get; set; }
    public uint PetLevel { get; set; }
    public Race Race { get; set; }
    public float X { get; set; }
    public float Y { get; set; }
    public float Z { get; set; }
    public uint ZoneId { get; set; }
    
    public Character(ParsedPacket<WorldCommands> packet)
    {
        Items = new Item[19];
        GUID = packet.ReadUInt64();
        Name = packet.ReadCString();
        Race = (Race)packet.ReadByte();
        Class = (Class)packet.ReadByte();
        Gender = (Gender)packet.ReadByte();
        Bytes = packet.ReadBytes(5);
        Level = packet.ReadByte();
        ZoneId = packet.ReadUInt32();
        MapId = packet.ReadUInt32();
        X = packet.ReadSingle();
        Y = packet.ReadSingle();
        Z = packet.ReadSingle();
        GuildId = packet.ReadUInt32();
        Flags = packet.ReadUInt32();
        packet.ReadUInt32(); // customize (rename, etc)
        packet.ReadByte(); // first login
        PetInfoId = packet.ReadUInt32();
        PetLevel = packet.ReadUInt32();
        PetFamilyId = packet.ReadUInt32();

        // read items
        for (int i = 0; i < Items.Length; ++i)
        {
            Items[i] = new Item(packet);
        }

        // read bags
        for (int i = 0; i < 4; ++i)
        {
            packet.ReadUInt32();
            packet.ReadByte();
            packet.ReadUInt32();
        }
    }
}