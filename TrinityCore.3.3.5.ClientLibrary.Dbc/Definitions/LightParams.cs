using TrinityCore._3._3._5.ClientLibrary.Dbc.Attributes;

namespace TrinityCore._3._3._5.ClientLibrary.Dbc.Definitions
{
    [DbcFile("LightParams.dbc")]
    public class LightParams : DbcFile
    {
        [DbcColumn(0, Enums.DbcColumnDataType.Int32)]
        public int Id { get; set; }

        [DbcColumn(1, Enums.DbcColumnDataType.Int32)]
        public int HighlightSky { get; set; }

        [DbcColumn(2, Enums.DbcColumnDataType.Int32)]
        public int LightSkyboxId { get; set; }

        [DbcColumn(3, Enums.DbcColumnDataType.Float)]
        public float Glow { get; set; }

        [DbcColumn(4, Enums.DbcColumnDataType.Float)]
        public float WaterShallowAlpha { get; set; }

        [DbcColumn(5, Enums.DbcColumnDataType.Float)]
        public float WaterDeepAlpha { get; set; }

        [DbcColumn(6, Enums.DbcColumnDataType.Float)]
        public float OceanShallowAlpha { get; set; }

        [DbcColumn(7, Enums.DbcColumnDataType.Float)]
        public float OceanDeepAlpha { get; set; }

        [DbcColumn(8, Enums.DbcColumnDataType.Int32)]
        public int Flags { get; set; }

        public LightSkybox? GetLightSkyboxIdLightSkybox()
        {
               return DbcDirectory.Open<LightSkybox>()?.Where(c => c.Id == this.LightSkyboxId).FirstOrDefault();
        }

     }
}
