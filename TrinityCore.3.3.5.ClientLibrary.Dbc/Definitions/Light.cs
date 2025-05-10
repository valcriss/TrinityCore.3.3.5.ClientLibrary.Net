using TrinityCore._3._3._5.ClientLibrary.Dbc.Attributes;
using TrinityCore._3._3._5.ClientLibrary.Dbc.Enums;

namespace TrinityCore._3._3._5.ClientLibrary.Dbc.Definitions;

[DbcFile("Light.dbc")]
public class Light : DbcFile
{
    [DbcColumn(0, DbcColumnDataType.Int32)]
    public int Id { get; set; }

    [DbcColumn(1, DbcColumnDataType.Int32)]
    public int ContinentId { get; set; }

    [DbcColumn(2, DbcColumnDataType.ArrayOfFloat, 3)]
    public float[]? GameCoords { get; set; }

    [DbcColumn(3, DbcColumnDataType.Float)]
    public float GameFalloffStart { get; set; }

    [DbcColumn(4, DbcColumnDataType.Float)]
    public float GameFalloffEnd { get; set; }

    [DbcColumn(5, DbcColumnDataType.ArrayOfUint32, 8)]
    public int[]? LightParamsId { get; set; }

    public Map? GetContinentIdMap()
    {
        return DbcDirectory.Open<Map>()?.Where(c => c.Id == ContinentId).FirstOrDefault();
    }

    public LightParams[]? GetLightParamsIdLightParamss()
    {
        return DbcDirectory.Open<LightParams>()?.Where(c => LightParamsId != null && LightParamsId.Contains(c.Id)).ToArray();
    }
}