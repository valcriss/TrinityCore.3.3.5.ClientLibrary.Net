using TrinityCore._3._3._5.ClientLibrary.Dbc.Attributes;

namespace TrinityCore._3._3._5.ClientLibrary.Dbc.Definitions
{
    [DbcFile("SpellDispelType.dbc")]
    public class SpellDispelType : DbcFile
    {
        [DbcColumn(0, Enums.DbcColumnDataType.Int32)]
        public int Id { get; set; }

        [DbcColumn(1, Enums.DbcColumnDataType.Loc)]
        public string? NameLang { get; set; }

        [DbcColumn(2, Enums.DbcColumnDataType.Int32)]
        public int Mask { get; set; }

        [DbcColumn(3, Enums.DbcColumnDataType.Int32)]
        public int ImmunityPossible { get; set; }

        [DbcColumn(4, Enums.DbcColumnDataType.StringRef)]
        public string? InternalName { get; set; }

     }
}
