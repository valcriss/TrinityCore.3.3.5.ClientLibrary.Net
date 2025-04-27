using TrinityCore._3._3._5.ClientLibrary.WorldState.Enums;

namespace TrinityCore._3._3._5.ClientLibrary.WorldState.Models.Account;

public class AccountDataTimes
{
    public Dictionary<AccountDataTimesTypes, uint> Values { get; } = new();
    public uint ServerTime { get; set; }

    public override string ToString()
    {
        return $"ServerTime: {ServerTime}, Values: {string.Join(", ", Values.Select(kvp => $"{kvp.Key}: {kvp.Value}"))}";
    }
}