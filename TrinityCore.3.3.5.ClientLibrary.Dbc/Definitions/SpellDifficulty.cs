using TrinityCore._3._3._5.ClientLibrary.Dbc.Attributes;

namespace TrinityCore._3._3._5.ClientLibrary.Dbc.Definitions
{
    [DbcFile("SpellDifficulty.dbc")]
    public class SpellDifficulty : DbcFile
    {
        [DbcColumn(0, Enums.DbcColumnDataType.Int32)]
        public int Id { get; set; }

        [DbcColumn(1, Enums.DbcColumnDataType.ArrayOfUint32, 4)]
        public int[]? DifficultySpellId { get; set; }

        public Spell[]? GetDifficultySpellIdSpells()
        {
               return DbcDirectory.Open<Spell>()?.Where(c => this.DifficultySpellId != null && this.DifficultySpellId.Contains(c.Id)).ToArray();
        }

     }
}
