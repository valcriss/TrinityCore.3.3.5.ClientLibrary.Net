using TrinityCore._3._3._5.ClientLibrary.Dbc.Attributes;

namespace TrinityCore._3._3._5.ClientLibrary.Dbc.Definitions
{
    [DbcFile("SpellMissile.dbc")]
    public class SpellMissile : DbcFile
    {
        [DbcColumn(0, Enums.DbcColumnDataType.Int32)]
        public int Id { get; set; }

        [DbcColumn(1, Enums.DbcColumnDataType.Int32)]
        public int Flags { get; set; }

        [DbcColumn(2, Enums.DbcColumnDataType.Float)]
        public float DefaultPitchMin { get; set; }

        [DbcColumn(3, Enums.DbcColumnDataType.Float)]
        public float DefaultPitchMax { get; set; }

        [DbcColumn(4, Enums.DbcColumnDataType.Float)]
        public float DefaultSpeedMin { get; set; }

        [DbcColumn(5, Enums.DbcColumnDataType.Float)]
        public float DefaultSpeedMax { get; set; }

        [DbcColumn(6, Enums.DbcColumnDataType.Float)]
        public float RandomizeFacingMin { get; set; }

        [DbcColumn(7, Enums.DbcColumnDataType.Float)]
        public float RandomizeFacingMax { get; set; }

        [DbcColumn(8, Enums.DbcColumnDataType.Float)]
        public float RandomizePitchMin { get; set; }

        [DbcColumn(9, Enums.DbcColumnDataType.Float)]
        public float RandomizePitchMax { get; set; }

        [DbcColumn(10, Enums.DbcColumnDataType.Float)]
        public float RandomizeSpeedMin { get; set; }

        [DbcColumn(11, Enums.DbcColumnDataType.Float)]
        public float RandomizeSpeedMax { get; set; }

        [DbcColumn(12, Enums.DbcColumnDataType.Float)]
        public float Gravity { get; set; }

        [DbcColumn(13, Enums.DbcColumnDataType.Float)]
        public float MaxDuration { get; set; }

        [DbcColumn(14, Enums.DbcColumnDataType.Float)]
        public float CollisionRadius { get; set; }

     }
}
