using TrinityCore._3._3._5.ClientLibrary.Dbc.Attributes;
using TrinityCore._3._3._5.ClientLibrary.Dbc.Enums;

namespace TrinityCore._3._3._5.ClientLibrary.Dbc.Definitions;

[DbcFile("DurabilityCosts.dbc")]
public class DurabilityCosts : DbcFile
{
    [DbcColumn(0, DbcColumnDataType.Int32)]
    public int Id { get; set; }

    [DbcColumn(1, DbcColumnDataType.ArrayOfUint32, 21)]
    public int[]? WeaponSubClassCost { get; set; }

    [DbcColumn(2, DbcColumnDataType.ArrayOfUint32, 8)]
    public int[]? ArmorSubClassCost { get; set; }
}