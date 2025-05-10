using TrinityCore._3._3._5.ClientLibrary.Dbc.Attributes;

namespace TrinityCore._3._3._5.ClientLibrary.Dbc.Definitions
{
    [DbcFile("TalentTab.dbc")]
    public class TalentTab : DbcFile
    {
        [DbcColumn(0, Enums.DbcColumnDataType.Int32)]
        public int Id { get; set; }

        [DbcColumn(1, Enums.DbcColumnDataType.Loc)]
        public string? NameLang { get; set; }

        [DbcColumn(2, Enums.DbcColumnDataType.Int32)]
        public int SpellIconId { get; set; }

        [DbcColumn(3, Enums.DbcColumnDataType.Int32)]
        public int RaceMask { get; set; }

        [DbcColumn(4, Enums.DbcColumnDataType.Int32)]
        public int ClassMask { get; set; }

        [DbcColumn(5, Enums.DbcColumnDataType.Int32)]
        public int CategoryEnumId { get; set; }

        [DbcColumn(6, Enums.DbcColumnDataType.Int32)]
        public int OrderIndex { get; set; }

        [DbcColumn(7, Enums.DbcColumnDataType.StringRef)]
        public string? BackgroundFile { get; set; }

        public SpellIcon? GetSpellIconIdSpellIcon()
        {
               return DbcDirectory.Open<SpellIcon>()?.Where(c => c.Id == this.SpellIconId).FirstOrDefault();
        }

     }
}
