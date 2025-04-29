using TrinityCore._3._3._5.ClientLibrary.Dbc.Enums;
using TrinityCore._3._3._5.ClientLibrary.Dbc.Models;

namespace TrinityCore._3._3._5.ClientLibrary.Dbc;

public class DbcCollection
{
    public DbcCollection(string dbcDirectory)
    {
        Spells = new SpellDbc(Path.Combine(dbcDirectory, "Spell.dbc"), LocaleConstant.LOCALE_FR_FR);
    }

    public SpellDbc Spells { get; set; }
}