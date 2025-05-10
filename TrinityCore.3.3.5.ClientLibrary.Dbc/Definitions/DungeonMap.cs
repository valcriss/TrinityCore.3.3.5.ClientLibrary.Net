using TrinityCore._3._3._5.ClientLibrary.Dbc.Attributes;
using TrinityCore._3._3._5.ClientLibrary.Dbc.Enums;

namespace TrinityCore._3._3._5.ClientLibrary.Dbc.Definitions;

[DbcFile("DungeonMap.dbc")]
public class DungeonMap : DbcFile
{
    [DbcColumn(0, DbcColumnDataType.Int32)]
    public int Id { get; set; }

    [DbcColumn(1, DbcColumnDataType.Int32)]
    public int MapId { get; set; }

    [DbcColumn(2, DbcColumnDataType.Int32)]
    public int FloorIndex { get; set; }

    [DbcColumn(3, DbcColumnDataType.Float)]
    public float MinX { get; set; }

    [DbcColumn(4, DbcColumnDataType.Float)]
    public float MaxX { get; set; }

    [DbcColumn(5, DbcColumnDataType.Float)]
    public float MinY { get; set; }

    [DbcColumn(6, DbcColumnDataType.Float)]
    public float MaxY { get; set; }

    [DbcColumn(7, DbcColumnDataType.Int32)]
    public int ParentWorldMapId { get; set; }

    public Map? GetMapIdMap()
    {
        return DbcDirectory.Open<Map>()?.Where(c => c.Id == MapId).FirstOrDefault();
    }

    public AreaTable? GetParentWorldMapIdAreaTable()
    {
        return DbcDirectory.Open<AreaTable>()?.Where(c => c.Id == ParentWorldMapId).FirstOrDefault();
    }
}