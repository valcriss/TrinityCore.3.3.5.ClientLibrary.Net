using TrinityCore._3._3._5.ClientLibrary.Dbc.Attributes;

namespace TrinityCore._3._3._5.ClientLibrary.Dbc.Definitions
{
    [DbcFile("TaxiNodes.dbc")]
    public class TaxiNodes : DbcFile
    {
        [DbcColumn(0, Enums.DbcColumnDataType.Int32)]
        public int Id { get; set; }

        [DbcColumn(1, Enums.DbcColumnDataType.Int32)]
        public int ContinentId { get; set; }

        [DbcColumn(2, Enums.DbcColumnDataType.ArrayOfFloat, 3)]
        public float[]? Pos { get; set; }

        [DbcColumn(3, Enums.DbcColumnDataType.Loc)]
        public string? NameLang { get; set; }

        [DbcColumn(4, Enums.DbcColumnDataType.ArrayOfUint32, 2)]
        public int[]? MountCreatureId { get; set; }

        public Map? GetContinentIdMap()
        {
               return DbcDirectory.Open<Map>()?.Where(c => c.Id == this.ContinentId).FirstOrDefault();
        }

     }
}
