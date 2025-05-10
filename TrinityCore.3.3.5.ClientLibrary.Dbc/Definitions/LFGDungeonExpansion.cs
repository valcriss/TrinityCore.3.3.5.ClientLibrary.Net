using TrinityCore._3._3._5.ClientLibrary.Dbc.Attributes;
using TrinityCore._3._3._5.ClientLibrary.Dbc.Enums;

namespace TrinityCore._3._3._5.ClientLibrary.Dbc.Definitions;

[DbcFile("LFGDungeonExpansion.dbc")]
public class LFGDungeonExpansion : DbcFile
{
    [DbcColumn(0, DbcColumnDataType.Int32)]
    public int Id { get; set; }

    [DbcColumn(1, DbcColumnDataType.Int32)]
    public int LfgId { get; set; }

    [DbcColumn(2, DbcColumnDataType.Int32)]
    public int ExpansionLevel { get; set; }

    [DbcColumn(3, DbcColumnDataType.Int32)]
    public int RandomId { get; set; }

    [DbcColumn(4, DbcColumnDataType.Int32)]
    public int HardLevelMin { get; set; }

    [DbcColumn(5, DbcColumnDataType.Int32)]
    public int HardLevelMax { get; set; }

    [DbcColumn(6, DbcColumnDataType.Int32)]
    public int TargetLevelMin { get; set; }

    [DbcColumn(7, DbcColumnDataType.Int32)]
    public int TargetLevelMax { get; set; }
}