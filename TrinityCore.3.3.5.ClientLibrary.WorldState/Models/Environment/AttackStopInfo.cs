namespace TrinityCore._3._3._5.ClientLibrary.WorldState.Models.Environment;

public class AttackStopInfo
{
    public ulong Guid { get; set; }
    public ulong? TargetGuid { get; set; }
    public bool IsDead { get; set; }
}