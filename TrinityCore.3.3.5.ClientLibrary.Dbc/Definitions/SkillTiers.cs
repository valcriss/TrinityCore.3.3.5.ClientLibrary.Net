using TrinityCore._3._3._5.ClientLibrary.Dbc.Attributes;
using TrinityCore._3._3._5.ClientLibrary.Dbc.Enums;

namespace TrinityCore._3._3._5.ClientLibrary.Dbc.Definitions;

[DbcFile("SkillTiers.dbc")]
public class SkillTiers : DbcFile
{
    [DbcColumn(0, DbcColumnDataType.Int32)]
    public int Id { get; set; }

    [DbcColumn(1, DbcColumnDataType.ArrayOfUint32, 16)]
    public int[]? Cost { get; set; }

    [DbcColumn(2, DbcColumnDataType.ArrayOfUint32, 16)]
    public int[]? Value { get; set; }
}