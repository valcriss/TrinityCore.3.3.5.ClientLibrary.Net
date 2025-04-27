namespace TrinityCore._3._3._5.ClientLibrary.WorldState.Models.Account;

public class CompletedAchievement
{
    public uint AchievementId { get; set; }
    public DateTime Date { get; set; }

    public override string ToString()
    {
        return $"CompletedAchievement: {AchievementId}, Date: {Date}";
    }
}