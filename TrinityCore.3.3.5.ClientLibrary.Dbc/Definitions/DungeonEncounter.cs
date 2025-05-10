using TrinityCore._3._3._5.ClientLibrary.Dbc.Attributes;

namespace TrinityCore._3._3._5.ClientLibrary.Dbc.Definitions
{
    [DbcFile("DungeonEncounter.dbc")]
    public class DungeonEncounter : DbcFile
    {
        [DbcColumn(0, Enums.DbcColumnDataType.Int32)]
        public int Id { get; set; }

        [DbcColumn(1, Enums.DbcColumnDataType.Int32)]
        public int MapId { get; set; }

        [DbcColumn(2, Enums.DbcColumnDataType.Int32)]
        public int Difficulty { get; set; }

        [DbcColumn(3, Enums.DbcColumnDataType.Int32)]
        public int OrderIndex { get; set; }

        [DbcColumn(4, Enums.DbcColumnDataType.Int32)]
        public int Bit { get; set; }

        [DbcColumn(5, Enums.DbcColumnDataType.Loc)]
        public string? NameLang { get; set; }

        [DbcColumn(6, Enums.DbcColumnDataType.Int32)]
        public int SpellIconId { get; set; }

        public Map? GetMapIdMap()
        {
               return DbcDirectory.Open<Map>()?.Where(c => c.Id == this.MapId).FirstOrDefault();
        }

        public SpellIcon? GetSpellIconIdSpellIcon()
        {
               return DbcDirectory.Open<SpellIcon>()?.Where(c => c.Id == this.SpellIconId).FirstOrDefault();
        }

     }
}
