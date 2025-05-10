using TrinityCore._3._3._5.ClientLibrary.Dbc.Attributes;
using TrinityCore._3._3._5.ClientLibrary.Dbc.Enums;

namespace TrinityCore._3._3._5.ClientLibrary.Dbc.Definitions;

[DbcFile("CinematicCamera.dbc")]
public class CinematicCamera : DbcFile
{
    [DbcColumn(0, DbcColumnDataType.Int32)]
    public int Id { get; set; }

    [DbcColumn(1, DbcColumnDataType.StringRef)]
    public string? Model { get; set; }

    [DbcColumn(2, DbcColumnDataType.Int32)]
    public int SoundId { get; set; }

    [DbcColumn(3, DbcColumnDataType.ArrayOfFloat, 3)]
    public float[]? Origin { get; set; }

    [DbcColumn(4, DbcColumnDataType.Float)]
    public float OriginFacing { get; set; }

    public SoundEntries? GetSoundIdSoundEntries()
    {
        return DbcDirectory.Open<SoundEntries>()?.Where(c => c.Id == SoundId).FirstOrDefault();
    }
}