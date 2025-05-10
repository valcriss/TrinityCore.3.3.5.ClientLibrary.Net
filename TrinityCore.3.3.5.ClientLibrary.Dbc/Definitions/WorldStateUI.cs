using TrinityCore._3._3._5.ClientLibrary.Dbc.Attributes;
using TrinityCore._3._3._5.ClientLibrary.Dbc.Enums;

namespace TrinityCore._3._3._5.ClientLibrary.Dbc.Definitions;

[DbcFile("WorldStateUI.dbc")]
public class WorldStateUI : DbcFile
{
    [DbcColumn(0, DbcColumnDataType.Int32)]
    public int Id { get; set; }

    [DbcColumn(1, DbcColumnDataType.Int32)]
    public int MapId { get; set; }

    [DbcColumn(2, DbcColumnDataType.Int32)]
    public int AreaId { get; set; }

    [DbcColumn(3, DbcColumnDataType.Int32)]
    public int PhaseShift { get; set; }

    [DbcColumn(4, DbcColumnDataType.StringRef)]
    public string? Icon { get; set; }

    [DbcColumn(5, DbcColumnDataType.Loc)]
    public string? String { get; set; }

    [DbcColumn(6, DbcColumnDataType.Loc)]
    public string? Tooltip { get; set; }

    [DbcColumn(7, DbcColumnDataType.Int32)]
    public int StateVariable { get; set; }

    [DbcColumn(8, DbcColumnDataType.Int32)]
    public int Type { get; set; }

    [DbcColumn(9, DbcColumnDataType.StringRef)]
    public string? DynamicIcon { get; set; }

    [DbcColumn(10, DbcColumnDataType.Loc)]
    public string? DynamicTooltip { get; set; }

    [DbcColumn(11, DbcColumnDataType.StringRef)]
    public string? ExtendedUI { get; set; }

    [DbcColumn(12, DbcColumnDataType.ArrayOfUint32, 3)]
    public int[]? ExtendedUIStateVariable { get; set; }

    public Map? GetMapIdMap()
    {
        return DbcDirectory.Open<Map>()?.Where(c => c.Id == MapId).FirstOrDefault();
    }

    public AreaTable? GetAreaIdAreaTable()
    {
        return DbcDirectory.Open<AreaTable>()?.Where(c => c.Id == AreaId).FirstOrDefault();
    }
}