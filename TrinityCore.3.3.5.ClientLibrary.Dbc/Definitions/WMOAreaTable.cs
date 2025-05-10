using TrinityCore._3._3._5.ClientLibrary.Dbc.Attributes;

namespace TrinityCore._3._3._5.ClientLibrary.Dbc.Definitions
{
    [DbcFile("WMOAreaTable.dbc")]
    public class WMOAreaTable : DbcFile
    {
        [DbcColumn(0, Enums.DbcColumnDataType.Int32)]
        public int Id { get; set; }

        [DbcColumn(1, Enums.DbcColumnDataType.Int32)]
        public int WMOId { get; set; }

        [DbcColumn(2, Enums.DbcColumnDataType.Int32)]
        public int NameSetId { get; set; }

        [DbcColumn(3, Enums.DbcColumnDataType.Int32)]
        public int WMOGroupId { get; set; }

        [DbcColumn(4, Enums.DbcColumnDataType.Int32)]
        public int SoundProviderPref { get; set; }

        [DbcColumn(5, Enums.DbcColumnDataType.Int32)]
        public int SoundProviderPrefUnderwater { get; set; }

        [DbcColumn(6, Enums.DbcColumnDataType.Int32)]
        public int AmbienceId { get; set; }

        [DbcColumn(7, Enums.DbcColumnDataType.Int32)]
        public int ZoneMusic { get; set; }

        [DbcColumn(8, Enums.DbcColumnDataType.Int32)]
        public int IntroSound { get; set; }

        [DbcColumn(9, Enums.DbcColumnDataType.Int32)]
        public int Flags { get; set; }

        [DbcColumn(10, Enums.DbcColumnDataType.Int32)]
        public int AreaTableId { get; set; }

        [DbcColumn(11, Enums.DbcColumnDataType.Loc)]
        public string? AreaNameLang { get; set; }

        public SoundProviderPreferences? GetSoundProviderPrefSoundProviderPreferences()
        {
               return DbcDirectory.Open<SoundProviderPreferences>()?.Where(c => c.Id == this.SoundProviderPref).FirstOrDefault();
        }

        public SoundProviderPreferences? GetSoundProviderPrefUnderwaterSoundProviderPreferences()
        {
               return DbcDirectory.Open<SoundProviderPreferences>()?.Where(c => c.Id == this.SoundProviderPrefUnderwater).FirstOrDefault();
        }

        public SoundAmbience? GetAmbienceIdSoundAmbience()
        {
               return DbcDirectory.Open<SoundAmbience>()?.Where(c => c.Id == this.AmbienceId).FirstOrDefault();
        }

        public ZoneMusic? GetZoneMusicZoneMusic()
        {
               return DbcDirectory.Open<ZoneMusic>()?.Where(c => c.Id == this.ZoneMusic).FirstOrDefault();
        }

        public ZoneIntroMusicTable? GetIntroSoundZoneIntroMusicTable()
        {
               return DbcDirectory.Open<ZoneIntroMusicTable>()?.Where(c => c.Id == this.IntroSound).FirstOrDefault();
        }

        public AreaTable? GetAreaTableIdAreaTable()
        {
               return DbcDirectory.Open<AreaTable>()?.Where(c => c.Id == this.AreaTableId).FirstOrDefault();
        }

     }
}
