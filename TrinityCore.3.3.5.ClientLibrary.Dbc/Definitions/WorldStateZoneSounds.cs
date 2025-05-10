using TrinityCore._3._3._5.ClientLibrary.Dbc.Attributes;

namespace TrinityCore._3._3._5.ClientLibrary.Dbc.Definitions
{
    [DbcFile("WorldStateZoneSounds.dbc")]
    public class WorldStateZoneSounds : DbcFile
    {
        [DbcColumn(0, Enums.DbcColumnDataType.Int32)]
        public int WorldStateId { get; set; }

        [DbcColumn(1, Enums.DbcColumnDataType.Int32)]
        public int WorldStateValue { get; set; }

        [DbcColumn(2, Enums.DbcColumnDataType.Int32)]
        public int AreaId { get; set; }

        [DbcColumn(3, Enums.DbcColumnDataType.Int32)]
        public int WMOAreaId { get; set; }

        [DbcColumn(4, Enums.DbcColumnDataType.Int32)]
        public int ZoneIntroMusicId { get; set; }

        [DbcColumn(5, Enums.DbcColumnDataType.Int32)]
        public int ZoneMusicId { get; set; }

        [DbcColumn(6, Enums.DbcColumnDataType.Int32)]
        public int SoundAmbienceId { get; set; }

        [DbcColumn(7, Enums.DbcColumnDataType.Int32)]
        public int SoundProviderPreferencesId { get; set; }

        public AreaTable? GetAreaIdAreaTable()
        {
               return DbcDirectory.Open<AreaTable>()?.Where(c => c.Id == this.AreaId).FirstOrDefault();
        }

        public WMOAreaTable? GetWMOAreaIdWMOAreaTable()
        {
               return DbcDirectory.Open<WMOAreaTable>()?.Where(c => c.Id == this.WMOAreaId).FirstOrDefault();
        }

        public ZoneIntroMusicTable? GetZoneIntroMusicIdZoneIntroMusicTable()
        {
               return DbcDirectory.Open<ZoneIntroMusicTable>()?.Where(c => c.Id == this.ZoneIntroMusicId).FirstOrDefault();
        }

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
