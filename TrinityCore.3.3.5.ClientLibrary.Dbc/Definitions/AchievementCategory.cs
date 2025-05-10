using TrinityCore._3._3._5.ClientLibrary.Dbc.Attributes;
using TrinityCore._3._3._5.ClientLibrary.Dbc.Enums;

namespace TrinityCore._3._3._5.ClientLibrary.Dbc.Definitions;

[DbcFile("Achievement_Category.dbc")]
public class AchievementCategory : DbcFile
{
    [DbcColumn(0, DbcColumnDataType.Int32)]
    public int Id { get; set; }

    [DbcColumn(1, DbcColumnDataType.Int32)]
    public int Parent { get; set; }

    [DbcColumn(2, DbcColumnDataType.Loc)]
    public string? NameLang { get; set; }

    [DbcColumn(3, DbcColumnDataType.Int32)]
    public int UiOrder { get; set; }

    public AchievementCategory? GetParentAchievementCategory()
    {
        return DbcDirectory.Open<AchievementCategory>()?.Where(c => c.Id == Parent).FirstOrDefault();
    }
}