using TrinityCore._3._3._5.ClientLibrary.Dbc.Attributes;
using TrinityCore._3._3._5.ClientLibrary.Dbc.Enums;

namespace TrinityCore._3._3._5.ClientLibrary.Dbc.Definitions;

[DbcFile("ScreenEffect.dbc")]
public class ScreenEffect : DbcFile
{
    [DbcColumn(0, DbcColumnDataType.Int32)]
    public int Id { get; set; }

    [DbcColumn(1, DbcColumnDataType.StringRef)]
    public string? Name { get; set; }

    [DbcColumn(2, DbcColumnDataType.Int32)]
    public int Effect { get; set; }

    [DbcColumn(3, DbcColumnDataType.ArrayOfUint32, 4)]
    public int[]? Param { get; set; }

    [DbcColumn(4, DbcColumnDataType.Int32)]
    public int LightParamsId { get; set; }

    [DbcColumn(5, DbcColumnDataType.Int32)]
    public int SoundAmbienceId { get; set; }

    [DbcColumn(6, DbcColumnDataType.Int32)]
    public int ZoneMusicId { get; set; }

    public LightParams? GetLightParamsIdLightParams()
    {
        return DbcDirectory.Open<LightParams>()?.Where(c => c.Id == LightParamsId).FirstOrDefault();
    }

    public SoundAmbience? GetSoundAmbienceIdSoundAmbience()
    {
        return DbcDirectory.Open<SoundAmbience>()?.Where(c => c.Id == SoundAmbienceId).FirstOrDefault();
    }

    public ZoneMusic? GetZoneMusicIdZoneMusic()
    {
        return DbcDirectory.Open<ZoneMusic>()?.Where(c => c.Id == ZoneMusicId).FirstOrDefault();
    }
}