using TrinityCore._3._3._5.ClientLibrary.Dbc.Attributes;
using TrinityCore._3._3._5.ClientLibrary.Dbc.Enums;

namespace TrinityCore._3._3._5.ClientLibrary.Dbc.Definitions;

[DbcFile("ZoneMusic.dbc")]
public class ZoneMusic : DbcFile
{
    [DbcColumn(0, DbcColumnDataType.Int32)]
    public int Id { get; set; }

    [DbcColumn(1, DbcColumnDataType.StringRef)]
    public string? SetName { get; set; }

    [DbcColumn(2, DbcColumnDataType.ArrayOfUint32, 2)]
    public int[]? SilenceIntervalMin { get; set; }

    [DbcColumn(3, DbcColumnDataType.ArrayOfUint32, 2)]
    public int[]? SilenceIntervalMax { get; set; }

    [DbcColumn(4, DbcColumnDataType.ArrayOfUint32, 2)]
    public int[]? Sounds { get; set; }

    public SoundEntries[]? GetSoundsSoundEntriess()
    {
        return DbcDirectory.Open<SoundEntries>()?.Where(c => Sounds != null && Sounds.Contains(c.Id)).ToArray();
    }
}