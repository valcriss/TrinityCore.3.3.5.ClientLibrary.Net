using TrinityCore._3._3._5.ClientLibrary.Dbc.Attributes;
using TrinityCore._3._3._5.ClientLibrary.Dbc.Enums;

namespace TrinityCore._3._3._5.ClientLibrary.Dbc.Definitions;

[DbcFile("Resistances.dbc")]
public class Resistances : DbcFile
{
    [DbcColumn(0, DbcColumnDataType.Int32)]
    public int Id { get; set; }

    [DbcColumn(1, DbcColumnDataType.Int32)]
    public int Flags { get; set; }

    [DbcColumn(2, DbcColumnDataType.Int32)]
    public int FizzleSoundId { get; set; }

    [DbcColumn(3, DbcColumnDataType.Loc)]
    public string? NameLang { get; set; }
}