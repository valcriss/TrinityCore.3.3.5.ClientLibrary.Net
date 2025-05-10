using TrinityCore._3._3._5.ClientLibrary.Dbc.Attributes;
using TrinityCore._3._3._5.ClientLibrary.Dbc.Enums;

namespace TrinityCore._3._3._5.ClientLibrary.Dbc.Definitions;

[DbcFile("SpellDispelType.dbc")]
public class SpellDispelType : DbcFile
{
    [DbcColumn(0, DbcColumnDataType.Int32)]
    public int Id { get; set; }

    [DbcColumn(1, DbcColumnDataType.Loc)]
    public string? NameLang { get; set; }

    [DbcColumn(2, DbcColumnDataType.Int32)]
    public int Mask { get; set; }

    [DbcColumn(3, DbcColumnDataType.Int32)]
    public int ImmunityPossible { get; set; }

    [DbcColumn(4, DbcColumnDataType.StringRef)]
    public string? InternalName { get; set; }
}