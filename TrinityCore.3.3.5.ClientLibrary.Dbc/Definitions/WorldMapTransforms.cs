using TrinityCore._3._3._5.ClientLibrary.Dbc.Attributes;
using TrinityCore._3._3._5.ClientLibrary.Dbc.Enums;

namespace TrinityCore._3._3._5.ClientLibrary.Dbc.Definitions;

[DbcFile("WorldMapTransforms.dbc")]
public class WorldMapTransforms : DbcFile
{
    [DbcColumn(0, DbcColumnDataType.Int32)]
    public int Id { get; set; }

    [DbcColumn(1, DbcColumnDataType.Int32)]
    public int MapId { get; set; }

    [DbcColumn(2, DbcColumnDataType.ArrayOfFloat, 2)]
    public float[]? RegionMin { get; set; }

    [DbcColumn(3, DbcColumnDataType.ArrayOfFloat, 2)]
    public float[]? RegionMax { get; set; }

    [DbcColumn(4, DbcColumnDataType.Int32)]
    public int NewMapId { get; set; }

    [DbcColumn(5, DbcColumnDataType.ArrayOfFloat, 2)]
    public float[]? RegionOffset { get; set; }

    [DbcColumn(6, DbcColumnDataType.Int32)]
    public int NewDungeonMapId { get; set; }

    public Map? GetMapIdMap()
    {
        return DbcDirectory.Open<Map>()?.Where(c => c.Id == MapId).FirstOrDefault();
    }

    public Map? GetNewMapIdMap()
    {
        return DbcDirectory.Open<Map>()?.Where(c => c.Id == NewMapId).FirstOrDefault();
    }

    public DungeonMap? GetNewDungeonMapIdDungeonMap()
    {
        return DbcDirectory.Open<DungeonMap>()?.Where(c => c.Id == NewDungeonMapId).FirstOrDefault();
    }
}