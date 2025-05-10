using TrinityCore._3._3._5.ClientLibrary.Dbc.Attributes;
using TrinityCore._3._3._5.ClientLibrary.Dbc.Enums;

namespace TrinityCore._3._3._5.ClientLibrary.Dbc.Definitions;

[DbcFile("Achievement.dbc")]
public class Achievement : DbcFile
{
    [DbcColumn(0, DbcColumnDataType.Int32)]
    public int Id { get; set; }

    [DbcColumn(1, DbcColumnDataType.Int32)]
    public int Faction { get; set; }

    [DbcColumn(2, DbcColumnDataType.Int32)]
    public int InstanceId { get; set; }

    [DbcColumn(3, DbcColumnDataType.Int32)]
    public int Supercedes { get; set; }

    [DbcColumn(4, DbcColumnDataType.Loc)]
    public string? Title { get; set; }

    [DbcColumn(5, DbcColumnDataType.Loc)]
    public string? Description { get; set; }

    [DbcColumn(6, DbcColumnDataType.Int32)]
    public int Category { get; set; }

    [DbcColumn(7, DbcColumnDataType.Int32)]
    public int Points { get; set; }

    [DbcColumn(8, DbcColumnDataType.Int32)]
    public int UiOrder { get; set; }

    [DbcColumn(9, DbcColumnDataType.Int32)]
    public int Flags { get; set; }

    [DbcColumn(10, DbcColumnDataType.Int32)]
    public int IconId { get; set; }

    [DbcColumn(11, DbcColumnDataType.Loc)]
    public string? Reward { get; set; }

    [DbcColumn(12, DbcColumnDataType.Int32)]
    public int MinimumCriteria { get; set; }

    [DbcColumn(13, DbcColumnDataType.Int32)]
    public int SharesCriteria { get; set; }

    public Faction? GetFactionFaction()
    {
        return DbcDirectory.Open<Faction>()?.Where(c => c.Id == Faction).FirstOrDefault();
    }

    public Map? GetInstanceIdMap()
    {
        return DbcDirectory.Open<Map>()?.Where(c => c.Id == InstanceId).FirstOrDefault();
    }

    public Achievement? GetSupercedesAchievement()
    {
        return DbcDirectory.Open<Achievement>()?.Where(c => c.Id == Supercedes).FirstOrDefault();
    }

    public AchievementCategory? GetCategoryAchievementCategory()
    {
        return DbcDirectory.Open<AchievementCategory>()?.Where(c => c.Id == Category).FirstOrDefault();
    }

    public SpellIcon? GetIconIdSpellIcon()
    {
        return DbcDirectory.Open<SpellIcon>()?.Where(c => c.Id == IconId).FirstOrDefault();
    }

    public Achievement? GetSharesCriteriaAchievement()
    {
        return DbcDirectory.Open<Achievement>()?.Where(c => c.Id == SharesCriteria).FirstOrDefault();
    }
}