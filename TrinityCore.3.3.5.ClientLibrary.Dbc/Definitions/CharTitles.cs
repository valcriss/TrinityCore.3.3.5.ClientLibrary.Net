using TrinityCore._3._3._5.ClientLibrary.Dbc.Attributes;

namespace TrinityCore._3._3._5.ClientLibrary.Dbc.Definitions
{
    [DbcFile("CharTitles.dbc")]
    public class CharTitles : DbcFile
    {
        [DbcColumn(0, Enums.DbcColumnDataType.Int32)]
        public int Id { get; set; }

        [DbcColumn(1, Enums.DbcColumnDataType.Int32)]
        public int ConditionId { get; set; }

        [DbcColumn(2, Enums.DbcColumnDataType.Loc)]
        public string? NameLang { get; set; }

        [DbcColumn(3, Enums.DbcColumnDataType.Loc)]
        public string? Name1 { get; set; }

        [DbcColumn(4, Enums.DbcColumnDataType.Int32)]
        public int MaskId { get; set; }

     }
}
