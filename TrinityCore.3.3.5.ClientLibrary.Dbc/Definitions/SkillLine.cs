using TrinityCore._3._3._5.ClientLibrary.Dbc.Attributes;
using TrinityCore._3._3._5.ClientLibrary.Dbc.Enums;

namespace TrinityCore._3._3._5.ClientLibrary.Dbc.Definitions;

[DbcFile("SkillLine.dbc")]
public class SkillLine : DbcFile
{
    [DbcColumn(0, DbcColumnDataType.Int32)]
    public int Id { get; set; }

    [DbcColumn(1, DbcColumnDataType.Int32)]
    public int CategoryId { get; set; }

    [DbcColumn(2, DbcColumnDataType.Int32)]
    public int SkillCostsId { get; set; }

    [DbcColumn(3, DbcColumnDataType.Loc)]
    public string? DisplayNameLang { get; set; }

    [DbcColumn(4, DbcColumnDataType.Loc)]
    public string? Description { get; set; }

    [DbcColumn(5, DbcColumnDataType.Int32)]
    public int SpellIconId { get; set; }

    [DbcColumn(6, DbcColumnDataType.Loc)]
    public string? AlternateVerb { get; set; }

    [DbcColumn(7, DbcColumnDataType.Int32)]
    public int CanLink { get; set; }

    public SkillLineCategory? GetCategoryIdSkillLineCategory()
    {
        return DbcDirectory.Open<SkillLineCategory>()?.Where(c => c.Id == CategoryId).FirstOrDefault();
    }

    public SpellIcon? GetSpellIconIdSpellIcon()
    {
        return DbcDirectory.Open<SpellIcon>()?.Where(c => c.Id == SpellIconId).FirstOrDefault();
    }
}