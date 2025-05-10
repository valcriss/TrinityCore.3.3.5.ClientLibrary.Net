using TrinityCore._3._3._5.ClientLibrary.Dbc.Attributes;
using TrinityCore._3._3._5.ClientLibrary.Dbc.Enums;

namespace TrinityCore._3._3._5.ClientLibrary.Dbc.Definitions;

[DbcFile("SkillRaceClassInfo.dbc")]
public class SkillRaceClassInfo : DbcFile
{
    [DbcColumn(0, DbcColumnDataType.Int32)]
    public int Id { get; set; }

    [DbcColumn(1, DbcColumnDataType.Int32)]
    public int SkillId { get; set; }

    [DbcColumn(2, DbcColumnDataType.Int32)]
    public int RaceMask { get; set; }

    [DbcColumn(3, DbcColumnDataType.Int32)]
    public int ClassMask { get; set; }

    [DbcColumn(4, DbcColumnDataType.Int32)]
    public int Flags { get; set; }

    [DbcColumn(5, DbcColumnDataType.Int32)]
    public int MinLevel { get; set; }

    [DbcColumn(6, DbcColumnDataType.Int32)]
    public int SkillTierId { get; set; }

    [DbcColumn(7, DbcColumnDataType.Int32)]
    public int SkillCostIndex { get; set; }

    public SkillLine? GetSkillIdSkillLine()
    {
        return DbcDirectory.Open<SkillLine>()?.Where(c => c.Id == SkillId).FirstOrDefault();
    }

    public SkillTiers? GetSkillTierIdSkillTiers()
    {
        return DbcDirectory.Open<SkillTiers>()?.Where(c => c.Id == SkillTierId).FirstOrDefault();
    }
}