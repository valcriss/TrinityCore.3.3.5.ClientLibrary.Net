namespace TrinityCore._3._3._5.ClientLibrary.WorldState.Models.Account;

public class AchievementCriteria
{
    public ulong Counter { get; set; }
    public uint CriteriaId { get; set; }
    public DateTime Date { get; set; }

    public override string ToString()
    {
        return $"AchievementCriteria: {CriteriaId}, Counter: {Counter}, Date: {Date}";
    }
}