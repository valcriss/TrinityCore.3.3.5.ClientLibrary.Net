using TrinityCore._3._3._5.ClientLibrary.Dbc.Attributes;

namespace TrinityCore._3._3._5.ClientLibrary.Dbc.Definitions
{
    [DbcFile("AreaTable.dbc")]
    public class AreaTable : DbcFile
    {
        [DbcColumn(0, Enums.DbcColumnDataType.Int32)]
        public int Id { get; set; }

        [DbcColumn(1, Enums.DbcColumnDataType.Int32)]
        public int ContinentId { get; set; }

        [DbcColumn(2, Enums.DbcColumnDataType.Int32)]
        public int ParentAreaId { get; set; }

        [DbcColumn(3, Enums.DbcColumnDataType.Int32)]
        public int AreaBit { get; set; }

        [DbcColumn(4, Enums.DbcColumnDataType.Int32)]
        public int Flags { get; set; }

        [DbcColumn(5, Enums.DbcColumnDataType.Int32)]
        public int SoundProviderPref { get; set; }

        [DbcColumn(6, Enums.DbcColumnDataType.Int32)]
        public int SoundProviderPrefUnderwater { get; set; }

        [DbcColumn(7, Enums.DbcColumnDataType.Int32)]
        public int AmbienceId { get; set; }

        [DbcColumn(8, Enums.DbcColumnDataType.Int32)]
        public int ZoneMusic { get; set; }

        [DbcColumn(9, Enums.DbcColumnDataType.Int32)]
        public int IntroSound { get; set; }

        [DbcColumn(10, Enums.DbcColumnDataType.Int32)]
        public int ExplorationLevel { get; set; }

        [DbcColumn(11, Enums.DbcColumnDataType.Loc)]
        public string? AreaNameLang { get; set; }

        [DbcColumn(12, Enums.DbcColumnDataType.Int32)]
        public int FactionGroupMask { get; set; }

        [DbcColumn(13, Enums.DbcColumnDataType.ArrayOfUint32, 4)]
        public int[]? LiquidTypeId { get; set; }

        [DbcColumn(14, Enums.DbcColumnDataType.Float)]
        public float MinElevation { get; set; }

        [DbcColumn(15, Enums.DbcColumnDataType.Float)]
        public float AmbientMultiplier { get; set; }

        [DbcColumn(16, Enums.DbcColumnDataType.Int32)]
        public int LightId { get; set; }

        public Map? GetContinentIdMap()
        {
               return DbcDirectory.Open<Map>()?.Where(c => c.Id == this.ContinentId).FirstOrDefault();
        }

        public AreaTable? GetParentAreaIdAreaTable()
        {
               return DbcDirectory.Open<AreaTable>()?.Where(c => c.Id == this.ParentAreaId).FirstOrDefault();
        }

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

        public LiquidType[]? GetLiquidTypeIdLiquidTypes()
        {
               return DbcDirectory.Open<LiquidType>()?.Where(c => this.LiquidTypeId != null && this.LiquidTypeId.Contains(c.Id)).ToArray();
        }

        public Light? GetLightIdLight()
        {
               return DbcDirectory.Open<Light>()?.Where(c => c.Id == this.LightId).FirstOrDefault();
        }

     }
}
