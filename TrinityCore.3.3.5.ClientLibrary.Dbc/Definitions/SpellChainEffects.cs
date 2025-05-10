using TrinityCore._3._3._5.ClientLibrary.Dbc.Attributes;
using TrinityCore._3._3._5.ClientLibrary.Dbc.Enums;

namespace TrinityCore._3._3._5.ClientLibrary.Dbc.Definitions;

[DbcFile("SpellChainEffects.dbc")]
public class SpellChainEffects : DbcFile
{
    [DbcColumn(0, DbcColumnDataType.Int32)]
    public int Id { get; set; }

    [DbcColumn(1, DbcColumnDataType.Float)]
    public float AvgSegLen { get; set; }

    [DbcColumn(2, DbcColumnDataType.Float)]
    public float Width { get; set; }

    [DbcColumn(3, DbcColumnDataType.Float)]
    public float NoiseScale { get; set; }

    [DbcColumn(4, DbcColumnDataType.Float)]
    public float TexCoordScale { get; set; }

    [DbcColumn(5, DbcColumnDataType.Int32)]
    public int SegDuration { get; set; }

    [DbcColumn(6, DbcColumnDataType.Int32)]
    public int SegDelay { get; set; }

    [DbcColumn(7, DbcColumnDataType.StringRef)]
    public string? Texture { get; set; }

    [DbcColumn(8, DbcColumnDataType.Int32)]
    public int Flags { get; set; }

    [DbcColumn(9, DbcColumnDataType.Int32)]
    public int JointCount { get; set; }

    [DbcColumn(10, DbcColumnDataType.Float)]
    public float JointOffsetRadius { get; set; }

    [DbcColumn(11, DbcColumnDataType.Int32)]
    public int JointsPerMinorJoint { get; set; }

    [DbcColumn(12, DbcColumnDataType.Int32)]
    public int MinorJointsPerMajorJoint { get; set; }

    [DbcColumn(13, DbcColumnDataType.Float)]
    public float MinorJointScale { get; set; }

    [DbcColumn(14, DbcColumnDataType.Float)]
    public float MajorJointScale { get; set; }

    [DbcColumn(15, DbcColumnDataType.Float)]
    public float JointMoveSpeed { get; set; }

    [DbcColumn(16, DbcColumnDataType.Float)]
    public float JointSmoothness { get; set; }

    [DbcColumn(17, DbcColumnDataType.Float)]
    public float MinDurationBetweenJointJumps { get; set; }

    [DbcColumn(18, DbcColumnDataType.Float)]
    public float MaxDurationBetweenJointJumps { get; set; }

    [DbcColumn(19, DbcColumnDataType.Float)]
    public float WaveHeight { get; set; }

    [DbcColumn(20, DbcColumnDataType.Float)]
    public float WaveFreq { get; set; }

    [DbcColumn(21, DbcColumnDataType.Float)]
    public float WaveSpeed { get; set; }

    [DbcColumn(22, DbcColumnDataType.Float)]
    public float MinWaveAngle { get; set; }

    [DbcColumn(23, DbcColumnDataType.Float)]
    public float MaxWaveAngle { get; set; }

    [DbcColumn(24, DbcColumnDataType.Float)]
    public float MinWaveSpin { get; set; }

    [DbcColumn(25, DbcColumnDataType.Float)]
    public float MaxWaveSpin { get; set; }

    [DbcColumn(26, DbcColumnDataType.Float)]
    public float ArcHeight { get; set; }

    [DbcColumn(27, DbcColumnDataType.Float)]
    public float MinArcAngle { get; set; }

    [DbcColumn(28, DbcColumnDataType.Float)]
    public float MaxArcAngle { get; set; }

    [DbcColumn(29, DbcColumnDataType.Float)]
    public float MinArcSpin { get; set; }

    [DbcColumn(30, DbcColumnDataType.Float)]
    public float MaxArcSpin { get; set; }

    [DbcColumn(31, DbcColumnDataType.Float)]
    public float DelayBetweenEffects { get; set; }

    [DbcColumn(32, DbcColumnDataType.Float)]
    public float MinFlickerOnDuration { get; set; }

    [DbcColumn(33, DbcColumnDataType.Float)]
    public float MaxFlickerOnDuration { get; set; }

    [DbcColumn(34, DbcColumnDataType.Float)]
    public float MinFlickerOffDuration { get; set; }

    [DbcColumn(35, DbcColumnDataType.Float)]
    public float MaxFlickerOffDuration { get; set; }

    [DbcColumn(36, DbcColumnDataType.Float)]
    public float PulseSpeed { get; set; }

    [DbcColumn(37, DbcColumnDataType.Float)]
    public float PulseOnLength { get; set; }

    [DbcColumn(38, DbcColumnDataType.Float)]
    public float PulseFadeLength { get; set; }

    [DbcColumn(39, DbcColumnDataType.Byte)]
    public byte Alpha { get; set; }

    [DbcColumn(40, DbcColumnDataType.Byte)]
    public byte Red { get; set; }

    [DbcColumn(41, DbcColumnDataType.Byte)]
    public byte Green { get; set; }

    [DbcColumn(42, DbcColumnDataType.Byte)]
    public byte Blue { get; set; }

    [DbcColumn(43, DbcColumnDataType.Byte)]
    public byte BlendMode { get; set; }

    [DbcColumn(44, DbcColumnDataType.StringRef)]
    public string? Combo { get; set; }

    [DbcColumn(45, DbcColumnDataType.Int32)]
    public int RenderLayer { get; set; }

    [DbcColumn(46, DbcColumnDataType.Float)]
    public float TextureLength { get; set; }

    [DbcColumn(47, DbcColumnDataType.Float)]
    public float WavePhase { get; set; }
}