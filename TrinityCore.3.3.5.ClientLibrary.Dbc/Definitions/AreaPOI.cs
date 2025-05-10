using TrinityCore._3._3._5.ClientLibrary.Dbc.Attributes;

namespace TrinityCore._3._3._5.ClientLibrary.Dbc.Definitions
{
    [DbcFile("AreaPOI.dbc")]
    public class AreaPOI : DbcFile
    {
        [DbcColumn(0, Enums.DbcColumnDataType.Int32)]
        public int Id { get; set; }

        [DbcColumn(1, Enums.DbcColumnDataType.Int32)]
        public int Importance { get; set; }

        [DbcColumn(2, Enums.DbcColumnDataType.ArrayOfUint32, 9)]
        public int[]? Icon { get; set; }

        [DbcColumn(3, Enums.DbcColumnDataType.Int32)]
        public int FactionId { get; set; }

        [DbcColumn(4, Enums.DbcColumnDataType.ArrayOfFloat, 3)]
        public float[]? Pos { get; set; }

        [DbcColumn(5, Enums.DbcColumnDataType.Int32)]
        public int ContinentId { get; set; }

        [DbcColumn(6, Enums.DbcColumnDataType.Int32)]
        public int Flags { get; set; }

        [DbcColumn(7, Enums.DbcColumnDataType.Int32)]
        public int AreaId { get; set; }

        [DbcColumn(8, Enums.DbcColumnDataType.Loc)]
        public string? NameLang { get; set; }

        [DbcColumn(9, Enums.DbcColumnDataType.Loc)]
        public string? Description { get; set; }

        [DbcColumn(10, Enums.DbcColumnDataType.Int32)]
        public int WorldStateId { get; set; }

        [DbcColumn(11, Enums.DbcColumnDataType.Int32)]
        public int WorldMapLink { get; set; }

        public FactionTemplate? GetFactionIdFactionTemplate()
        {
               return DbcDirectory.Open<FactionTemplate>()?.Where(c => c.Id == this.FactionId).FirstOrDefault();
        }

        public Map? GetContinentIdMap()
        {
               return DbcDirectory.Open<Map>()?.Where(c => c.Id == this.ContinentId).FirstOrDefault();
        }

        public AreaTable? GetAreaIdAreaTable()
        {
               return DbcDirectory.Open<AreaTable>()?.Where(c => c.Id == this.AreaId).FirstOrDefault();
        }

     }
}
