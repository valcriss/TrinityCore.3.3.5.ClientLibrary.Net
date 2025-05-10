using TrinityCore._3._3._5.ClientLibrary.Dbc.Attributes;
using TrinityCore._3._3._5.ClientLibrary.Dbc.Enums;

namespace TrinityCore._3._3._5.ClientLibrary.Dbc.Definitions;

[DbcFile("LightIntBand.dbc")]
public class LightIntBand : DbcFile
{
    [DbcColumn(0, DbcColumnDataType.Int32)]
    public int Id { get; set; }

    [DbcColumn(1, DbcColumnDataType.Int32)]
    public int Num { get; set; }

    [DbcColumn(2, DbcColumnDataType.ArrayOfUint32, 16)]
    public int[]? Time { get; set; }

    [DbcColumn(3, DbcColumnDataType.ArrayOfUint32, 16)]
    public int[]? Data { get; set; }
}