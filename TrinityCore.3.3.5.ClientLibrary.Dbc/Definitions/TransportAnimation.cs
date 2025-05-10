using TrinityCore._3._3._5.ClientLibrary.Dbc.Attributes;
using TrinityCore._3._3._5.ClientLibrary.Dbc.Enums;

namespace TrinityCore._3._3._5.ClientLibrary.Dbc.Definitions;

[DbcFile("TransportAnimation.dbc")]
public class TransportAnimation : DbcFile
{
    [DbcColumn(0, DbcColumnDataType.Int32)]
    public int Id { get; set; }

    [DbcColumn(1, DbcColumnDataType.Int32)]
    public int TransportId { get; set; }

    [DbcColumn(2, DbcColumnDataType.Int32)]
    public int TimeIndex { get; set; }

    [DbcColumn(3, DbcColumnDataType.ArrayOfFloat, 3)]
    public float[]? Pos { get; set; }

    [DbcColumn(4, DbcColumnDataType.Int32)]
    public int SequenceId { get; set; }
}