using TrinityCore._3._3._5.ClientLibrary.Dbc.Attributes;

namespace TrinityCore._3._3._5.ClientLibrary.Dbc.Definitions
{
    [DbcFile("EmotesText.dbc")]
    public class EmotesText : DbcFile
    {
        [DbcColumn(0, Enums.DbcColumnDataType.Int32)]
        public int Id { get; set; }

        [DbcColumn(1, Enums.DbcColumnDataType.StringRef)]
        public string? Name { get; set; }

        [DbcColumn(2, Enums.DbcColumnDataType.Int32)]
        public int EmoteId { get; set; }

        [DbcColumn(3, Enums.DbcColumnDataType.ArrayOfUint32, 16)]
        public int[]? EmoteText { get; set; }

        public Emotes? GetEmoteIdEmotes()
        {
               return DbcDirectory.Open<Emotes>()?.Where(c => c.Id == this.EmoteId).FirstOrDefault();
        }

        public EmotesTextData[]? GetEmoteTextEmotesTextDatas()
        {
               return DbcDirectory.Open<EmotesTextData>()?.Where(c => this.EmoteText != null && this.EmoteText.Contains(c.Id)).ToArray();
        }

     }
}
