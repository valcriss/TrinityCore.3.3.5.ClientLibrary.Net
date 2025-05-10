using TrinityCore._3._3._5.ClientLibrary.Dbc.Attributes;

namespace TrinityCore._3._3._5.ClientLibrary.Dbc.Definitions
{
    [DbcFile("Exhaustion.dbc")]
    public class Exhaustion : DbcFile
    {
        [DbcColumn(0, Enums.DbcColumnDataType.Int32)]
        public int Id { get; set; }

        [DbcColumn(1, Enums.DbcColumnDataType.Int32)]
        public int Xp { get; set; }

        [DbcColumn(2, Enums.DbcColumnDataType.Float)]
        public float Factor { get; set; }

        [DbcColumn(3, Enums.DbcColumnDataType.Float)]
        public float OutdoorHours { get; set; }

        [DbcColumn(4, Enums.DbcColumnDataType.Float)]
        public float InnHours { get; set; }

        [DbcColumn(5, Enums.DbcColumnDataType.Loc)]
        public string? NameLang { get; set; }

        [DbcColumn(6, Enums.DbcColumnDataType.Float)]
        public float Threshold { get; set; }

     }
}
