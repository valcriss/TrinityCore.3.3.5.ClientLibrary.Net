namespace TrinityCore._3._3._5.ClientLibrary.WorldState.Models.Environment;

public class ThreatData
{
    public ulong Guid { get; set; }
    public ulong HighestThreatGuid { get; set; }
    public List<ThreatItem> ThreatItems { get; set; } = new();
}