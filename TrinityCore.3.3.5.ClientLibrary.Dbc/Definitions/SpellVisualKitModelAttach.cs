using TrinityCore._3._3._5.ClientLibrary.Dbc.Attributes;
using TrinityCore._3._3._5.ClientLibrary.Dbc.Enums;

namespace TrinityCore._3._3._5.ClientLibrary.Dbc.Definitions;

[DbcFile("SpellVisualKitModelAttach.dbc")]
public class SpellVisualKitModelAttach : DbcFile
{
    [DbcColumn(0, DbcColumnDataType.Int32)]
    public int Id { get; set; }

    [DbcColumn(1, DbcColumnDataType.Int32)]
    public int ParentSpellVisualKitId { get; set; }

    [DbcColumn(2, DbcColumnDataType.Int32)]
    public int SpellVisualEffectNameId { get; set; }

    [DbcColumn(3, DbcColumnDataType.Int32)]
    public int AttachmentId { get; set; }

    [DbcColumn(4, DbcColumnDataType.ArrayOfFloat, 3)]
    public float[]? Offset { get; set; }

    [DbcColumn(5, DbcColumnDataType.Float)]
    public float Yaw { get; set; }

    [DbcColumn(6, DbcColumnDataType.Float)]
    public float Pitch { get; set; }

    [DbcColumn(7, DbcColumnDataType.Float)]
    public float Roll { get; set; }

    public SpellVisualKit? GetParentSpellVisualKitIdSpellVisualKit()
    {
        return DbcDirectory.Open<SpellVisualKit>()?.Where(c => c.Id == ParentSpellVisualKitId).FirstOrDefault();
    }

    public SpellVisualEffectName? GetSpellVisualEffectNameIdSpellVisualEffectName()
    {
        return DbcDirectory.Open<SpellVisualEffectName>()?.Where(c => c.Id == SpellVisualEffectNameId).FirstOrDefault();
    }
}