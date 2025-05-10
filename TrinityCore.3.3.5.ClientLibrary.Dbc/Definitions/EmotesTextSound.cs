using TrinityCore._3._3._5.ClientLibrary.Dbc.Attributes;

namespace TrinityCore._3._3._5.ClientLibrary.Dbc.Definitions
{
    [DbcFile("EmotesTextSound.dbc")]
    public class EmotesTextSound : DbcFile
    {
        [DbcColumn(0, Enums.DbcColumnDataType.Int32)]
        public int Id { get; set; }

        [DbcColumn(1, Enums.DbcColumnDataType.Int32)]
        public int EmotesTextId { get; set; }

        [DbcColumn(2, Enums.DbcColumnDataType.Int32)]
        public int RaceId { get; set; }

        [DbcColumn(3, Enums.DbcColumnDataType.Int32)]
        public int SexId { get; set; }

        [DbcColumn(4, Enums.DbcColumnDataType.Int32)]
        public int SoundId { get; set; }

        public EmotesText? GetEmotesTextIdEmotesText()
        {
               return DbcDirectory.Open<EmotesText>()?.Where(c => c.Id == this.EmotesTextId).FirstOrDefault();
        }

        public ChrRaces? GetRaceIdChrRaces()
        {
               return DbcDirectory.Open<ChrRaces>()?.Where(c => c.Id == this.RaceId).FirstOrDefault();
        }

        public SoundEntries? GetSoundIdSoundEntries()
        {
               return DbcDirectory.Open<SoundEntries>()?.Where(c => c.Id == this.SoundId).FirstOrDefault();
        }

     }
}
