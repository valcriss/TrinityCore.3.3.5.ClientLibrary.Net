using TrinityCore._3._3._5.ClientLibrary.Dbc.Attributes;

namespace TrinityCore._3._3._5.ClientLibrary.Dbc.Definitions
{
    [DbcFile("AttackAnimTypes.dbc")]
    public class AttackAnimTypes : DbcFile
    {
        [DbcColumn(0, Enums.DbcColumnDataType.Int32)]
        public int AnimId { get; set; }

        [DbcColumn(1, Enums.DbcColumnDataType.StringRef)]
        public string? AnimName { get; set; }

     }
}
