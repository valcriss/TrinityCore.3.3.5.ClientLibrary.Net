using TrinityCore._3._3._5.ClientLibrary.Dbc.Attributes;

namespace TrinityCore._3._3._5.ClientLibrary.Dbc.Definitions
{
    [DbcFile("Lock.dbc")]
    public class Lock : DbcFile
    {
        [DbcColumn(0, Enums.DbcColumnDataType.Int32)]
        public int Id { get; set; }

        [DbcColumn(1, Enums.DbcColumnDataType.ArrayOfUint32, 8)]
        public int[]? Type { get; set; }

        [DbcColumn(2, Enums.DbcColumnDataType.ArrayOfUint32, 8)]
        public int[]? Index { get; set; }

        [DbcColumn(3, Enums.DbcColumnDataType.ArrayOfUint32, 8)]
        public int[]? Skill { get; set; }

        [DbcColumn(4, Enums.DbcColumnDataType.ArrayOfUint32, 8)]
        public int[]? Action { get; set; }

     }
}
