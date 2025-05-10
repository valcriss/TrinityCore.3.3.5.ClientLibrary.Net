using TrinityCore._3._3._5.ClientLibrary.Dbc.Attributes;

namespace TrinityCore._3._3._5.ClientLibrary.Dbc.Definitions
{
    [DbcFile("ItemClass.dbc")]
    public class ItemClass : DbcFile
    {
        [DbcColumn(0, Enums.DbcColumnDataType.Int32)]
        public int ClassId { get; set; }

        [DbcColumn(1, Enums.DbcColumnDataType.Int32)]
        public int SubclassMapId { get; set; }

        [DbcColumn(2, Enums.DbcColumnDataType.Int32)]
        public int Flags { get; set; }

        [DbcColumn(3, Enums.DbcColumnDataType.Loc)]
        public string? ClassNameLang { get; set; }

     }
}
