using TrinityCore._3._3._5.ClientLibrary.Dbc.Attributes;

namespace TrinityCore._3._3._5.ClientLibrary.Dbc.Definitions
{
    [DbcFile("SpellChainEffects.dbc")]
    public class SpellChainEffects : DbcFile
    {
        [DbcColumn(0, Enums.DbcColumnDataType.Int32)]
        public int Id { get; set; }

        [DbcColumn(1, Enums.DbcColumnDataType.Float)]
        public float AvgSegLen { get; set; }

        [DbcColumn(2, Enums.DbcColumnDataType.Float)]
        public float Width { get; set; }

        [DbcColumn(3, Enums.DbcColumnDataType.Float)]
        public float NoiseScale { get; set; }

        [DbcColumn(4, Enums.DbcColumnDataType.Float)]
        public float TexCoordScale { get; set; }

        [DbcColumn(5, Enums.DbcColumnDataType.Int32)]
        public int SegDuration { get; set; }

        [DbcColumn(6, Enums.DbcColumnDataType.Int32)]
        public int SegDelay { get; set; }

        [DbcColumn(7, Enums.DbcColumnDataType.StringRef)]
        public string? Texture { get; set; }

        [DbcColumn(8, Enums.DbcColumnDataType.Int32)]
        public int Flags { get; set; }

        [DbcColumn(9, Enums.DbcColumnDataType.Int32)]
        public int JointCount { get; set; }

        [DbcColumn(10, Enums.DbcColumnDataType.Float)]
        public float JointOffsetRadius { get; set; }

        [DbcColumn(11, Enums.DbcColumnDataType.Int32)]
        public int JointsPerMinorJoint { get; set; }

        [DbcColumn(12, Enums.DbcColumnDataType.Int32)]
        public int MinorJointsPerMajorJoint { get; set; }

        [DbcColumn(13, Enums.DbcColumnDataType.Float)]
        public float MinorJointScale { get; set; }

        [DbcColumn(14, Enums.DbcColumnDataType.Float)]
        public float MajorJointScale { get; set; }

        [DbcColumn(15, Enums.DbcColumnDataType.Float)]
        public float JointMoveSpeed { get; set; }

        [DbcColumn(16, Enums.DbcColumnDataType.Float)]
        public float JointSmoothness { get; set; }

        [DbcColumn(17, Enums.DbcColumnDataType.Float)]
        public float MinDurationBetweenJointJumps { get; set; }

        [DbcColumn(18, Enums.DbcColumnDataType.Float)]
        public float MaxDurationBetweenJointJumps { get; set; }

        [DbcColumn(19, Enums.DbcColumnDataType.Float)]
        public float WaveHeight { get; set; }

        [DbcColumn(20, Enums.DbcColumnDataType.Float)]
        public float WaveFreq { get; set; }

        [DbcColumn(21, Enums.DbcColumnDataType.Float)]
        public float WaveSpeed { get; set; }

        [DbcColumn(22, Enums.DbcColumnDataType.Float)]
        public float MinWaveAngle { get; set; }

        [DbcColumn(23, Enums.DbcColumnDataType.Float)]
        public float MaxWaveAngle { get; set; }

        [DbcColumn(24, Enums.DbcColumnDataType.Float)]
        public float MinWaveSpin { get; set; }

        [DbcColumn(25, Enums.DbcColumnDataType.Float)]
        public float MaxWaveSpin { get; set; }

        [DbcColumn(26, Enums.DbcColumnDataType.Float)]
        public float ArcHeight { get; set; }

        [DbcColumn(27, Enums.DbcColumnDataType.Float)]
        public float MinArcAngle { get; set; }

        [DbcColumn(28, Enums.DbcColumnDataType.Float)]
        public float MaxArcAngle { get; set; }

        [DbcColumn(29, Enums.DbcColumnDataType.Float)]
        public float MinArcSpin { get; set; }

        [DbcColumn(30, Enums.DbcColumnDataType.Float)]
        public float MaxArcSpin { get; set; }

        [DbcColumn(31, Enums.DbcColumnDataType.Float)]
        public float DelayBetweenEffects { get; set; }

        [DbcColumn(32, Enums.DbcColumnDataType.Float)]
        public float MinFlickerOnDuration { get; set; }

        [DbcColumn(33, Enums.DbcColumnDataType.Float)]
        public float MaxFlickerOnDuration { get; set; }

        [DbcColumn(34, Enums.DbcColumnDataType.Float)]
        public float MinFlickerOffDuration { get; set; }

        [DbcColumn(35, Enums.DbcColumnDataType.Float)]
        public float MaxFlickerOffDuration { get; set; }

        [DbcColumn(36, Enums.DbcColumnDataType.Float)]
        public float PulseSpeed { get; set; }

        [DbcColumn(37, Enums.DbcColumnDataType.Float)]
        public float PulseOnLength { get; set; }

        [DbcColumn(38, Enums.DbcColumnDataType.Float)]
        public float PulseFadeLength { get; set; }

        [DbcColumn(39, Enums.DbcColumnDataType.Byte)]
        public byte Alpha { get; set; }

        [DbcColumn(40, Enums.DbcColumnDataType.Byte)]
        public byte Red { get; set; }

        [DbcColumn(41, Enums.DbcColumnDataType.Byte)]
        public byte Green { get; set; }

        [DbcColumn(42, Enums.DbcColumnDataType.Byte)]
        public byte Blue { get; set; }

        [DbcColumn(43, Enums.DbcColumnDataType.Byte)]
        public byte BlendMode { get; set; }

        [DbcColumn(44, Enums.DbcColumnDataType.StringRef)]
        public string? Combo { get; set; }

        [DbcColumn(45, Enums.DbcColumnDataType.Int32)]
        public int RenderLayer { get; set; }

        [DbcColumn(46, Enums.DbcColumnDataType.Float)]
        public float TextureLength { get; set; }

        [DbcColumn(47, Enums.DbcColumnDataType.Float)]
        public float WavePhase { get; set; }

     }
}
