using TrinityCore._3._3._5.ClientLibrary.Dbc.Attributes;
using TrinityCore._3._3._5.ClientLibrary.Dbc.Enums;

namespace TrinityCore._3._3._5.ClientLibrary.Dbc.Definitions;

[DbcFile("Weather.dbc")]
public class Weather : DbcFile
{
    [DbcColumn(0, DbcColumnDataType.Int32)]
    public int Id { get; set; }

    [DbcColumn(1, DbcColumnDataType.Int32)]
    public int AmbienceId { get; set; }

    [DbcColumn(2, DbcColumnDataType.Int32)]
    public int EffectType { get; set; }

    [DbcColumn(3, DbcColumnDataType.Float)]
    public float TransitionSkyBox { get; set; }

    [DbcColumn(4, DbcColumnDataType.ArrayOfFloat, 3)]
    public float[]? EffectColor { get; set; }

    [DbcColumn(5, DbcColumnDataType.StringRef)]
    public string? EffectTexture { get; set; }

    public SoundEntries? GetAmbienceIdSoundEntries()
    {
        return DbcDirectory.Open<SoundEntries>()?.Where(c => c.Id == AmbienceId).FirstOrDefault();
    }
}