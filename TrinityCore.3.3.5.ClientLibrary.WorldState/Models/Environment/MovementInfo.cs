namespace TrinityCore._3._3._5.ClientLibrary.WorldState.Models.Environment;

public class MovementInfo
{
    public MovementHasTarget MovementHasTarget { get; set; } = new();
    public MovementLiving MovementLiving { get; set; } = new();
    public MovementPosition MovementPosition { get; set; } = new();
    public MovementRotation MovementRotation { get; set; } = new();
    public MovementStationary MovementStationary { get; set; } = new();
}