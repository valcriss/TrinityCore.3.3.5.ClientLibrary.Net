using TrinityCore._3._3._5.ClientLibrary.Dbc.Attributes;
using TrinityCore._3._3._5.ClientLibrary.Dbc.Enums;

namespace TrinityCore._3._3._5.ClientLibrary.Dbc.Definitions;

[DbcFile("PvpDifficulty.dbc")]
public class PvpDifficulty : DbcFile
{
    [DbcColumn(0, DbcColumnDataType.Int32)]
    public int Id { get; set; }

    [DbcColumn(1, DbcColumnDataType.Int32)]
    public int MapId { get; set; }

    [DbcColumn(2, DbcColumnDataType.Int32)]
    public int RangeIndex { get; set; }

    [DbcColumn(3, DbcColumnDataType.Int32)]
    public int MinLevel { get; set; }

    [DbcColumn(4, DbcColumnDataType.Int32)]
    public int MaxLevel { get; set; }

    [DbcColumn(5, DbcColumnDataType.Int32)]
    public int Difficulty { get; set; }

    public Map? GetMapIdMap()
    {
        return DbcDirectory.Open<Map>()?.Where(c => c.Id == MapId).FirstOrDefault();
    }
}