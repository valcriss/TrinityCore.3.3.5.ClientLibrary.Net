using TrinityCore._3._3._5.ClientLibrary.Dbc.Attributes;
using TrinityCore._3._3._5.ClientLibrary.Dbc.Enums;

namespace TrinityCore._3._3._5.ClientLibrary.Dbc.Definitions;

[DbcFile("ParticleColor.dbc")]
public class ParticleColor : DbcFile
{
    [DbcColumn(0, DbcColumnDataType.Int32)]
    public int Id { get; set; }

    [DbcColumn(1, DbcColumnDataType.ArrayOfUint32, 3)]
    public int[]? Start { get; set; }

    [DbcColumn(2, DbcColumnDataType.ArrayOfUint32, 3)]
    public int[]? MId { get; set; }

    [DbcColumn(3, DbcColumnDataType.ArrayOfUint32, 3)]
    public int[]? End { get; set; }
}