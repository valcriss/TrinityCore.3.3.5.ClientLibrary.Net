using TrinityCore._3._3._5.ClientLibrary.Dbc.Attributes;

namespace TrinityCore._3._3._5.ClientLibrary.Dbc.Definitions
{
    [DbcFile("FileData.dbc")]
    public class FileData : DbcFile
    {
        [DbcColumn(0, Enums.DbcColumnDataType.Int32)]
        public int Id { get; set; }

        [DbcColumn(1, Enums.DbcColumnDataType.StringRef)]
        public string? Filename { get; set; }

        [DbcColumn(2, Enums.DbcColumnDataType.StringRef)]
        public string? Filepath { get; set; }

     }
}
