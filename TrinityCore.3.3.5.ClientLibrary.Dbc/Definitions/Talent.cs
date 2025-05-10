using TrinityCore._3._3._5.ClientLibrary.Dbc.Attributes;
using TrinityCore._3._3._5.ClientLibrary.Dbc.Enums;

namespace TrinityCore._3._3._5.ClientLibrary.Dbc.Definitions;

[DbcFile("Talent.dbc")]
public class Talent : DbcFile
{
    [DbcColumn(0, DbcColumnDataType.Int32)]
    public int Id { get; set; }

    [DbcColumn(1, DbcColumnDataType.Int32)]
    public int TabId { get; set; }

    [DbcColumn(2, DbcColumnDataType.Int32)]
    public int TierId { get; set; }

    [DbcColumn(3, DbcColumnDataType.Int32)]
    public int ColumnIndex { get; set; }

    [DbcColumn(4, DbcColumnDataType.ArrayOfUint32, 9)]
    public int[]? SpellRank { get; set; }

    [DbcColumn(5, DbcColumnDataType.ArrayOfUint32, 3)]
    public int[]? PrereqTalent { get; set; }

    [DbcColumn(6, DbcColumnDataType.ArrayOfUint32, 3)]
    public int[]? PrereqRank { get; set; }

    [DbcColumn(7, DbcColumnDataType.Int32)]
    public int Flags { get; set; }

    [DbcColumn(8, DbcColumnDataType.Int32)]
    public int RequiredSpellId { get; set; }

    [DbcColumn(9, DbcColumnDataType.ArrayOfUint32, 2)]
    public int[]? CategoryMask { get; set; }

    public Talent[]? GetPrereqTalentTalents()
    {
        return DbcDirectory.Open<Talent>()?.Where(c => PrereqTalent != null && PrereqTalent.Contains(c.Id)).ToArray();
    }

    public Spell? GetRequiredSpellIdSpell()
    {
        return DbcDirectory.Open<Spell>()?.Where(c => c.Id == RequiredSpellId).FirstOrDefault();
    }
}