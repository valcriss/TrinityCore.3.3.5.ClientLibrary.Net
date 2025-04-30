using TrinityCore._3._3._5.ClientLibrary.Network.Core.Packets;
using TrinityCore._3._3._5.ClientLibrary.Shared.Enums;
using TrinityCore._3._3._5.ClientLibrary.WorldNetwork.Models.Enums;
using TrinityCore._3._3._5.ClientLibrary.WorldState.Models.Player;

namespace TrinityCore._3._3._5.ClientLibrary.WorldNetwork.Models.Messages.States.Player;

public class ServerUnlearnedSpellsInfo : ParsedPacket<WorldCommands>
{
    public ServerUnlearnedSpellsInfo(byte[]? data = null) : base(WorldCommands.SMSG_SEND_UNLEARN_SPELLS, data)
    {
    }

    public UnlearnedSpellsList UnlearnedSpells { get; set; } = new();

    public static ServerUnlearnedSpellsInfo Parse(RawPacket<WorldCommands> rawPacket)
    {
        ServerUnlearnedSpellsInfo packet = new(rawPacket.Payload);
        uint count = packet.ReadUInt32();
        for (int i = 0; i < count; i++)
        {
            uint id = packet.ReadUInt32();
            packet.UnlearnedSpells.Spells.Add(new Spell { Id = id });
        }

        return packet;
    }
}