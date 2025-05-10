using TrinityCore._3._3._5.ClientLibrary.Dbc.Attributes;
using TrinityCore._3._3._5.ClientLibrary.Dbc.Enums;

namespace TrinityCore._3._3._5.ClientLibrary.Dbc.Definitions;

[DbcFile("LockType.dbc")]
public class LockType : DbcFile
{
    [DbcColumn(0, DbcColumnDataType.Int32)]
    public int Id { get; set; }

    [DbcColumn(1, DbcColumnDataType.Loc)]
    public string? NameLang { get; set; }

    [DbcColumn(2, DbcColumnDataType.Loc)]
    public string? ResourceNameLang { get; set; }

    [DbcColumn(3, DbcColumnDataType.Loc)]
    public string? Verb { get; set; }

    [DbcColumn(4, DbcColumnDataType.StringRef)]
    public string? CursorName { get; set; }
}