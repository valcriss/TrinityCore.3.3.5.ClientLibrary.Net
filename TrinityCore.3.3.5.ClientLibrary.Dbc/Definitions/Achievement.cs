using TrinityCore._3._3._5.ClientLibrary.Dbc.Attributes;

namespace TrinityCore._3._3._5.ClientLibrary.Dbc.Definitions
{
    [DbcFile("Achievement.dbc")]
    public class Achievement : DbcFile
    {
        [DbcColumn(0, Enums.DbcColumnDataType.Int32)]
        public int Id { get; set; }

        [DbcColumn(1, Enums.DbcColumnDataType.Int32)]
        public int Faction { get; set; }

        [DbcColumn(2, Enums.DbcColumnDataType.Int32)]
        public int InstanceId { get; set; }

        [DbcColumn(3, Enums.DbcColumnDataType.Int32)]
        public int Supercedes { get; set; }

        [DbcColumn(4, Enums.DbcColumnDataType.Loc)]
        public string? Title { get; set; }

        [DbcColumn(5, Enums.DbcColumnDataType.Loc)]
        public string? Description { get; set; }

        [DbcColumn(6, Enums.DbcColumnDataType.Int32)]
        public int Category { get; set; }

        [DbcColumn(7, Enums.DbcColumnDataType.Int32)]
        public int Points { get; set; }

        [DbcColumn(8, Enums.DbcColumnDataType.Int32)]
        public int UiOrder { get; set; }

        [DbcColumn(9, Enums.DbcColumnDataType.Int32)]
        public int Flags { get; set; }

        [DbcColumn(10, Enums.DbcColumnDataType.Int32)]
        public int IconId { get; set; }

        [DbcColumn(11, Enums.DbcColumnDataType.Loc)]
        public string? Reward { get; set; }

        [DbcColumn(12, Enums.DbcColumnDataType.Int32)]
        public int MinimumCriteria { get; set; }

        [DbcColumn(13, Enums.DbcColumnDataType.Int32)]
        public int SharesCriteria { get; set; }

        public Faction? GetFactionFaction()
        {
               return DbcDirectory.Open<Faction>()?.Where(c => c.Id == this.Faction).FirstOrDefault();
        }

        public Map? GetInstanceIdMap()
        {
               return DbcDirectory.Open<Map>()?.Where(c => c.Id == this.InstanceId).FirstOrDefault();
        }

        public Achievement? GetSupercedesAchievement()
        {
               return DbcDirectory.Open<Achievement>()?.Where(c => c.Id == this.Supercedes).FirstOrDefault();
        }

        public AchievementCategory? GetCategoryAchievementCategory()
        {
               return DbcDirectory.Open<AchievementCategory>()?.Where(c => c.Id == this.Category).FirstOrDefault();
        }

        public SpellIcon? GetIconIdSpellIcon()
        {
               return DbcDirectory.Open<SpellIcon>()?.Where(c => c.Id == this.IconId).FirstOrDefault();
        }

        public Achievement? GetSharesCriteriaAchievement()
        {
               return DbcDirectory.Open<Achievement>()?.Where(c => c.Id == this.SharesCriteria).FirstOrDefault();
        }

     }
}
