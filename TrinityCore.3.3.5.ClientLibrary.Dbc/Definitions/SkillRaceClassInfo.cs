using TrinityCore._3._3._5.ClientLibrary.Dbc.Attributes;

namespace TrinityCore._3._3._5.ClientLibrary.Dbc.Definitions
{
    [DbcFile("SkillRaceClassInfo.dbc")]
    public class SkillRaceClassInfo : DbcFile
    {
        [DbcColumn(0, Enums.DbcColumnDataType.Int32)]
        public int Id { get; set; }

        [DbcColumn(1, Enums.DbcColumnDataType.Int32)]
        public int SkillId { get; set; }

        [DbcColumn(2, Enums.DbcColumnDataType.Int32)]
        public int RaceMask { get; set; }

        [DbcColumn(3, Enums.DbcColumnDataType.Int32)]
        public int ClassMask { get; set; }

        [DbcColumn(4, Enums.DbcColumnDataType.Int32)]
        public int Flags { get; set; }

        [DbcColumn(5, Enums.DbcColumnDataType.Int32)]
        public int MinLevel { get; set; }

        [DbcColumn(6, Enums.DbcColumnDataType.Int32)]
        public int SkillTierId { get; set; }

        [DbcColumn(7, Enums.DbcColumnDataType.Int32)]
        public int SkillCostIndex { get; set; }

        public SkillLine? GetSkillIdSkillLine()
        {
               return DbcDirectory.Open<SkillLine>()?.Where(c => c.Id == this.SkillId).FirstOrDefault();
        }

        public SkillTiers? GetSkillTierIdSkillTiers()
        {
               return DbcDirectory.Open<SkillTiers>()?.Where(c => c.Id == this.SkillTierId).FirstOrDefault();
        }

     }
}
