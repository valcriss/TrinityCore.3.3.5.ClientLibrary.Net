using TrinityCore._3._3._5.ClientLibrary.Dbc.Attributes;
using TrinityCore._3._3._5.ClientLibrary.Dbc.Enums;

namespace TrinityCore._3._3._5.ClientLibrary.Dbc.Definitions;

[DbcFile("SpellItemEnchantmentCondition.dbc")]
public class SpellItemEnchantmentCondition : DbcFile
{
    [DbcColumn(0, DbcColumnDataType.Int32)]
    public int Id { get; set; }

    [DbcColumn(1, DbcColumnDataType.ArrayOfBool, 5)]
    public bool[]? LtOperandType { get; set; }

    [DbcColumn(2, DbcColumnDataType.ArrayOfUint32, 5)]
    public int[]? LtOperand { get; set; }

    [DbcColumn(3, DbcColumnDataType.ArrayOfBool, 5)]
    public bool[]? Operator { get; set; }

    [DbcColumn(4, DbcColumnDataType.ArrayOfBool, 5)]
    public bool[]? RtOperandType { get; set; }

    [DbcColumn(5, DbcColumnDataType.ArrayOfUint32, 5)]
    public int[]? RtOperand { get; set; }

    [DbcColumn(6, DbcColumnDataType.ArrayOfBool, 5)]
    public bool[]? Logic { get; set; }
}