using TrinityCore._3._3._5.ClientLibrary.Dbc.Attributes;

namespace TrinityCore._3._3._5.ClientLibrary.Dbc.Definitions
{
    [DbcFile("Light.dbc")]
    public class Light : DbcFile
    {
        [DbcColumn(0, Enums.DbcColumnDataType.Int32)]
        public int Id { get; set; }

        [DbcColumn(1, Enums.DbcColumnDataType.Int32)]
        public int ContinentId { get; set; }

        [DbcColumn(2, Enums.DbcColumnDataType.ArrayOfFloat, 3)]
        public float[]? GameCoords { get; set; }

        [DbcColumn(3, Enums.DbcColumnDataType.Float)]
        public float GameFalloffStart { get; set; }

        [DbcColumn(4, Enums.DbcColumnDataType.Float)]
        public float GameFalloffEnd { get; set; }

        [DbcColumn(5, Enums.DbcColumnDataType.ArrayOfUint32, 8)]
        public int[]? LightParamsId { get; set; }

        public Map? GetContinentIdMap()
        {
               return DbcDirectory.Open<Map>()?.Where(c => c.Id == this.ContinentId).FirstOrDefault();
        }

        public LightParams[]? GetLightParamsIdLightParamss()
        {
               return DbcDirectory.Open<LightParams>()?.Where(c => this.LightParamsId != null && this.LightParamsId.Contains(c.Id)).ToArray();
        }

     }
}
