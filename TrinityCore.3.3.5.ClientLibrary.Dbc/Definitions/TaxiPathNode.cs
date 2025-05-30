using TrinityCore._3._3._5.ClientLibrary.Dbc.Attributes;
using TrinityCore._3._3._5.ClientLibrary.Dbc.Enums;

namespace TrinityCore._3._3._5.ClientLibrary.Dbc.Definitions;

[DbcFile("TaxiPathNode.dbc")]
public class TaxiPathNode : DbcFile
{
    [DbcColumn(0, DbcColumnDataType.Int32)]
    public int Id { get; set; }

    [DbcColumn(1, DbcColumnDataType.Int32)]
    public int PathId { get; set; }

    [DbcColumn(2, DbcColumnDataType.Int32)]
    public int NodeIndex { get; set; }

    [DbcColumn(3, DbcColumnDataType.Int32)]
    public int ContinentId { get; set; }

    [DbcColumn(4, DbcColumnDataType.ArrayOfFloat, 3)]
    public float[]? Loc { get; set; }

    [DbcColumn(5, DbcColumnDataType.Int32)]
    public int Flags { get; set; }

    [DbcColumn(6, DbcColumnDataType.Int32)]
    public int Delay { get; set; }

    [DbcColumn(7, DbcColumnDataType.Int32)]
    public int ArrivalEventId { get; set; }

    [DbcColumn(8, DbcColumnDataType.Int32)]
    public int DepartureEventId { get; set; }

    public TaxiPath? GetPathIdTaxiPath()
    {
        return DbcDirectory.Open<TaxiPath>()?.Where(c => c.Id == PathId).FirstOrDefault();
    }

    public Map? GetContinentIdMap()
    {
        return DbcDirectory.Open<Map>()?.Where(c => c.Id == ContinentId).FirstOrDefault();
    }
}