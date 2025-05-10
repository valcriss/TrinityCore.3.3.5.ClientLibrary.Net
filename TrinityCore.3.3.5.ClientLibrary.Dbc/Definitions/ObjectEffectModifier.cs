using TrinityCore._3._3._5.ClientLibrary.Dbc.Attributes;
using TrinityCore._3._3._5.ClientLibrary.Dbc.Enums;

namespace TrinityCore._3._3._5.ClientLibrary.Dbc.Definitions;

[DbcFile("ObjectEffectModifier.dbc")]
public class ObjectEffectModifier : DbcFile
{
    [DbcColumn(0, DbcColumnDataType.Int32)]
    public int Id { get; set; }

    [DbcColumn(1, DbcColumnDataType.Int32)]
    public int InputType { get; set; }

    [DbcColumn(2, DbcColumnDataType.Int32)]
    public int MapType { get; set; }

    [DbcColumn(3, DbcColumnDataType.Int32)]
    public int OutputType { get; set; }

    [DbcColumn(4, DbcColumnDataType.ArrayOfFloat, 4)]
    public float[]? Param { get; set; }
}