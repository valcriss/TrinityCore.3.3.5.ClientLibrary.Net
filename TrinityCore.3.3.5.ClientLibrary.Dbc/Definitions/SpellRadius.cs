using TrinityCore._3._3._5.ClientLibrary.Dbc.Attributes;
using TrinityCore._3._3._5.ClientLibrary.Dbc.Enums;

namespace TrinityCore._3._3._5.ClientLibrary.Dbc.Definitions;

[DbcFile("SpellRadius.dbc")]
public class SpellRadius : DbcFile
{
    [DbcColumn(0, DbcColumnDataType.Int32)]
    public int Id { get; set; }

    [DbcColumn(1, DbcColumnDataType.Float)]
    public float Radius { get; set; }

    [DbcColumn(2, DbcColumnDataType.Float)]
    public float RadiusPerLevel { get; set; }

    [DbcColumn(3, DbcColumnDataType.Float)]
    public float RadiusMax { get; set; }
}