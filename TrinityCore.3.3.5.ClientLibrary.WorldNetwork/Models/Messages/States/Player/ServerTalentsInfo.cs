using TrinityCore._3._3._5.ClientLibrary.Network.Core.Packets;
using TrinityCore._3._3._5.ClientLibrary.WorldNetwork.Models.Enums;
using TrinityCore._3._3._5.ClientLibrary.WorldState.Models.Player;

namespace TrinityCore._3._3._5.ClientLibrary.WorldNetwork.Models.Messages.States.Player;

public class ServerTalentsInfo : ParsedPacket<WorldCommands>
{
    private const sbyte MAX_TALENT_SPECS = 2;

    private ServerTalentsInfo(byte[]? data = null) : base(WorldCommands.SMSG_TALENTS_INFO, data)
    {
    }

    public TalentsInformations TalentsInfo { get; set; } = new();

    public static ServerTalentsInfo Parse(RawPacket<WorldCommands> rawPacket)
    {
        ServerTalentsInfo packet = new(rawPacket.Payload);

        packet.TalentsInfo.IsPet = packet.ReadSByte() != 0;
        if (packet.TalentsInfo.IsPet)
            LoadPetTalents(packet);
        else
            LoadPlayerTalents(packet);

        return packet;
    }

    private static void LoadPetTalents(ServerTalentsInfo packet)
    {
        packet.TalentsInfo.UnSpendPoints = packet.ReadUInt32();
        sbyte count = packet.ReadSByte();
        for (int i = 0; i < count; i++)
            packet.TalentsInfo.Talents.Add(new Talent
            {
                TalentId = packet.ReadUInt32(),
                TalentRank = packet.ReadSByte()
            });
    }

    private static void LoadPlayerTalents(ServerTalentsInfo packet)
    {
        packet.TalentsInfo.UnSpendPoints = packet.ReadUInt32();
        sbyte talentGroupCount = packet.ReadSByte();
        packet.ReadSByte();

        if (talentGroupCount == 0) return;
        if (talentGroupCount > MAX_TALENT_SPECS)
            talentGroupCount = MAX_TALENT_SPECS;

        for (int group = 0; group < talentGroupCount; group++)
        {
            sbyte talentsToLoad = packet.ReadSByte();
            LoadTalents(packet, group, talentsToLoad);

            sbyte glyphsToLoad = packet.ReadSByte();
            LoadGlyphs(packet, group, glyphsToLoad);
        }
    }

    private static void LoadTalents(ServerTalentsInfo packet, int group, sbyte talentsToLoad)
    {
        for (int j = 0; j < talentsToLoad; j++)
            packet.TalentsInfo.Talents.Add(new Talent
            {
                Group = group,
                TalentId = packet.ReadUInt32(),
                TalentRank = packet.ReadSByte()
            });
    }

    private static void LoadGlyphs(ServerTalentsInfo packet, int group, sbyte glyphsToLoad)
    {
        for (int j = 0; j < glyphsToLoad; j++)
            packet.TalentsInfo.Glyphs.Add(new Glyph
            {
                Group = group,
                GlyphId = packet.ReadUInt16()
            });
    }
}