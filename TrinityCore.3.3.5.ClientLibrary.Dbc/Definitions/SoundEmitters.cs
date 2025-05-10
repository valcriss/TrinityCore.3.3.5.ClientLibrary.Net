using TrinityCore._3._3._5.ClientLibrary.Dbc.Attributes;
using TrinityCore._3._3._5.ClientLibrary.Dbc.Enums;

namespace TrinityCore._3._3._5.ClientLibrary.Dbc.Definitions;

[DbcFile("SoundEmitters.dbc")]
public class SoundEmitters : DbcFile
{
    [DbcColumn(0, DbcColumnDataType.Int32)]
    public int Id { get; set; }

    [DbcColumn(1, DbcColumnDataType.ArrayOfFloat, 3)]
    public float[]? Position { get; set; }

    [DbcColumn(2, DbcColumnDataType.ArrayOfFloat, 3)]
    public float[]? Direction { get; set; }

    [DbcColumn(3, DbcColumnDataType.Int32)]
    public int SoundEntryAdvancedId { get; set; }

    [DbcColumn(4, DbcColumnDataType.Int32)]
    public int MapId { get; set; }

    [DbcColumn(5, DbcColumnDataType.StringRef)]
    public string? Name { get; set; }

    public SoundEntriesAdvanced? GetSoundEntryAdvancedIdSoundEntriesAdvanced()
    {
        return DbcDirectory.Open<SoundEntriesAdvanced>()?.Where(c => c.Id == SoundEntryAdvancedId).FirstOrDefault();
    }

    public Map? GetMapIdMap()
    {
        return DbcDirectory.Open<Map>()?.Where(c => c.Id == MapId).FirstOrDefault();
    }
}