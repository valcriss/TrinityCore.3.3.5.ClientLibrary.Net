using TrinityCore._3._3._5.ClientLibrary.Dbc.Attributes;

namespace TrinityCore._3._3._5.ClientLibrary.Dbc.Definitions
{
    [DbcFile("Emotes.dbc")]
    public class Emotes : DbcFile
    {
        [DbcColumn(0, Enums.DbcColumnDataType.Int32)]
        public int Id { get; set; }

        [DbcColumn(1, Enums.DbcColumnDataType.StringRef)]
        public string? EmoteSlashCommand { get; set; }

        [DbcColumn(2, Enums.DbcColumnDataType.Int32)]
        public int AnimId { get; set; }

        [DbcColumn(3, Enums.DbcColumnDataType.Int32)]
        public int EmoteFlags { get; set; }

        [DbcColumn(4, Enums.DbcColumnDataType.Int32)]
        public int EmoteSpecProc { get; set; }

        [DbcColumn(5, Enums.DbcColumnDataType.Int32)]
        public int EmoteSpecProcParam { get; set; }

        [DbcColumn(6, Enums.DbcColumnDataType.Int32)]
        public int EventSoundId { get; set; }

        public AnimationData? GetAnimIdAnimationData()
        {
               return DbcDirectory.Open<AnimationData>()?.Where(c => c.Id == this.AnimId).FirstOrDefault();
        }

        public SoundEntries? GetEventSoundIdSoundEntries()
        {
               return DbcDirectory.Open<SoundEntries>()?.Where(c => c.Id == this.EventSoundId).FirstOrDefault();
        }

     }
}
