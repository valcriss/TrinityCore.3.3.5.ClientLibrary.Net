using TrinityCore._3._3._5.ClientLibrary.Dbc.Attributes;
using TrinityCore._3._3._5.ClientLibrary.Dbc.Enums;

namespace TrinityCore._3._3._5.ClientLibrary.Dbc.Definitions;

[DbcFile("TalentTab.dbc")]
public class TalentTab : DbcFile
{
    [DbcColumn(0, DbcColumnDataType.Int32)]
    public int Id { get; set; }

    [DbcColumn(1, DbcColumnDataType.Loc)]
    public string? NameLang { get; set; }

    [DbcColumn(2, DbcColumnDataType.Int32)]
    public int SpellIconId { get; set; }

    [DbcColumn(3, DbcColumnDataType.Int32)]
    public int RaceMask { get; set; }

    [DbcColumn(4, DbcColumnDataType.Int32)]
    public int ClassMask { get; set; }

    [DbcColumn(5, DbcColumnDataType.Int32)]
    public int CategoryEnumId { get; set; }

    [DbcColumn(6, DbcColumnDataType.Int32)]
    public int OrderIndex { get; set; }

    [DbcColumn(7, DbcColumnDataType.StringRef)]
    public string? BackgroundFile { get; set; }

    public SpellIcon? GetSpellIconIdSpellIcon()
    {
        return DbcDirectory.Open<SpellIcon>()?.Where(c => c.Id == SpellIconId).FirstOrDefault();
    }
}