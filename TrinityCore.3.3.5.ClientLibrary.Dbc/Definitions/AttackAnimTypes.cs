using TrinityCore._3._3._5.ClientLibrary.Dbc.Attributes;
using TrinityCore._3._3._5.ClientLibrary.Dbc.Enums;

namespace TrinityCore._3._3._5.ClientLibrary.Dbc.Definitions;

[DbcFile("AttackAnimTypes.dbc")]
public class AttackAnimTypes : DbcFile
{
    [DbcColumn(0, DbcColumnDataType.Int32)]
    public int AnimId { get; set; }

    [DbcColumn(1, DbcColumnDataType.StringRef)]
    public string? AnimName { get; set; }
}