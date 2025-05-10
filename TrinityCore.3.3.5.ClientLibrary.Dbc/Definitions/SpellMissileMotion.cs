using TrinityCore._3._3._5.ClientLibrary.Dbc.Attributes;
using TrinityCore._3._3._5.ClientLibrary.Dbc.Enums;

namespace TrinityCore._3._3._5.ClientLibrary.Dbc.Definitions;

[DbcFile("SpellMissileMotion.dbc")]
public class SpellMissileMotion : DbcFile
{
    [DbcColumn(0, DbcColumnDataType.Int32)]
    public int Id { get; set; }

    [DbcColumn(1, DbcColumnDataType.StringRef)]
    public string? Name { get; set; }

    [DbcColumn(2, DbcColumnDataType.StringRef)]
    public string? ScriptBody { get; set; }

    [DbcColumn(3, DbcColumnDataType.Int32)]
    public int Flags { get; set; }

    [DbcColumn(4, DbcColumnDataType.Int32)]
    public int MissileCount { get; set; }
}