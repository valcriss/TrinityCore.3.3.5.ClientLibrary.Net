using TrinityCore._3._3._5.ClientLibrary.Dbc.Attributes;

namespace TrinityCore._3._3._5.ClientLibrary.Dbc.Definitions
{
    [DbcFile("DeathThudLookups.dbc")]
    public class DeathThudLookups : DbcFile
    {
        [DbcColumn(0, Enums.DbcColumnDataType.Int32)]
        public int Id { get; set; }

        [DbcColumn(1, Enums.DbcColumnDataType.Int32)]
        public int SizeClass { get; set; }

        [DbcColumn(2, Enums.DbcColumnDataType.Int32)]
        public int TerrainTypeSoundId { get; set; }

        [DbcColumn(3, Enums.DbcColumnDataType.Int32)]
        public int SoundEntryId { get; set; }

        [DbcColumn(4, Enums.DbcColumnDataType.Int32)]
        public int SoundEntryIdWater { get; set; }

        public TerrainTypeSounds? GetTerrainTypeSoundIdTerrainTypeSounds()
        {
               return DbcDirectory.Open<TerrainTypeSounds>()?.Where(c => c.Id == this.TerrainTypeSoundId).FirstOrDefault();
        }

        public SoundEntries? GetSoundEntryIdSoundEntries()
        {
               return DbcDirectory.Open<SoundEntries>()?.Where(c => c.Id == this.SoundEntryId).FirstOrDefault();
        }

        public SoundEntries? GetSoundEntryIdWaterSoundEntries()
        {
               return DbcDirectory.Open<SoundEntries>()?.Where(c => c.Id == this.SoundEntryIdWater).FirstOrDefault();
        }

     }
}
