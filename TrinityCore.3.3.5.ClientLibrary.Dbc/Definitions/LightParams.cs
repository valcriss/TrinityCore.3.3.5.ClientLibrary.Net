using TrinityCore._3._3._5.ClientLibrary.Dbc.Attributes;
using TrinityCore._3._3._5.ClientLibrary.Dbc.Enums;

namespace TrinityCore._3._3._5.ClientLibrary.Dbc.Definitions;

[DbcFile("LightParams.dbc")]
public class LightParams : DbcFile
{
    [DbcColumn(0, DbcColumnDataType.Int32)]
    public int Id { get; set; }

    [DbcColumn(1, DbcColumnDataType.Int32)]
    public int HighlightSky { get; set; }

    [DbcColumn(2, DbcColumnDataType.Int32)]
    public int LightSkyboxId { get; set; }

    [DbcColumn(3, DbcColumnDataType.Float)]
    public float Glow { get; set; }

    [DbcColumn(4, DbcColumnDataType.Float)]
    public float WaterShallowAlpha { get; set; }

    [DbcColumn(5, DbcColumnDataType.Float)]
    public float WaterDeepAlpha { get; set; }

    [DbcColumn(6, DbcColumnDataType.Float)]
    public float OceanShallowAlpha { get; set; }

    [DbcColumn(7, DbcColumnDataType.Float)]
    public float OceanDeepAlpha { get; set; }

    [DbcColumn(8, DbcColumnDataType.Int32)]
    public int Flags { get; set; }

    public LightSkybox? GetLightSkyboxIdLightSkybox()
    {
        return DbcDirectory.Open<LightSkybox>()?.Where(c => c.Id == LightSkyboxId).FirstOrDefault();
    }
}