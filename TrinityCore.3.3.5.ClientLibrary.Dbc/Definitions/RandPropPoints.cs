using TrinityCore._3._3._5.ClientLibrary.Dbc.Attributes;
using TrinityCore._3._3._5.ClientLibrary.Dbc.Enums;

namespace TrinityCore._3._3._5.ClientLibrary.Dbc.Definitions;

[DbcFile("RandPropPoints.dbc")]
public class RandPropPoints : DbcFile
{
    [DbcColumn(0, DbcColumnDataType.Int32)]
    public int Id { get; set; }

    [DbcColumn(1, DbcColumnDataType.ArrayOfUint32, 5)]
    public int[]? Epic { get; set; }

    [DbcColumn(2, DbcColumnDataType.ArrayOfUint32, 5)]
    public int[]? Superior { get; set; }

    [DbcColumn(3, DbcColumnDataType.ArrayOfUint32, 5)]
    public int[]? Good { get; set; }
}