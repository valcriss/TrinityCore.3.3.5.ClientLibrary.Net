using TrinityCore._3._3._5.ClientLibrary.Dbc.Attributes;

namespace TrinityCore._3._3._5.ClientLibrary.Dbc.Definitions
{
    [DbcFile("SkillLine.dbc")]
    public class SkillLine : DbcFile
    {
        [DbcColumn(0, Enums.DbcColumnDataType.Int32)]
        public int Id { get; set; }

        [DbcColumn(1, Enums.DbcColumnDataType.Int32)]
        public int CategoryId { get; set; }

        [DbcColumn(2, Enums.DbcColumnDataType.Int32)]
        public int SkillCostsId { get; set; }

        [DbcColumn(3, Enums.DbcColumnDataType.Loc)]
        public string? DisplayNameLang { get; set; }

        [DbcColumn(4, Enums.DbcColumnDataType.Loc)]
        public string? Description { get; set; }

        [DbcColumn(5, Enums.DbcColumnDataType.Int32)]
        public int SpellIconId { get; set; }

        [DbcColumn(6, Enums.DbcColumnDataType.Loc)]
        public string? AlternateVerb { get; set; }

        [DbcColumn(7, Enums.DbcColumnDataType.Int32)]
        public int CanLink { get; set; }

        public SkillLineCategory? GetCategoryIdSkillLineCategory()
        {
               return DbcDirectory.Open<SkillLineCategory>()?.Where(c => c.Id == this.CategoryId).FirstOrDefault();
        }

        public SpellIcon? GetSpellIconIdSpellIcon()
        {
               return DbcDirectory.Open<SpellIcon>()?.Where(c => c.Id == this.SpellIconId).FirstOrDefault();
        }

     }
}
