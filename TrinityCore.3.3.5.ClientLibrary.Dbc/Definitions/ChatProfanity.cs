using TrinityCore._3._3._5.ClientLibrary.Dbc.Attributes;

namespace TrinityCore._3._3._5.ClientLibrary.Dbc.Definitions
{
    [DbcFile("ChatProfanity.dbc")]
    public class ChatProfanity : DbcFile
    {
        [DbcColumn(0, Enums.DbcColumnDataType.Int32)]
        public int Id { get; set; }

        [DbcColumn(1, Enums.DbcColumnDataType.StringRef)]
        public string? Text { get; set; }

        [DbcColumn(2, Enums.DbcColumnDataType.Int32)]
        public int Language { get; set; }

     }
}
