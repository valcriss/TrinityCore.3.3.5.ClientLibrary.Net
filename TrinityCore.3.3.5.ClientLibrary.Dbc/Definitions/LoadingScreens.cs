using TrinityCore._3._3._5.ClientLibrary.Dbc.Attributes;

namespace TrinityCore._3._3._5.ClientLibrary.Dbc.Definitions
{
    [DbcFile("LoadingScreens.dbc")]
    public class LoadingScreens : DbcFile
    {
        [DbcColumn(0, Enums.DbcColumnDataType.Int32)]
        public int Id { get; set; }

        [DbcColumn(1, Enums.DbcColumnDataType.StringRef)]
        public string? Name { get; set; }

        [DbcColumn(2, Enums.DbcColumnDataType.StringRef)]
        public string? FileName { get; set; }

        [DbcColumn(3, Enums.DbcColumnDataType.Int32)]
        public int HasWideScreen { get; set; }

     }
}
