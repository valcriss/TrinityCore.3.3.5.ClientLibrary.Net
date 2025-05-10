using TrinityCore._3._3._5.ClientLibrary.Dbc.Attributes;
using TrinityCore._3._3._5.ClientLibrary.Dbc.Enums;

namespace TrinityCore._3._3._5.ClientLibrary.Dbc.Definitions;

[DbcFile("CinematicSequences.dbc")]
public class CinematicSequences : DbcFile
{
    [DbcColumn(0, DbcColumnDataType.Int32)]
    public int Id { get; set; }

    [DbcColumn(1, DbcColumnDataType.Int32)]
    public int SoundId { get; set; }

    [DbcColumn(2, DbcColumnDataType.ArrayOfUint32, 8)]
    public int[]? Camera { get; set; }

    public SoundEntries? GetSoundIdSoundEntries()
    {
        return DbcDirectory.Open<SoundEntries>()?.Where(c => c.Id == SoundId).FirstOrDefault();
    }

    public CinematicCamera[]? GetCameraCinematicCameras()
    {
        return DbcDirectory.Open<CinematicCamera>()?.Where(c => Camera != null && Camera.Contains(c.Id)).ToArray();
    }
}