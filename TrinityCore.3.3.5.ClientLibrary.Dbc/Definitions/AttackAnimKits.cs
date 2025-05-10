using TrinityCore._3._3._5.ClientLibrary.Dbc.Attributes;
using TrinityCore._3._3._5.ClientLibrary.Dbc.Enums;

namespace TrinityCore._3._3._5.ClientLibrary.Dbc.Definitions;

[DbcFile("AttackAnimKits.dbc")]
public class AttackAnimKits : DbcFile
{
    [DbcColumn(0, DbcColumnDataType.Int32)]
    public int Id { get; set; }

    [DbcColumn(1, DbcColumnDataType.Int32)]
    public int ItemSubclassId { get; set; }

    [DbcColumn(2, DbcColumnDataType.Int32)]
    public int AnimTypeId { get; set; }

    [DbcColumn(3, DbcColumnDataType.Int32)]
    public int AnimFrequency { get; set; }

    [DbcColumn(4, DbcColumnDataType.Int32)]
    public int WhichHand { get; set; }

    public AttackAnimTypes? GetAnimTypeIdAttackAnimTypes()
    {
        return DbcDirectory.Open<AttackAnimTypes>()?.Where(c => c.AnimId == AnimTypeId).FirstOrDefault();
    }
}