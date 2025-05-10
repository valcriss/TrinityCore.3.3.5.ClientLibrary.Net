using TrinityCore._3._3._5.ClientLibrary.Dbc.Attributes;

namespace TrinityCore._3._3._5.ClientLibrary.Dbc.Definitions
{
    [DbcFile("TransportPhysics.dbc")]
    public class TransportPhysics : DbcFile
    {
        [DbcColumn(0, Enums.DbcColumnDataType.Int32)]
        public int Id { get; set; }

        [DbcColumn(1, Enums.DbcColumnDataType.Float)]
        public float WaveAmp { get; set; }

        [DbcColumn(2, Enums.DbcColumnDataType.Float)]
        public float WaveTimeScale { get; set; }

        [DbcColumn(3, Enums.DbcColumnDataType.Float)]
        public float RollAmp { get; set; }

        [DbcColumn(4, Enums.DbcColumnDataType.Float)]
        public float RollTimeScale { get; set; }

        [DbcColumn(5, Enums.DbcColumnDataType.Float)]
        public float PitchAmp { get; set; }

        [DbcColumn(6, Enums.DbcColumnDataType.Float)]
        public float PitchTimeScale { get; set; }

        [DbcColumn(7, Enums.DbcColumnDataType.Float)]
        public float MaxBank { get; set; }

        [DbcColumn(8, Enums.DbcColumnDataType.Float)]
        public float MaxBankTurnSpeed { get; set; }

        [DbcColumn(9, Enums.DbcColumnDataType.Float)]
        public float SpeedDampThresh { get; set; }

        [DbcColumn(10, Enums.DbcColumnDataType.Float)]
        public float SpeedDamp { get; set; }

     }
}
