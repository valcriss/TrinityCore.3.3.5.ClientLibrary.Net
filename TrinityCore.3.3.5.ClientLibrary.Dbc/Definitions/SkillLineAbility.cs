using TrinityCore._3._3._5.ClientLibrary.Dbc.Attributes;

namespace TrinityCore._3._3._5.ClientLibrary.Dbc.Definitions
{
    [DbcFile("SkillLineAbility.dbc")]
    public class SkillLineAbility : DbcFile
    {
        [DbcColumn(0, Enums.DbcColumnDataType.Int32)]
        public int Id { get; set; }

        [DbcColumn(1, Enums.DbcColumnDataType.Int32)]
        public int SkillLine { get; set; }

        [DbcColumn(2, Enums.DbcColumnDataType.Int32)]
        public int Spell { get; set; }

        [DbcColumn(3, Enums.DbcColumnDataType.Int32)]
        public int RaceMask { get; set; }

        [DbcColumn(4, Enums.DbcColumnDataType.Int32)]
        public int ClassMask { get; set; }

        [DbcColumn(5, Enums.DbcColumnDataType.Int32)]
        public int ExcludeRace { get; set; }

        [DbcColumn(6, Enums.DbcColumnDataType.Int32)]
        public int ExcludeClass { get; set; }

        [DbcColumn(7, Enums.DbcColumnDataType.Int32)]
        public int MinSkillLineRank { get; set; }

        [DbcColumn(8, Enums.DbcColumnDataType.Int32)]
        public int SupercededBySpell { get; set; }

        [DbcColumn(9, Enums.DbcColumnDataType.Int32)]
        public int AcquireMethod { get; set; }

        [DbcColumn(10, Enums.DbcColumnDataType.Int32)]
        public int TrivialSkillLineRankHigh { get; set; }

        [DbcColumn(11, Enums.DbcColumnDataType.Int32)]
        public int TrivialSkillLineRankLow { get; set; }

        [DbcColumn(12, Enums.DbcColumnDataType.ArrayOfUint32, 2)]
        public int[]? CharacterPoints { get; set; }

        public SkillLine? GetSkillLineSkillLine()
        {
               return DbcDirectory.Open<SkillLine>()?.Where(c => c.Id == this.SkillLine).FirstOrDefault();
        }

        public Spell? GetSpellSpell()
        {
               return DbcDirectory.Open<Spell>()?.Where(c => c.Id == this.Spell).FirstOrDefault();
        }

        public Spell? GetSupercededBySpellSpell()
        {
               return DbcDirectory.Open<Spell>()?.Where(c => c.Id == this.SupercededBySpell).FirstOrDefault();
        }

     }
}
