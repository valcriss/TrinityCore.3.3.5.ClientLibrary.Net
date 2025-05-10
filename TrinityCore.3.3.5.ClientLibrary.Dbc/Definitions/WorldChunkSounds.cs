using TrinityCore._3._3._5.ClientLibrary.Dbc.Attributes;

namespace TrinityCore._3._3._5.ClientLibrary.Dbc.Definitions
{
    [DbcFile("WorldChunkSounds.dbc")]
    public class WorldChunkSounds : DbcFile
    {
        [DbcColumn(0, Enums.DbcColumnDataType.Int32)]
        public int Id { get; set; }

        [DbcColumn(1, Enums.DbcColumnDataType.Int32)]
        public int ChunkX { get; set; }

        [DbcColumn(2, Enums.DbcColumnDataType.Int32)]
        public int ChunkY { get; set; }

        [DbcColumn(3, Enums.DbcColumnDataType.Int32)]
        public int SubchunkX { get; set; }

        [DbcColumn(4, Enums.DbcColumnDataType.Int32)]
        public int SubchunkY { get; set; }

        [DbcColumn(5, Enums.DbcColumnDataType.Int32)]
        public int ZoneIntroMusicId { get; set; }

        [DbcColumn(6, Enums.DbcColumnDataType.Int32)]
        public int ZoneMusicId { get; set; }

        [DbcColumn(7, Enums.DbcColumnDataType.Int32)]
        public int SoundAmbienceId { get; set; }

        [DbcColumn(8, Enums.DbcColumnDataType.Int32)]
        public int SoundProviderPreferencesId { get; set; }

        public ZoneMusic? GetZoneMusicIdZoneMusic()
        {
               return DbcDirectory.Open<ZoneMusic>()?.Where(c => c.Id == this.ZoneMusicId).FirstOrDefault();
        }

        public SoundAmbience? GetSoundAmbienceIdSoundAmbience()
        {
               return DbcDirectory.Open<SoundAmbience>()?.Where(c => c.Id == this.SoundAmbienceId).FirstOrDefault();
        }

        public SoundProviderPreferences? GetSoundProviderPreferencesIdSoundProviderPreferences()
        {
               return DbcDirectory.Open<SoundProviderPreferences>()?.Where(c => c.Id == this.SoundProviderPreferencesId).FirstOrDefault();
        }

     }
}
