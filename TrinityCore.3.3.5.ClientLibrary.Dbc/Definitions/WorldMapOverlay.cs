using TrinityCore._3._3._5.ClientLibrary.Dbc.Attributes;

namespace TrinityCore._3._3._5.ClientLibrary.Dbc.Definitions
{
    [DbcFile("WorldMapOverlay.dbc")]
    public class WorldMapOverlay : DbcFile
    {
        [DbcColumn(0, Enums.DbcColumnDataType.Int32)]
        public int Id { get; set; }

        [DbcColumn(1, Enums.DbcColumnDataType.Int32)]
        public int MapAreaId { get; set; }

        [DbcColumn(2, Enums.DbcColumnDataType.ArrayOfUint32, 4)]
        public int[]? AreaId { get; set; }

        [DbcColumn(3, Enums.DbcColumnDataType.Int32)]
        public int MapPointX { get; set; }

        [DbcColumn(4, Enums.DbcColumnDataType.Int32)]
        public int MapPointY { get; set; }

        [DbcColumn(5, Enums.DbcColumnDataType.StringRef)]
        public string? TextureName { get; set; }

        [DbcColumn(6, Enums.DbcColumnDataType.Int32)]
        public int TextureWidth { get; set; }

        [DbcColumn(7, Enums.DbcColumnDataType.Int32)]
        public int TextureHeight { get; set; }

        [DbcColumn(8, Enums.DbcColumnDataType.Int32)]
        public int OffsetX { get; set; }

        [DbcColumn(9, Enums.DbcColumnDataType.Int32)]
        public int OffsetY { get; set; }

        [DbcColumn(10, Enums.DbcColumnDataType.Int32)]
        public int HitRectTop { get; set; }

        [DbcColumn(11, Enums.DbcColumnDataType.Int32)]
        public int HitRectLeft { get; set; }

        [DbcColumn(12, Enums.DbcColumnDataType.Int32)]
        public int HitRectBottom { get; set; }

        [DbcColumn(13, Enums.DbcColumnDataType.Int32)]
        public int HitRectRight { get; set; }

        public WorldMapArea? GetMapAreaIdWorldMapArea()
        {
               return DbcDirectory.Open<WorldMapArea>()?.Where(c => c.Id == this.MapAreaId).FirstOrDefault();
        }

        public AreaTable[]? GetAreaIdAreaTables()
        {
               return DbcDirectory.Open<AreaTable>()?.Where(c => this.AreaId != null && this.AreaId.Contains(c.Id)).ToArray();
        }

     }
}
