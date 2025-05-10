using TrinityCore._3._3._5.ClientLibrary.Dbc.Attributes;
using TrinityCore._3._3._5.ClientLibrary.Dbc.Enums;

namespace TrinityCore._3._3._5.ClientLibrary.Dbc.Definitions;

[DbcFile("AreaTrigger.dbc")]
public class AreaTrigger : DbcFile
{
    [DbcColumn(0, DbcColumnDataType.Int32)]
    public int Id { get; set; }

    [DbcColumn(1, DbcColumnDataType.Int32)]
    public int ContinentId { get; set; }

    [DbcColumn(2, DbcColumnDataType.ArrayOfFloat, 3)]
    public float[]? Pos { get; set; }

    [DbcColumn(3, DbcColumnDataType.Float)]
    public float Radius { get; set; }

    [DbcColumn(4, DbcColumnDataType.Float)]
    public float BoxLength { get; set; }

    [DbcColumn(5, DbcColumnDataType.Float)]
    public float BoxWidth { get; set; }

    [DbcColumn(6, DbcColumnDataType.Float)]
    public float BoxHeight { get; set; }

    [DbcColumn(7, DbcColumnDataType.Float)]
    public float BoxYaw { get; set; }

    public Map? GetContinentIdMap()
    {
        return DbcDirectory.Open<Map>()?.Where(c => c.Id == ContinentId).FirstOrDefault();
    }
}