using TrinityCore._3._3._5.ClientLibrary.Dbc.Attributes;
using TrinityCore._3._3._5.ClientLibrary.Dbc.Enums;

namespace TrinityCore._3._3._5.ClientLibrary.Dbc.Definitions;

[DbcFile("CameraShakes.dbc")]
public class CameraShakes : DbcFile
{
    [DbcColumn(0, DbcColumnDataType.Int32)]
    public int Id { get; set; }

    [DbcColumn(1, DbcColumnDataType.Int32)]
    public int ShakeType { get; set; }

    [DbcColumn(2, DbcColumnDataType.Int32)]
    public int Direction { get; set; }

    [DbcColumn(3, DbcColumnDataType.Float)]
    public float Amplitude { get; set; }

    [DbcColumn(4, DbcColumnDataType.Float)]
    public float Frequency { get; set; }

    [DbcColumn(5, DbcColumnDataType.Float)]
    public float Duration { get; set; }

    [DbcColumn(6, DbcColumnDataType.Float)]
    public float Phase { get; set; }

    [DbcColumn(7, DbcColumnDataType.Float)]
    public float Coefficient { get; set; }
}