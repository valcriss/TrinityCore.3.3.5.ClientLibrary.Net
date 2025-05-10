using TrinityCore._3._3._5.ClientLibrary.Dbc.Attributes;
using TrinityCore._3._3._5.ClientLibrary.Dbc.Enums;

namespace TrinityCore._3._3._5.ClientLibrary.Dbc.Definitions;

[DbcFile("GlyphProperties.dbc")]
public class GlyphProperties : DbcFile
{
    [DbcColumn(0, DbcColumnDataType.Int32)]
    public int Id { get; set; }

    [DbcColumn(1, DbcColumnDataType.Int32)]
    public int SpellId { get; set; }

    [DbcColumn(2, DbcColumnDataType.Int32)]
    public int GlyphSlotFlags { get; set; }

    [DbcColumn(3, DbcColumnDataType.Int32)]
    public int SpellIconId { get; set; }

    public Spell? GetSpellIdSpell()
    {
        return DbcDirectory.Open<Spell>()?.Where(c => c.Id == SpellId).FirstOrDefault();
    }

    public SpellIcon? GetSpellIconIdSpellIcon()
    {
        return DbcDirectory.Open<SpellIcon>()?.Where(c => c.Id == SpellIconId).FirstOrDefault();
    }
}