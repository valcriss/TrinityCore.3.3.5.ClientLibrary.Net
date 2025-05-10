using TrinityCore._3._3._5.ClientLibrary.Dbc.Attributes;
using TrinityCore._3._3._5.ClientLibrary.Dbc.Enums;

namespace TrinityCore._3._3._5.ClientLibrary.Dbc.Definitions;

[DbcFile("MapDifficulty.dbc")]
public class MapDifficulty : DbcFile
{
    [DbcColumn(0, DbcColumnDataType.Int32)]
    public int Id { get; set; }

    [DbcColumn(1, DbcColumnDataType.Int32)]
    public int MapId { get; set; }

    [DbcColumn(2, DbcColumnDataType.Int32)]
    public int Difficulty { get; set; }

    [DbcColumn(3, DbcColumnDataType.Loc)]
    public string? Message { get; set; }

    [DbcColumn(4, DbcColumnDataType.Int32)]
    public int RaidDuration { get; set; }

    [DbcColumn(5, DbcColumnDataType.Int32)]
    public int MaxPlayers { get; set; }

    [DbcColumn(6, DbcColumnDataType.StringRef)]
    public string? Difficultystring { get; set; }

    public Map? GetMapIdMap()
    {
        return DbcDirectory.Open<Map>()?.Where(c => c.Id == MapId).FirstOrDefault();
    }
}