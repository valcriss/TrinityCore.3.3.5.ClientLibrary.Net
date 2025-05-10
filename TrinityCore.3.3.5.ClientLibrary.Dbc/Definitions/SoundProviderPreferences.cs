using TrinityCore._3._3._5.ClientLibrary.Dbc.Attributes;
using TrinityCore._3._3._5.ClientLibrary.Dbc.Enums;

namespace TrinityCore._3._3._5.ClientLibrary.Dbc.Definitions;

[DbcFile("SoundProviderPreferences.dbc")]
public class SoundProviderPreferences : DbcFile
{
    [DbcColumn(0, DbcColumnDataType.Int32)]
    public int Id { get; set; }

    [DbcColumn(1, DbcColumnDataType.StringRef)]
    public string? Description { get; set; }

    [DbcColumn(2, DbcColumnDataType.Int32)]
    public int Flags { get; set; }

    [DbcColumn(3, DbcColumnDataType.Int32)]
    public int EAXEnvironmentSelection { get; set; }

    [DbcColumn(4, DbcColumnDataType.Float)]
    public float EAXDecayTime { get; set; }

    [DbcColumn(5, DbcColumnDataType.Float)]
    public float EAX2EnvironmentSize { get; set; }

    [DbcColumn(6, DbcColumnDataType.Float)]
    public float EAX2EnvironmentDiffusion { get; set; }

    [DbcColumn(7, DbcColumnDataType.Int32)]
    public int EAX2Room { get; set; }

    [DbcColumn(8, DbcColumnDataType.Int32)]
    public int EAX2RoomHF { get; set; }

    [DbcColumn(9, DbcColumnDataType.Float)]
    public float EAX2DecayHFRatio { get; set; }

    [DbcColumn(10, DbcColumnDataType.Int32)]
    public int EAX2Reflections { get; set; }

    [DbcColumn(11, DbcColumnDataType.Float)]
    public float EAX2ReflectionsDelay { get; set; }

    [DbcColumn(12, DbcColumnDataType.Int32)]
    public int EAX2Reverb { get; set; }

    [DbcColumn(13, DbcColumnDataType.Float)]
    public float EAX2ReverbDelay { get; set; }

    [DbcColumn(14, DbcColumnDataType.Float)]
    public float EAX2RoomRolloff { get; set; }

    [DbcColumn(15, DbcColumnDataType.Float)]
    public float EAX2AirAbsorption { get; set; }

    [DbcColumn(16, DbcColumnDataType.Int32)]
    public int EAX3RoomLF { get; set; }

    [DbcColumn(17, DbcColumnDataType.Float)]
    public float EAX3DecayLFRatio { get; set; }

    [DbcColumn(18, DbcColumnDataType.Float)]
    public float EAX3EchoTime { get; set; }

    [DbcColumn(19, DbcColumnDataType.Float)]
    public float EAX3EchoDepth { get; set; }

    [DbcColumn(20, DbcColumnDataType.Float)]
    public float EAX3ModulationTime { get; set; }

    [DbcColumn(21, DbcColumnDataType.Float)]
    public float EAX3ModulationDepth { get; set; }

    [DbcColumn(22, DbcColumnDataType.Float)]
    public float EAX3HFReference { get; set; }

    [DbcColumn(23, DbcColumnDataType.Float)]
    public float EAX3LFReference { get; set; }
}