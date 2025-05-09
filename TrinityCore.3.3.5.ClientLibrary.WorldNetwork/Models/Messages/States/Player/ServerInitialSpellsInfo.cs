using TrinityCore._3._3._5.ClientLibrary.Network.Core.Packets;
using TrinityCore._3._3._5.ClientLibrary.Shared.Enums;
using TrinityCore._3._3._5.ClientLibrary.Shared.Logger;
using TrinityCore._3._3._5.ClientLibrary.WorldState.Models.Player;

namespace TrinityCore._3._3._5.ClientLibrary.WorldNetwork.Models.Messages.States.Player;

public class ServerInitialSpellsInfo : ParsedPacket<WorldCommands>
{
    public ServerInitialSpellsInfo(byte[]? data = null) : base(WorldCommands.SMSG_INITIAL_SPELLS, data)
    {
    }

    public SpellsList SpellsList { get; set; } = new();

    public static ServerInitialSpellsInfo Parse(RawPacket<WorldCommands> rawPacket)
    {
        ServerInitialSpellsInfo packet = new(rawPacket.Payload);
        byte packetControl = packet.ReadByte();
        if (packetControl != 0x00)
        {
            Log.Error($"Received initial spells info packet control != 0x00 ({packetControl})");
            return new ServerInitialSpellsInfo();
        }

        ushort count = packet.ReadUInt16();
        for (int i = 0; i < count; i++)
        {
            uint id = packet.ReadUInt32();
            ushort spellControl = packet.ReadUInt16();
            if (spellControl != 0x00)
            {
                Log.Error($"Received initial spells info spell control != 0x00 ({id} - {spellControl})");
                continue;
            }

            packet.SpellsList.Spells.Add(new Spell { Id = id });
        }

        return packet;
    }
}