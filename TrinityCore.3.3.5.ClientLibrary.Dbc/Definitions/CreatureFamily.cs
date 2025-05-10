using TrinityCore._3._3._5.ClientLibrary.Dbc.Attributes;

namespace TrinityCore._3._3._5.ClientLibrary.Dbc.Definitions
{
    [DbcFile("CreatureFamily.dbc")]
    public class CreatureFamily : DbcFile
    {
        [DbcColumn(0, Enums.DbcColumnDataType.Int32)]
        public int Id { get; set; }

        [DbcColumn(1, Enums.DbcColumnDataType.Float)]
        public float MinScale { get; set; }

        [DbcColumn(2, Enums.DbcColumnDataType.Int32)]
        public int MinScaleLevel { get; set; }

        [DbcColumn(3, Enums.DbcColumnDataType.Float)]
        public float MaxScale { get; set; }

        [DbcColumn(4, Enums.DbcColumnDataType.Int32)]
        public int MaxScaleLevel { get; set; }

        [DbcColumn(5, Enums.DbcColumnDataType.ArrayOfUint32, 2)]
        public int[]? SkillLine { get; set; }

        [DbcColumn(6, Enums.DbcColumnDataType.Int32)]
        public int PetFoodMask { get; set; }

        [DbcColumn(7, Enums.DbcColumnDataType.Int32)]
        public int PetTalentType { get; set; }

        [DbcColumn(8, Enums.DbcColumnDataType.Int32)]
        public int CategoryEnumId { get; set; }

        [DbcColumn(9, Enums.DbcColumnDataType.Loc)]
        public string? NameLang { get; set; }

        [DbcColumn(10, Enums.DbcColumnDataType.StringRef)]
        public string? IconFile { get; set; }

        public SkillLine[]? GetSkillLineSkillLines()
        {
               return DbcDirectory.Open<SkillLine>()?.Where(c => this.SkillLine != null && this.SkillLine.Contains(c.Id)).ToArray();
        }

     }
}
