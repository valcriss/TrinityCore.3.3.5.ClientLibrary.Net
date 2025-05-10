using TrinityCore._3._3._5.ClientLibrary.Dbc.Attributes;
using TrinityCore._3._3._5.ClientLibrary.Dbc.Enums;

namespace TrinityCore._3._3._5.ClientLibrary.Dbc.Definitions;

[DbcFile("ItemSet.dbc")]
public class ItemSet : DbcFile
{
    [DbcColumn(0, DbcColumnDataType.Int32)]
    public int Id { get; set; }

    [DbcColumn(1, DbcColumnDataType.Loc)]
    public string? NameLang { get; set; }

    [DbcColumn(2, DbcColumnDataType.ArrayOfUint32, 17)]
    public int[]? ItemId { get; set; }

    [DbcColumn(3, DbcColumnDataType.ArrayOfUint32, 8)]
    public int[]? SetSpellId { get; set; }

    [DbcColumn(4, DbcColumnDataType.ArrayOfUint32, 8)]
    public int[]? SetThreshold { get; set; }

    [DbcColumn(5, DbcColumnDataType.Int32)]
    public int RequiredSkill { get; set; }

    [DbcColumn(6, DbcColumnDataType.Int32)]
    public int RequiredSkillRank { get; set; }

    public Item[]? GetItemIdItems()
    {
        return DbcDirectory.Open<Item>()?.Where(c => ItemId != null && ItemId.Contains(c.Id)).ToArray();
    }

    public Spell[]? GetSetSpellIdSpells()
    {
        return DbcDirectory.Open<Spell>()?.Where(c => SetSpellId != null && SetSpellId.Contains(c.Id)).ToArray();
    }

    public SkillLine? GetRequiredSkillSkillLine()
    {
        return DbcDirectory.Open<SkillLine>()?.Where(c => c.Id == RequiredSkill).FirstOrDefault();
    }
}