using TrinityCore._3._3._5.ClientLibrary.Dbc.Attributes;

namespace TrinityCore._3._3._5.ClientLibrary.Dbc.Definitions
{
    [DbcFile("FootstepTerrainLookup.dbc")]
    public class FootstepTerrainLookup : DbcFile
    {
        [DbcColumn(0, Enums.DbcColumnDataType.Int32)]
        public int Id { get; set; }

        [DbcColumn(1, Enums.DbcColumnDataType.Int32)]
        public int CreatureFootstepId { get; set; }

        [DbcColumn(2, Enums.DbcColumnDataType.Int32)]
        public int TerrainSoundId { get; set; }

        [DbcColumn(3, Enums.DbcColumnDataType.Int32)]
        public int SoundId { get; set; }

        [DbcColumn(4, Enums.DbcColumnDataType.Int32)]
        public int SoundIdSplash { get; set; }

        public TerrainType? GetTerrainSoundIdTerrainType()
        {
               return DbcDirectory.Open<TerrainType>()?.Where(c => c.TerrainId == this.TerrainSoundId).FirstOrDefault();
        }

        public SoundEntries? GetSoundIdSoundEntries()
        {
               return DbcDirectory.Open<SoundEntries>()?.Where(c => c.Id == this.SoundId).FirstOrDefault();
        }

        public SoundEntries? GetSoundIdSplashSoundEntries()
        {
               return DbcDirectory.Open<SoundEntries>()?.Where(c => c.Id == this.SoundIdSplash).FirstOrDefault();
        }

     }
}
