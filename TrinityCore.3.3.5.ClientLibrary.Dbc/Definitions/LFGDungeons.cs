using TrinityCore._3._3._5.ClientLibrary.Dbc.Attributes;

namespace TrinityCore._3._3._5.ClientLibrary.Dbc.Definitions
{
    [DbcFile("LFGDungeons.dbc")]
    public class LFGDungeons : DbcFile
    {
        [DbcColumn(0, Enums.DbcColumnDataType.Int32)]
        public int Id { get; set; }

        [DbcColumn(1, Enums.DbcColumnDataType.Loc)]
        public string? NameLang { get; set; }

        [DbcColumn(2, Enums.DbcColumnDataType.Int32)]
        public int MinLevel { get; set; }

        [DbcColumn(3, Enums.DbcColumnDataType.Int32)]
        public int MaxLevel { get; set; }

        [DbcColumn(4, Enums.DbcColumnDataType.Int32)]
        public int TargetLevel { get; set; }

        [DbcColumn(5, Enums.DbcColumnDataType.Int32)]
        public int TargetLevelMin { get; set; }

        [DbcColumn(6, Enums.DbcColumnDataType.Int32)]
        public int TargetLevelMax { get; set; }

        [DbcColumn(7, Enums.DbcColumnDataType.Int32)]
        public int MapId { get; set; }

        [DbcColumn(8, Enums.DbcColumnDataType.Int32)]
        public int Difficulty { get; set; }

        [DbcColumn(9, Enums.DbcColumnDataType.Int32)]
        public int Flags { get; set; }

        [DbcColumn(10, Enums.DbcColumnDataType.Int32)]
        public int TypeId { get; set; }

        [DbcColumn(11, Enums.DbcColumnDataType.Int32)]
        public int Faction { get; set; }

        [DbcColumn(12, Enums.DbcColumnDataType.StringRef)]
        public string? TextureFilename { get; set; }

        [DbcColumn(13, Enums.DbcColumnDataType.Int32)]
        public int ExpansionLevel { get; set; }

        [DbcColumn(14, Enums.DbcColumnDataType.Int32)]
        public int OrderIndex { get; set; }

        [DbcColumn(15, Enums.DbcColumnDataType.Int32)]
        public int GroupId { get; set; }

        [DbcColumn(16, Enums.DbcColumnDataType.Loc)]
        public string? Description { get; set; }

        public Map? GetMapIdMap()
        {
               return DbcDirectory.Open<Map>()?.Where(c => c.Id == this.MapId).FirstOrDefault();
        }

        public Faction? GetFactionFaction()
        {
               return DbcDirectory.Open<Faction>()?.Where(c => c.Id == this.Faction).FirstOrDefault();
        }

     }
}
