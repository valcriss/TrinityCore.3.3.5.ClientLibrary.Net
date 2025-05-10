using TrinityCore._3._3._5.ClientLibrary.Dbc.Attributes;

namespace TrinityCore._3._3._5.ClientLibrary.Dbc.Definitions
{
    [DbcFile("Talent.dbc")]
    public class Talent : DbcFile
    {
        [DbcColumn(0, Enums.DbcColumnDataType.Int32)]
        public int Id { get; set; }

        [DbcColumn(1, Enums.DbcColumnDataType.Int32)]
        public int TabId { get; set; }

        [DbcColumn(2, Enums.DbcColumnDataType.Int32)]
        public int TierId { get; set; }

        [DbcColumn(3, Enums.DbcColumnDataType.Int32)]
        public int ColumnIndex { get; set; }

        [DbcColumn(4, Enums.DbcColumnDataType.ArrayOfUint32, 9)]
        public int[]? SpellRank { get; set; }

        [DbcColumn(5, Enums.DbcColumnDataType.ArrayOfUint32, 3)]
        public int[]? PrereqTalent { get; set; }

        [DbcColumn(6, Enums.DbcColumnDataType.ArrayOfUint32, 3)]
        public int[]? PrereqRank { get; set; }

        [DbcColumn(7, Enums.DbcColumnDataType.Int32)]
        public int Flags { get; set; }

        [DbcColumn(8, Enums.DbcColumnDataType.Int32)]
        public int RequiredSpellId { get; set; }

        [DbcColumn(9, Enums.DbcColumnDataType.ArrayOfUint32, 2)]
        public int[]? CategoryMask { get; set; }

        public Talent[]? GetPrereqTalentTalents()
        {
               return DbcDirectory.Open<Talent>()?.Where(c => this.PrereqTalent != null && this.PrereqTalent.Contains(c.Id)).ToArray();
        }

        public Spell? GetRequiredSpellIdSpell()
        {
               return DbcDirectory.Open<Spell>()?.Where(c => c.Id == this.RequiredSpellId).FirstOrDefault();
        }

     }
}
