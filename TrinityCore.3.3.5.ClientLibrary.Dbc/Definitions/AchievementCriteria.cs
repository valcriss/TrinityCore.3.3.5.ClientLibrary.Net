using TrinityCore._3._3._5.ClientLibrary.Dbc.Attributes;
using TrinityCore._3._3._5.ClientLibrary.Dbc.Enums;

namespace TrinityCore._3._3._5.ClientLibrary.Dbc.Definitions;

[DbcFile("Achievement_Criteria.dbc")]
public class AchievementCriteria : DbcFile
{
    [DbcColumn(0, DbcColumnDataType.Int32)]
    public int Id { get; set; }

    [DbcColumn(1, DbcColumnDataType.Int32)]
    public int AchievementId { get; set; }

    [DbcColumn(2, DbcColumnDataType.Int32)]
    public int Type { get; set; }

    [DbcColumn(3, DbcColumnDataType.Int32)]
    public int AssetId { get; set; }

    [DbcColumn(4, DbcColumnDataType.Int32)]
    public int Quantity { get; set; }

    [DbcColumn(5, DbcColumnDataType.Int32)]
    public int StartEvent { get; set; }

    [DbcColumn(6, DbcColumnDataType.Int32)]
    public int StartAsset { get; set; }

    [DbcColumn(7, DbcColumnDataType.Int32)]
    public int FailEvent { get; set; }

    [DbcColumn(8, DbcColumnDataType.Int32)]
    public int FailAsset { get; set; }

    [DbcColumn(9, DbcColumnDataType.Loc)]
    public string? Description { get; set; }

    [DbcColumn(10, DbcColumnDataType.Int32)]
    public int Flags { get; set; }

    [DbcColumn(11, DbcColumnDataType.Int32)]
    public int TimerStartEvent { get; set; }

    [DbcColumn(12, DbcColumnDataType.Int32)]
    public int TimerAssetId { get; set; }

    [DbcColumn(13, DbcColumnDataType.Int32)]
    public int TimerTime { get; set; }

    [DbcColumn(14, DbcColumnDataType.Int32)]
    public int UiOrder { get; set; }

    public Achievement? GetAchievementIdAchievement()
    {
        return DbcDirectory.Open<Achievement>()?.Where(c => c.Id == AchievementId).FirstOrDefault();
    }
}