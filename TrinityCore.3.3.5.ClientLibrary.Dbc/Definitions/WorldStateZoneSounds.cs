using TrinityCore._3._3._5.ClientLibrary.Dbc.Attributes;
using TrinityCore._3._3._5.ClientLibrary.Dbc.Enums;

namespace TrinityCore._3._3._5.ClientLibrary.Dbc.Definitions;

[DbcFile("WorldStateZoneSounds.dbc")]
public class WorldStateZoneSounds : DbcFile
{
    [DbcColumn(0, DbcColumnDataType.Int32)]
    public int WorldStateId { get; set; }

    [DbcColumn(1, DbcColumnDataType.Int32)]
    public int WorldStateValue { get; set; }

    [DbcColumn(2, DbcColumnDataType.Int32)]
    public int AreaId { get; set; }

    [DbcColumn(3, DbcColumnDataType.Int32)]
    public int WMOAreaId { get; set; }

    [DbcColumn(4, DbcColumnDataType.Int32)]
    public int ZoneIntroMusicId { get; set; }

    [DbcColumn(5, DbcColumnDataType.Int32)]
    public int ZoneMusicId { get; set; }

    [DbcColumn(6, DbcColumnDataType.Int32)]
    public int SoundAmbienceId { get; set; }

    [DbcColumn(7, DbcColumnDataType.Int32)]
    public int SoundProviderPreferencesId { get; set; }

    public AreaTable? GetAreaIdAreaTable()
    {
        return DbcDirectory.Open<AreaTable>()?.Where(c => c.Id == AreaId).FirstOrDefault();
    }

    public WMOAreaTable? GetWMOAreaIdWMOAreaTable()
    {
        return DbcDirectory.Open<WMOAreaTable>()?.Where(c => c.Id == WMOAreaId).FirstOrDefault();
    }

    public ZoneIntroMusicTable? GetZoneIntroMusicIdZoneIntroMusicTable()
    {
        return DbcDirectory.Open<ZoneIntroMusicTable>()?.Where(c => c.Id == ZoneIntroMusicId).FirstOrDefault();
    }

    public ZoneMusic? GetZoneMusicIdZoneMusic()
    {
        return DbcDirectory.Open<ZoneMusic>()?.Where(c => c.Id == ZoneMusicId).FirstOrDefault();
    }

    public SoundAmbience? GetSoundAmbienceIdSoundAmbience()
    {
        return DbcDirectory.Open<SoundAmbience>()?.Where(c => c.Id == SoundAmbienceId).FirstOrDefault();
    }

    public SoundProviderPreferences? GetSoundProviderPreferencesIdSoundProviderPreferences()
    {
        return DbcDirectory.Open<SoundProviderPreferences>()?.Where(c => c.Id == SoundProviderPreferencesId).FirstOrDefault();
    }
}