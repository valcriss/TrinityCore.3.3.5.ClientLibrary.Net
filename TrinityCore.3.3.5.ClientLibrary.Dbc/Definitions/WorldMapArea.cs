using TrinityCore._3._3._5.ClientLibrary.Dbc.Attributes;
using TrinityCore._3._3._5.ClientLibrary.Dbc.Enums;

namespace TrinityCore._3._3._5.ClientLibrary.Dbc.Definitions;

[DbcFile("WorldMapArea.dbc")]
public class WorldMapArea : DbcFile
{
    [DbcColumn(0, DbcColumnDataType.Int32)]
    public int Id { get; set; }

    [DbcColumn(1, DbcColumnDataType.Int32)]
    public int MapId { get; set; }

    [DbcColumn(2, DbcColumnDataType.Int32)]
    public int AreaId { get; set; }

    [DbcColumn(3, DbcColumnDataType.StringRef)]
    public string? AreaName { get; set; }

    [DbcColumn(4, DbcColumnDataType.Float)]
    public float LocLeft { get; set; }

    [DbcColumn(5, DbcColumnDataType.Float)]
    public float LocRight { get; set; }

    [DbcColumn(6, DbcColumnDataType.Float)]
    public float LocTop { get; set; }

    [DbcColumn(7, DbcColumnDataType.Float)]
    public float LocBottom { get; set; }

    [DbcColumn(8, DbcColumnDataType.Int32)]
    public int DisplayMapId { get; set; }

    [DbcColumn(9, DbcColumnDataType.Int32)]
    public int DefaultDungeonFloor { get; set; }

    [DbcColumn(10, DbcColumnDataType.Int32)]
    public int ParentWorldMapId { get; set; }

    public Map? GetMapIdMap()
    {
        return DbcDirectory.Open<Map>()?.Where(c => c.Id == MapId).FirstOrDefault();
    }

    public AreaTable? GetAreaIdAreaTable()
    {
        return DbcDirectory.Open<AreaTable>()?.Where(c => c.Id == AreaId).FirstOrDefault();
    }

    public Map? GetDisplayMapIdMap()
    {
        return DbcDirectory.Open<Map>()?.Where(c => c.Id == DisplayMapId).FirstOrDefault();
    }

    public WorldMapArea? GetParentWorldMapIdWorldMapArea()
    {
        return DbcDirectory.Open<WorldMapArea>()?.Where(c => c.Id == ParentWorldMapId).FirstOrDefault();
    }
}