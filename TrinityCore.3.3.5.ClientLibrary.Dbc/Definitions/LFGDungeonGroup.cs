using TrinityCore._3._3._5.ClientLibrary.Dbc.Attributes;

namespace TrinityCore._3._3._5.ClientLibrary.Dbc.Definitions
{
    [DbcFile("LFGDungeonGroup.dbc")]
    public class LFGDungeonGroup : DbcFile
    {
        [DbcColumn(0, Enums.DbcColumnDataType.Int32)]
        public int Id { get; set; }

        [DbcColumn(1, Enums.DbcColumnDataType.Loc)]
        public string? NameLang { get; set; }

        [DbcColumn(2, Enums.DbcColumnDataType.Int32)]
        public int OrderIndex { get; set; }

        [DbcColumn(3, Enums.DbcColumnDataType.Int32)]
        public int ParentGroupId { get; set; }

        [DbcColumn(4, Enums.DbcColumnDataType.Int32)]
        public int TypeId { get; set; }

     }
}
