using TrinityCore._3._3._5.ClientLibrary.Dbc.Attributes;

namespace TrinityCore._3._3._5.ClientLibrary.Dbc.Definitions
{
    [DbcFile("Achievement_Criteria.dbc")]
    public class AchievementCriteria : DbcFile
    {
        [DbcColumn(0, Enums.DbcColumnDataType.Int32)]
        public int Id { get; set; }

        [DbcColumn(1, Enums.DbcColumnDataType.Int32)]
        public int AchievementId { get; set; }

        [DbcColumn(2, Enums.DbcColumnDataType.Int32)]
        public int Type { get; set; }

        [DbcColumn(3, Enums.DbcColumnDataType.Int32)]
        public int AssetId { get; set; }

        [DbcColumn(4, Enums.DbcColumnDataType.Int32)]
        public int Quantity { get; set; }

        [DbcColumn(5, Enums.DbcColumnDataType.Int32)]
        public int StartEvent { get; set; }

        [DbcColumn(6, Enums.DbcColumnDataType.Int32)]
        public int StartAsset { get; set; }

        [DbcColumn(7, Enums.DbcColumnDataType.Int32)]
        public int FailEvent { get; set; }

        [DbcColumn(8, Enums.DbcColumnDataType.Int32)]
        public int FailAsset { get; set; }

        [DbcColumn(9, Enums.DbcColumnDataType.Loc)]
        public string? Description { get; set; }

        [DbcColumn(10, Enums.DbcColumnDataType.Int32)]
        public int Flags { get; set; }

        [DbcColumn(11, Enums.DbcColumnDataType.Int32)]
        public int TimerStartEvent { get; set; }

        [DbcColumn(12, Enums.DbcColumnDataType.Int32)]
        public int TimerAssetId { get; set; }

        [DbcColumn(13, Enums.DbcColumnDataType.Int32)]
        public int TimerTime { get; set; }

        [DbcColumn(14, Enums.DbcColumnDataType.Int32)]
        public int UiOrder { get; set; }

        public Achievement? GetAchievementIdAchievement()
        {
               return DbcDirectory.Open<Achievement>()?.Where(c => c.Id == this.AchievementId).FirstOrDefault();
        }

     }
}
