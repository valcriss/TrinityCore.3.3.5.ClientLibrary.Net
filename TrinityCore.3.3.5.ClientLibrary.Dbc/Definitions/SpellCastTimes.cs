using TrinityCore._3._3._5.ClientLibrary.Dbc.Attributes;

namespace TrinityCore._3._3._5.ClientLibrary.Dbc.Definitions
{
    [DbcFile("SpellCastTimes.dbc")]
    public class SpellCastTimes : DbcFile
    {
        [DbcColumn(0, Enums.DbcColumnDataType.Int32)]
        public int Id { get; set; }

        [DbcColumn(1, Enums.DbcColumnDataType.Int32)]
        public int Base { get; set; }

        [DbcColumn(2, Enums.DbcColumnDataType.Int32)]
        public int PerLevel { get; set; }

        [DbcColumn(3, Enums.DbcColumnDataType.Int32)]
        public int Minimum { get; set; }

     }
}
