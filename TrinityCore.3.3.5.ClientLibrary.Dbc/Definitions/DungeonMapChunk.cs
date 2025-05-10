using TrinityCore._3._3._5.ClientLibrary.Dbc.Attributes;
using TrinityCore._3._3._5.ClientLibrary.Dbc.Enums;

namespace TrinityCore._3._3._5.ClientLibrary.Dbc.Definitions;

[DbcFile("DungeonMapChunk.dbc")]
public class DungeonMapChunk : DbcFile
{
    [DbcColumn(0, DbcColumnDataType.Int32)]
    public int Id { get; set; }

    [DbcColumn(1, DbcColumnDataType.Int32)]
    public int MapId { get; set; }

    [DbcColumn(2, DbcColumnDataType.Int32)]
    public int WMOGroupId { get; set; }

    [DbcColumn(3, DbcColumnDataType.Int32)]
    public int DungeonMapId { get; set; }

    [DbcColumn(4, DbcColumnDataType.Float)]
    public float MinZ { get; set; }

    public Map? GetMapIdMap()
    {
        return DbcDirectory.Open<Map>()?.Where(c => c.Id == MapId).FirstOrDefault();
    }

    public WMOAreaTable? GetWMOGroupIdWMOAreaTable()
    {
        return DbcDirectory.Open<WMOAreaTable>()?.Where(c => c.WMOGroupId == WMOGroupId).FirstOrDefault();
    }

    public DungeonMap? GetDungeonMapIdDungeonMap()
    {
        return DbcDirectory.Open<DungeonMap>()?.Where(c => c.Id == DungeonMapId).FirstOrDefault();
    }
}