using TrinityCore._3._3._5.ClientLibrary.Dbc.Attributes;

namespace TrinityCore._3._3._5.ClientLibrary.Dbc.Definitions
{
    [DbcFile("OverrideSpellData.dbc")]
    public class OverrideSpellData : DbcFile
    {
        [DbcColumn(0, Enums.DbcColumnDataType.Int32)]
        public int Id { get; set; }

        [DbcColumn(1, Enums.DbcColumnDataType.ArrayOfUint32, 10)]
        public int[]? Spells { get; set; }

        [DbcColumn(2, Enums.DbcColumnDataType.Int32)]
        public int Flags { get; set; }

        public Spell[]? GetSpellsSpells()
        {
               return DbcDirectory.Open<Spell>()?.Where(c => this.Spells != null && this.Spells.Contains(c.Id)).ToArray();
        }

     }
}
