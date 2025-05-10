using TrinityCore._3._3._5.ClientLibrary.Dbc.Attributes;
using TrinityCore._3._3._5.ClientLibrary.Dbc.Enums;

namespace TrinityCore._3._3._5.ClientLibrary.Dbc.Definitions;

[DbcFile("SpellRange.dbc")]
public class SpellRange : DbcFile
{
    [DbcColumn(0, DbcColumnDataType.Int32)]
    public int Id { get; set; }

    [DbcColumn(1, DbcColumnDataType.ArrayOfFloat, 2)]
    public float[]? RangeMin { get; set; }

    [DbcColumn(2, DbcColumnDataType.ArrayOfFloat, 2)]
    public float[]? RangeMax { get; set; }

    [DbcColumn(3, DbcColumnDataType.Int32)]
    public int Flags { get; set; }

    [DbcColumn(4, DbcColumnDataType.Loc)]
    public string? DisplayNameLang { get; set; }

    [DbcColumn(5, DbcColumnDataType.Loc)]
    public string? DisplayNameShort { get; set; }
}