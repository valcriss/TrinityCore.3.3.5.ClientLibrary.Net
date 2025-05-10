using TrinityCore._3._3._5.ClientLibrary.Dbc.Attributes;

namespace TrinityCore._3._3._5.ClientLibrary.Dbc.Definitions
{
    [DbcFile("CameraShakes.dbc")]
    public class CameraShakes : DbcFile
    {
        [DbcColumn(0, Enums.DbcColumnDataType.Int32)]
        public int Id { get; set; }

        [DbcColumn(1, Enums.DbcColumnDataType.Int32)]
        public int ShakeType { get; set; }

        [DbcColumn(2, Enums.DbcColumnDataType.Int32)]
        public int Direction { get; set; }

        [DbcColumn(3, Enums.DbcColumnDataType.Float)]
        public float Amplitude { get; set; }

        [DbcColumn(4, Enums.DbcColumnDataType.Float)]
        public float Frequency { get; set; }

        [DbcColumn(5, Enums.DbcColumnDataType.Float)]
        public float Duration { get; set; }

        [DbcColumn(6, Enums.DbcColumnDataType.Float)]
        public float Phase { get; set; }

        [DbcColumn(7, Enums.DbcColumnDataType.Float)]
        public float Coefficient { get; set; }

     }
}
