using TrinityCore._3._3._5.ClientLibrary.Dbc.Attributes;
using TrinityCore._3._3._5.ClientLibrary.Dbc.Enums;

namespace TrinityCore._3._3._5.ClientLibrary.Dbc.Definitions;

[DbcFile("OverrideSpellData.dbc")]
public class OverrideSpellData : DbcFile
{
    [DbcColumn(0, DbcColumnDataType.Int32)]
    public int Id { get; set; }

    [DbcColumn(1, DbcColumnDataType.ArrayOfUint32, 10)]
    public int[]? Spells { get; set; }

    [DbcColumn(2, DbcColumnDataType.Int32)]
    public int Flags { get; set; }

    public Spell[]? GetSpellsSpells()
    {
        return DbcDirectory.Open<Spell>()?.Where(c => Spells != null && Spells.Contains(c.Id)).ToArray();
    }
}