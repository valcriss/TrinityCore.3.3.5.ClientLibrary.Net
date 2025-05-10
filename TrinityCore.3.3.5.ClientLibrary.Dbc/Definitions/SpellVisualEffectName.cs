using TrinityCore._3._3._5.ClientLibrary.Dbc.Attributes;
using TrinityCore._3._3._5.ClientLibrary.Dbc.Enums;

namespace TrinityCore._3._3._5.ClientLibrary.Dbc.Definitions;

[DbcFile("SpellVisualEffectName.dbc")]
public class SpellVisualEffectName : DbcFile
{
    [DbcColumn(0, DbcColumnDataType.Int32)]
    public int Id { get; set; }

    [DbcColumn(1, DbcColumnDataType.StringRef)]
    public string? Name { get; set; }

    [DbcColumn(2, DbcColumnDataType.StringRef)]
    public string? FileName { get; set; }

    [DbcColumn(3, DbcColumnDataType.Float)]
    public float AreaEffectSize { get; set; }

    [DbcColumn(4, DbcColumnDataType.Float)]
    public float Scale { get; set; }

    [DbcColumn(5, DbcColumnDataType.Float)]
    public float MinAllowedScale { get; set; }

    [DbcColumn(6, DbcColumnDataType.Float)]
    public float MaxAllowedScale { get; set; }
}