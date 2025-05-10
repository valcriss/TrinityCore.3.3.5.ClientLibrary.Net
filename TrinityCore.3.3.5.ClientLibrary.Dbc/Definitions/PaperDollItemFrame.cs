using TrinityCore._3._3._5.ClientLibrary.Dbc.Attributes;
using TrinityCore._3._3._5.ClientLibrary.Dbc.Enums;

namespace TrinityCore._3._3._5.ClientLibrary.Dbc.Definitions;

[DbcFile("PaperDollItemFrame.dbc")]
public class PaperDollItemFrame : DbcFile
{
    [DbcColumn(0, DbcColumnDataType.StringRef)]
    public string? ItemButtonName { get; set; }

    [DbcColumn(1, DbcColumnDataType.StringRef)]
    public string? SlotIcon { get; set; }

    [DbcColumn(2, DbcColumnDataType.Int32)]
    public int SlotNumber { get; set; }
}