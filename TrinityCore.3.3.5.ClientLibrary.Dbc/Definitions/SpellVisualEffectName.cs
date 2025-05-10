using TrinityCore._3._3._5.ClientLibrary.Dbc.Attributes;

namespace TrinityCore._3._3._5.ClientLibrary.Dbc.Definitions
{
    [DbcFile("SpellVisualEffectName.dbc")]
    public class SpellVisualEffectName : DbcFile
    {
        [DbcColumn(0, Enums.DbcColumnDataType.Int32)]
        public int Id { get; set; }

        [DbcColumn(1, Enums.DbcColumnDataType.StringRef)]
        public string? Name { get; set; }

        [DbcColumn(2, Enums.DbcColumnDataType.StringRef)]
        public string? FileName { get; set; }

        [DbcColumn(3, Enums.DbcColumnDataType.Float)]
        public float AreaEffectSize { get; set; }

        [DbcColumn(4, Enums.DbcColumnDataType.Float)]
        public float Scale { get; set; }

        [DbcColumn(5, Enums.DbcColumnDataType.Float)]
        public float MinAllowedScale { get; set; }

        [DbcColumn(6, Enums.DbcColumnDataType.Float)]
        public float MaxAllowedScale { get; set; }

     }
}
