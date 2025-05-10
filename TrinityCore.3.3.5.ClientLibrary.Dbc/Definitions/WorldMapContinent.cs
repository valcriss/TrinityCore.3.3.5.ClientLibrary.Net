using TrinityCore._3._3._5.ClientLibrary.Dbc.Attributes;
using TrinityCore._3._3._5.ClientLibrary.Dbc.Enums;

namespace TrinityCore._3._3._5.ClientLibrary.Dbc.Definitions;

[DbcFile("WorldMapContinent.dbc")]
public class WorldMapContinent : DbcFile
{
    [DbcColumn(0, DbcColumnDataType.Int32)]
    public int Id { get; set; }

    [DbcColumn(1, DbcColumnDataType.Int32)]
    public int MapId { get; set; }

    [DbcColumn(2, DbcColumnDataType.Int32)]
    public int LeftBoundary { get; set; }

    [DbcColumn(3, DbcColumnDataType.Int32)]
    public int RightBoundary { get; set; }

    [DbcColumn(4, DbcColumnDataType.Int32)]
    public int TopBoundary { get; set; }

    [DbcColumn(5, DbcColumnDataType.Int32)]
    public int BottomBoundary { get; set; }

    [DbcColumn(6, DbcColumnDataType.ArrayOfFloat, 2)]
    public float[]? ContinentOffset { get; set; }

    [DbcColumn(7, DbcColumnDataType.Float)]
    public float Scale { get; set; }

    [DbcColumn(8, DbcColumnDataType.ArrayOfFloat, 2)]
    public float[]? TaxiMin { get; set; }

    [DbcColumn(9, DbcColumnDataType.ArrayOfFloat, 2)]
    public float[]? TaxiMax { get; set; }

    [DbcColumn(10, DbcColumnDataType.Int32)]
    public int WorldMapId { get; set; }

    public Map? GetMapIdMap()
    {
        return DbcDirectory.Open<Map>()?.Where(c => c.Id == MapId).FirstOrDefault();
    }

    public WorldMapArea? GetWorldMapIdWorldMapArea()
    {
        return DbcDirectory.Open<WorldMapArea>()?.Where(c => c.Id == WorldMapId).FirstOrDefault();
    }
}