using TrinityCore._3._3._5.ClientLibrary.Dbc.Attributes;
using TrinityCore._3._3._5.ClientLibrary.Dbc.Enums;

namespace TrinityCore._3._3._5.ClientLibrary.Dbc.Definitions;

[DbcFile("BattlemasterList.dbc")]
public class BattlemasterList : DbcFile
{
    [DbcColumn(0, DbcColumnDataType.Int32)]
    public int Id { get; set; }

    [DbcColumn(1, DbcColumnDataType.ArrayOfUint32, 8)]
    public int[]? MapId { get; set; }

    [DbcColumn(2, DbcColumnDataType.Int32)]
    public int InstanceType { get; set; }

    [DbcColumn(3, DbcColumnDataType.Int32)]
    public int GroupsAllowed { get; set; }

    [DbcColumn(4, DbcColumnDataType.Loc)]
    public string? NameLang { get; set; }

    [DbcColumn(5, DbcColumnDataType.Int32)]
    public int MaxGroupSize { get; set; }

    [DbcColumn(6, DbcColumnDataType.Int32)]
    public int HolidayWorldState { get; set; }

    [DbcColumn(7, DbcColumnDataType.Int32)]
    public int MinLevel { get; set; }

    [DbcColumn(8, DbcColumnDataType.Int32)]
    public int MaxLevel { get; set; }

    public Map[]? GetMapIdMaps()
    {
        return DbcDirectory.Open<Map>()?.Where(c => MapId != null && MapId.Contains(c.Id)).ToArray();
    }
}