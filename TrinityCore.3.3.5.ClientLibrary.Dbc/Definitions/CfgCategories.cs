using TrinityCore._3._3._5.ClientLibrary.Dbc.Attributes;

namespace TrinityCore._3._3._5.ClientLibrary.Dbc.Definitions
{
    [DbcFile("Cfg_Categories.dbc")]
    public class CfgCategories : DbcFile
    {
        [DbcColumn(0, Enums.DbcColumnDataType.Int32)]
        public int Id { get; set; }

        [DbcColumn(1, Enums.DbcColumnDataType.Int32)]
        public int LocaleMask { get; set; }

        [DbcColumn(2, Enums.DbcColumnDataType.Int32)]
        public int CreateCharsetMask { get; set; }

        [DbcColumn(3, Enums.DbcColumnDataType.Int32)]
        public int Flags { get; set; }

        [DbcColumn(4, Enums.DbcColumnDataType.Loc)]
        public string? NameLang { get; set; }

     }
}
