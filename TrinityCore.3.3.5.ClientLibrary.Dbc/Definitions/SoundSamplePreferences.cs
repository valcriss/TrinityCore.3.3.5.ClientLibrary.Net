using TrinityCore._3._3._5.ClientLibrary.Dbc.Attributes;
using TrinityCore._3._3._5.ClientLibrary.Dbc.Enums;

namespace TrinityCore._3._3._5.ClientLibrary.Dbc.Definitions;

[DbcFile("SoundSamplePreferences.dbc")]
public class SoundSamplePreferences : DbcFile
{
    [DbcColumn(0, DbcColumnDataType.Int32)]
    public int Id { get; set; }

    [DbcColumn(1, DbcColumnDataType.Int32)]
    public int Field0603592001 { get; set; }

    [DbcColumn(2, DbcColumnDataType.Int32)]
    public int Field0603592002 { get; set; }

    [DbcColumn(3, DbcColumnDataType.Int32)]
    public int EAX2SampleRoom { get; set; }

    [DbcColumn(4, DbcColumnDataType.Int32)]
    public int Field0603592004 { get; set; }

    [DbcColumn(5, DbcColumnDataType.Int32)]
    public int Field0603592005 { get; set; }

    [DbcColumn(6, DbcColumnDataType.Float)]
    public float Field0603592006 { get; set; }

    [DbcColumn(7, DbcColumnDataType.Int32)]
    public int Field0603592007 { get; set; }

    [DbcColumn(8, DbcColumnDataType.Float)]
    public float EAX2SampleOcclusionLFRatio { get; set; }

    [DbcColumn(9, DbcColumnDataType.Float)]
    public float EAX2SampleOcclusionRoomRatio { get; set; }

    [DbcColumn(10, DbcColumnDataType.Int32)]
    public int Field0603592010 { get; set; }

    [DbcColumn(11, DbcColumnDataType.Float)]
    public float EAX1EffectLevel { get; set; }

    [DbcColumn(12, DbcColumnDataType.Int32)]
    public int Field0603592012 { get; set; }

    [DbcColumn(13, DbcColumnDataType.Float)]
    public float Field0603592013 { get; set; }

    [DbcColumn(14, DbcColumnDataType.Float)]
    public float EAX3SampleExclusion { get; set; }

    [DbcColumn(15, DbcColumnDataType.Float)]
    public float Field0603592015 { get; set; }

    [DbcColumn(16, DbcColumnDataType.Int32)]
    public int Field0603592016 { get; set; }
}