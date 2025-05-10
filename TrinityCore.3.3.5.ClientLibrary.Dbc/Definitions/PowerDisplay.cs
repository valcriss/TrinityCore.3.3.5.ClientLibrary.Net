using TrinityCore._3._3._5.ClientLibrary.Dbc.Attributes;
using TrinityCore._3._3._5.ClientLibrary.Dbc.Enums;

namespace TrinityCore._3._3._5.ClientLibrary.Dbc.Definitions;

[DbcFile("PowerDisplay.dbc")]
public class PowerDisplay : DbcFile
{
    [DbcColumn(0, DbcColumnDataType.Int32)]
    public int Id { get; set; }

    [DbcColumn(1, DbcColumnDataType.Int32)]
    public int ActualType { get; set; }

    [DbcColumn(2, DbcColumnDataType.StringRef)]
    public string? GlobalStringBaseTag { get; set; }

    [DbcColumn(3, DbcColumnDataType.Byte)]
    public byte Red { get; set; }

    [DbcColumn(4, DbcColumnDataType.Byte)]
    public byte Green { get; set; }

    [DbcColumn(5, DbcColumnDataType.Byte)]
    public byte Blue { get; set; }
}