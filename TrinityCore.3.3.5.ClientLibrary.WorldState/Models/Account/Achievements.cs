namespace TrinityCore._3._3._5.ClientLibrary.WorldState.Models.Account;

public class Achievements
{
    public List<AchievementCriteria> AchievementCriteria { get; } = new();
    public List<CompletedAchievement> CompletedAchievements { get; } = new();

    public override string ToString()
    {
        return $"Achievements: {string.Join(", ", CompletedAchievements)}\n" +
               $"AchievementCriteria: {string.Join(", ", AchievementCriteria)}";
    }
}