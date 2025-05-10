using TrinityCore._3._3._5.ClientLibrary.Dbc.Attributes;

namespace TrinityCore._3._3._5.ClientLibrary.Dbc.Definitions
{
    [DbcFile("GameTables.dbc")]
    public class GameTables : DbcFile
    {
        [DbcColumn(0, Enums.DbcColumnDataType.StringRef)]
        public string? Name { get; set; }

        [DbcColumn(1, Enums.DbcColumnDataType.Int32)]
        public int NumRows { get; set; }

        [DbcColumn(2, Enums.DbcColumnDataType.Int32)]
        public int NumColumns { get; set; }

     }
}
