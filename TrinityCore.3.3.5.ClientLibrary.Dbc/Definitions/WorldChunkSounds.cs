using TrinityCore._3._3._5.ClientLibrary.Dbc.Attributes;
using TrinityCore._3._3._5.ClientLibrary.Dbc.Enums;

namespace TrinityCore._3._3._5.ClientLibrary.Dbc.Definitions;

[DbcFile("WorldChunkSounds.dbc")]
public class WorldChunkSounds : DbcFile
{
    [DbcColumn(0, DbcColumnDataType.Int32)]
    public int Id { get; set; }

    [DbcColumn(1, DbcColumnDataType.Int32)]
    public int ChunkX { get; set; }

    [DbcColumn(2, DbcColumnDataType.Int32)]
    public int ChunkY { get; set; }

    [DbcColumn(3, DbcColumnDataType.Int32)]
    public int SubchunkX { get; set; }

    [DbcColumn(4, DbcColumnDataType.Int32)]
    public int SubchunkY { get; set; }

    [DbcColumn(5, DbcColumnDataType.Int32)]
    public int ZoneIntroMusicId { get; set; }

    [DbcColumn(6, DbcColumnDataType.Int32)]
    public int ZoneMusicId { get; set; }

    [DbcColumn(7, DbcColumnDataType.Int32)]
    public int SoundAmbienceId { get; set; }

    [DbcColumn(8, DbcColumnDataType.Int32)]
    public int SoundProviderPreferencesId { get; set; }

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