using TrinityCore._3._3._5.ClientLibrary.Dbc.Attributes;
using TrinityCore._3._3._5.ClientLibrary.Dbc.Enums;

namespace TrinityCore._3._3._5.ClientLibrary.Dbc.Definitions;

[DbcFile("WorldMapOverlay.dbc")]
public class WorldMapOverlay : DbcFile
{
    [DbcColumn(0, DbcColumnDataType.Int32)]
    public int Id { get; set; }

    [DbcColumn(1, DbcColumnDataType.Int32)]
    public int MapAreaId { get; set; }

    [DbcColumn(2, DbcColumnDataType.ArrayOfUint32, 4)]
    public int[]? AreaId { get; set; }

    [DbcColumn(3, DbcColumnDataType.Int32)]
    public int MapPointX { get; set; }

    [DbcColumn(4, DbcColumnDataType.Int32)]
    public int MapPointY { get; set; }

    [DbcColumn(5, DbcColumnDataType.StringRef)]
    public string? TextureName { get; set; }

    [DbcColumn(6, DbcColumnDataType.Int32)]
    public int TextureWidth { get; set; }

    [DbcColumn(7, DbcColumnDataType.Int32)]
    public int TextureHeight { get; set; }

    [DbcColumn(8, DbcColumnDataType.Int32)]
    public int OffsetX { get; set; }

    [DbcColumn(9, DbcColumnDataType.Int32)]
    public int OffsetY { get; set; }

    [DbcColumn(10, DbcColumnDataType.Int32)]
    public int HitRectTop { get; set; }

    [DbcColumn(11, DbcColumnDataType.Int32)]
    public int HitRectLeft { get; set; }

    [DbcColumn(12, DbcColumnDataType.Int32)]
    public int HitRectBottom { get; set; }

    [DbcColumn(13, DbcColumnDataType.Int32)]
    public int HitRectRight { get; set; }

    public WorldMapArea? GetMapAreaIdWorldMapArea()
    {
        return DbcDirectory.Open<WorldMapArea>()?.Where(c => c.Id == MapAreaId).FirstOrDefault();
    }

    public AreaTable[]? GetAreaIdAreaTables()
    {
        return DbcDirectory.Open<AreaTable>()?.Where(c => AreaId != null && AreaId.Contains(c.Id)).ToArray();
    }
}