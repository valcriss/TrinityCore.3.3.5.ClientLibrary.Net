using TrinityCore._3._3._5.ClientLibrary.Dbc.Attributes;

namespace TrinityCore._3._3._5.ClientLibrary.Dbc.Definitions
{
    [DbcFile("WorldMapContinent.dbc")]
    public class WorldMapContinent : DbcFile
    {
        [DbcColumn(0, Enums.DbcColumnDataType.Int32)]
        public int Id { get; set; }

        [DbcColumn(1, Enums.DbcColumnDataType.Int32)]
        public int MapId { get; set; }

        [DbcColumn(2, Enums.DbcColumnDataType.Int32)]
        public int LeftBoundary { get; set; }

        [DbcColumn(3, Enums.DbcColumnDataType.Int32)]
        public int RightBoundary { get; set; }

        [DbcColumn(4, Enums.DbcColumnDataType.Int32)]
        public int TopBoundary { get; set; }

        [DbcColumn(5, Enums.DbcColumnDataType.Int32)]
        public int BottomBoundary { get; set; }

        [DbcColumn(6, Enums.DbcColumnDataType.ArrayOfFloat, 2)]
        public float[]? ContinentOffset { get; set; }

        [DbcColumn(7, Enums.DbcColumnDataType.Float)]
        public float Scale { get; set; }

        [DbcColumn(8, Enums.DbcColumnDataType.ArrayOfFloat, 2)]
        public float[]? TaxiMin { get; set; }

        [DbcColumn(9, Enums.DbcColumnDataType.ArrayOfFloat, 2)]
        public float[]? TaxiMax { get; set; }

        [DbcColumn(10, Enums.DbcColumnDataType.Int32)]
        public int WorldMapId { get; set; }

        public Map? GetMapIdMap()
        {
               return DbcDirectory.Open<Map>()?.Where(c => c.Id == this.MapId).FirstOrDefault();
        }

        public WorldMapArea? GetWorldMapIdWorldMapArea()
        {
               return DbcDirectory.Open<WorldMapArea>()?.Where(c => c.Id == this.WorldMapId).FirstOrDefault();
        }

     }
}
