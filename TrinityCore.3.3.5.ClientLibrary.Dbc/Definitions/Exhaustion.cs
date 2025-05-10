using TrinityCore._3._3._5.ClientLibrary.Dbc.Attributes;
using TrinityCore._3._3._5.ClientLibrary.Dbc.Enums;

namespace TrinityCore._3._3._5.ClientLibrary.Dbc.Definitions;

[DbcFile("Exhaustion.dbc")]
public class Exhaustion : DbcFile
{
    [DbcColumn(0, DbcColumnDataType.Int32)]
    public int Id { get; set; }

    [DbcColumn(1, DbcColumnDataType.Int32)]
    public int Xp { get; set; }

    [DbcColumn(2, DbcColumnDataType.Float)]
    public float Factor { get; set; }

    [DbcColumn(3, DbcColumnDataType.Float)]
    public float OutdoorHours { get; set; }

    [DbcColumn(4, DbcColumnDataType.Float)]
    public float InnHours { get; set; }

    [DbcColumn(5, DbcColumnDataType.Loc)]
    public string? NameLang { get; set; }

    [DbcColumn(6, DbcColumnDataType.Float)]
    public float Threshold { get; set; }
}