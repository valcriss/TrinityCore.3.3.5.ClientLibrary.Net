using TrinityCore._3._3._5.ClientLibrary.Dbc.Attributes;
using TrinityCore._3._3._5.ClientLibrary.Dbc.Enums;

namespace TrinityCore._3._3._5.ClientLibrary.Dbc.Definitions;

[DbcFile("DestructibleModelData.dbc")]
public class DestructibleModelData : DbcFile
{
    [DbcColumn(0, DbcColumnDataType.Int32)]
    public int Id { get; set; }

    [DbcColumn(1, DbcColumnDataType.Int32)]
    public int State0ImpactEffectDoodadSet { get; set; }

    [DbcColumn(2, DbcColumnDataType.Int32)]
    public int State0AmbientDoodadSet { get; set; }

    [DbcColumn(3, DbcColumnDataType.Int32)]
    public int State1WMO { get; set; }

    [DbcColumn(4, DbcColumnDataType.Int32)]
    public int State1DestructionDoodadSet { get; set; }

    [DbcColumn(5, DbcColumnDataType.Int32)]
    public int State1ImpactEffectDoodadSet { get; set; }

    [DbcColumn(6, DbcColumnDataType.Int32)]
    public int State1AmbientDoodadSet { get; set; }

    [DbcColumn(7, DbcColumnDataType.Int32)]
    public int State2WMO { get; set; }

    [DbcColumn(8, DbcColumnDataType.Int32)]
    public int State2DestructionDoodadSet { get; set; }

    [DbcColumn(9, DbcColumnDataType.Int32)]
    public int State2ImpactEffectDoodadSet { get; set; }

    [DbcColumn(10, DbcColumnDataType.Int32)]
    public int State2AmbientDoodadSet { get; set; }

    [DbcColumn(11, DbcColumnDataType.Int32)]
    public int State3WMO { get; set; }

    [DbcColumn(12, DbcColumnDataType.Int32)]
    public int State3InitDoodadSet { get; set; }

    [DbcColumn(13, DbcColumnDataType.Int32)]
    public int State3AmbientDoodadSet { get; set; }

    [DbcColumn(14, DbcColumnDataType.Int32)]
    public int EjectDirection { get; set; }

    [DbcColumn(15, DbcColumnDataType.Int32)]
    public int RepairGroundFx { get; set; }

    [DbcColumn(16, DbcColumnDataType.Int32)]
    public int DoNotHighlight { get; set; }

    [DbcColumn(17, DbcColumnDataType.Int32)]
    public int HealEffect { get; set; }

    [DbcColumn(18, DbcColumnDataType.Int32)]
    public int HealEffectSpeed { get; set; }
}