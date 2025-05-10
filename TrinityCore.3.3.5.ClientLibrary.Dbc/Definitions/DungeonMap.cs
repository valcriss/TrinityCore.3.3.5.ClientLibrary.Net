using TrinityCore._3._3._5.ClientLibrary.Dbc.Attributes;

namespace TrinityCore._3._3._5.ClientLibrary.Dbc.Definitions
{
    [DbcFile("DungeonMap.dbc")]
    public class DungeonMap : DbcFile
    {
        [DbcColumn(0, Enums.DbcColumnDataType.Int32)]
        public int Id { get; set; }

        [DbcColumn(1, Enums.DbcColumnDataType.Int32)]
        public int MapId { get; set; }

        [DbcColumn(2, Enums.DbcColumnDataType.Int32)]
        public int FloorIndex { get; set; }

        [DbcColumn(3, Enums.DbcColumnDataType.Float)]
        public float MinX { get; set; }

        [DbcColumn(4, Enums.DbcColumnDataType.Float)]
        public float MaxX { get; set; }

        [DbcColumn(5, Enums.DbcColumnDataType.Float)]
        public float MinY { get; set; }

        [DbcColumn(6, Enums.DbcColumnDataType.Float)]
        public float MaxY { get; set; }

        [DbcColumn(7, Enums.DbcColumnDataType.Int32)]
        public int ParentWorldMapId { get; set; }

        public Map? GetMapIdMap()
        {
               return DbcDirectory.Open<Map>()?.Where(c => c.Id == this.MapId).FirstOrDefault();
        }

        public AreaTable? GetParentWorldMapIdAreaTable()
        {
               return DbcDirectory.Open<AreaTable>()?.Where(c => c.Id == this.ParentWorldMapId).FirstOrDefault();
        }

     }
}
