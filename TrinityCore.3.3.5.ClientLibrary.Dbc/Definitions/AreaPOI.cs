using TrinityCore._3._3._5.ClientLibrary.Dbc.Attributes;
using TrinityCore._3._3._5.ClientLibrary.Dbc.Enums;

namespace TrinityCore._3._3._5.ClientLibrary.Dbc.Definitions;

[DbcFile("AreaPOI.dbc")]
public class AreaPOI : DbcFile
{
    [DbcColumn(0, DbcColumnDataType.Int32)]
    public int Id { get; set; }

    [DbcColumn(1, DbcColumnDataType.Int32)]
    public int Importance { get; set; }

    [DbcColumn(2, DbcColumnDataType.ArrayOfUint32, 9)]
    public int[]? Icon { get; set; }

    [DbcColumn(3, DbcColumnDataType.Int32)]
    public int FactionId { get; set; }

    [DbcColumn(4, DbcColumnDataType.ArrayOfFloat, 3)]
    public float[]? Pos { get; set; }

    [DbcColumn(5, DbcColumnDataType.Int32)]
    public int ContinentId { get; set; }

    [DbcColumn(6, DbcColumnDataType.Int32)]
    public int Flags { get; set; }

    [DbcColumn(7, DbcColumnDataType.Int32)]
    public int AreaId { get; set; }

    [DbcColumn(8, DbcColumnDataType.Loc)]
    public string? NameLang { get; set; }

    [DbcColumn(9, DbcColumnDataType.Loc)]
    public string? Description { get; set; }

    [DbcColumn(10, DbcColumnDataType.Int32)]
    public int WorldStateId { get; set; }

    [DbcColumn(11, DbcColumnDataType.Int32)]
    public int WorldMapLink { get; set; }

    public FactionTemplate? GetFactionIdFactionTemplate()
    {
        return DbcDirectory.Open<FactionTemplate>()?.Where(c => c.Id == FactionId).FirstOrDefault();
    }

    public Map? GetContinentIdMap()
    {
        return DbcDirectory.Open<Map>()?.Where(c => c.Id == ContinentId).FirstOrDefault();
    }

    public AreaTable? GetAreaIdAreaTable()
    {
        return DbcDirectory.Open<AreaTable>()?.Where(c => c.Id == AreaId).FirstOrDefault();
    }
}