using TrinityCore._3._3._5.ClientLibrary.Dbc.Attributes;

namespace TrinityCore._3._3._5.ClientLibrary.Dbc.Definitions
{
    [DbcFile("GlyphSlot.dbc")]
    public class GlyphSlot : DbcFile
    {
        [DbcColumn(0, Enums.DbcColumnDataType.Int32)]
        public int Id { get; set; }

        [DbcColumn(1, Enums.DbcColumnDataType.Int32)]
        public int Type { get; set; }

        [DbcColumn(2, Enums.DbcColumnDataType.Int32)]
        public int Tooltip { get; set; }

     }
}
