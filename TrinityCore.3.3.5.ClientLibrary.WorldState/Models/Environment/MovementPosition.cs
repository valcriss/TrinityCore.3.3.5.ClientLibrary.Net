namespace TrinityCore._3._3._5.ClientLibrary.WorldState.Models.Environment;

public class MovementPosition
{
    public Position Position { get; set; } = new();
    public bool Transport { get; set; }
    public ulong? TransportGuid { get; set; }
    public Position TransportPosition { get; set; } = new();
}