using TrinityCore._3._3._5.ClientLibrary.Dbc.Attributes;
using TrinityCore._3._3._5.ClientLibrary.Dbc.Enums;

namespace TrinityCore._3._3._5.ClientLibrary.Dbc.Definitions;

[DbcFile("SpellVisualPrecastTransitions.dbc")]
public class SpellVisualPrecastTransitions : DbcFile
{
    [DbcColumn(0, DbcColumnDataType.Int32)]
    public int Id { get; set; }

    [DbcColumn(1, DbcColumnDataType.StringRef)]
    public string? PrecastLoadAnimName { get; set; }

    [DbcColumn(2, DbcColumnDataType.StringRef)]
    public string? PrecastHoldAnimName { get; set; }
}