using TrinityCore._3._3._5.ClientLibrary.Dbc.Attributes;

namespace TrinityCore._3._3._5.ClientLibrary.Dbc.Definitions
{
    [DbcFile("Map.dbc")]
    public class Map : DbcFile
    {
        [DbcColumn(0, Enums.DbcColumnDataType.Int32)]
        public int Id { get; set; }

        [DbcColumn(1, Enums.DbcColumnDataType.StringRef)]
        public string? Directory { get; set; }

        [DbcColumn(2, Enums.DbcColumnDataType.Int32)]
        public int InstanceType { get; set; }

        [DbcColumn(3, Enums.DbcColumnDataType.Int32)]
        public int Flags { get; set; }

        [DbcColumn(4, Enums.DbcColumnDataType.Int32)]
        public int PVP { get; set; }

        [DbcColumn(5, Enums.DbcColumnDataType.Loc)]
        public string? MapNameLang { get; set; }

        [DbcColumn(6, Enums.DbcColumnDataType.Int32)]
        public int AreaTableId { get; set; }

        [DbcColumn(7, Enums.DbcColumnDataType.Loc)]
        public string? MapDescription0 { get; set; }

        [DbcColumn(8, Enums.DbcColumnDataType.Loc)]
        public string? MapDescription1 { get; set; }

        [DbcColumn(9, Enums.DbcColumnDataType.Int32)]
        public int LoadingScreenId { get; set; }

        [DbcColumn(10, Enums.DbcColumnDataType.Float)]
        public float MinimapIconScale { get; set; }

        [DbcColumn(11, Enums.DbcColumnDataType.Int32)]
        public int CorpseMapId { get; set; }

        [DbcColumn(12, Enums.DbcColumnDataType.ArrayOfFloat, 2)]
        public float[]? Corpse { get; set; }

        [DbcColumn(13, Enums.DbcColumnDataType.Int32)]
        public int TimeOfDayOverride { get; set; }

        [DbcColumn(14, Enums.DbcColumnDataType.Int32)]
        public int ExpansionId { get; set; }

        [DbcColumn(15, Enums.DbcColumnDataType.Int32)]
        public int RaidOffset { get; set; }

        [DbcColumn(16, Enums.DbcColumnDataType.Int32)]
        public int MaxPlayers { get; set; }

        public AreaTable? GetAreaTableIdAreaTable()
        {
               return DbcDirectory.Open<AreaTable>()?.Where(c => c.Id == this.AreaTableId).FirstOrDefault();
        }

        public LoadingScreens? GetLoadingScreenIdLoadingScreens()
        {
               return DbcDirectory.Open<LoadingScreens>()?.Where(c => c.Id == this.LoadingScreenId).FirstOrDefault();
        }

        public Map? GetCorpseMapIdMap()
        {
               return DbcDirectory.Open<Map>()?.Where(c => c.Id == this.CorpseMapId).FirstOrDefault();
        }

     }
}
