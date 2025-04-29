namespace TrinityCore._3._3._5.ClientLibrary.WorldState.Models.Environment;

public class MovementInfo
{
    public MovementHasTarget? MovementHasTarget { get; set; } = null;
    public MovementLiving? MovementLiving { get; set; } = null;
    public MovementPosition? MovementPosition { get; set; } = null;
    public MovementRotation? MovementRotation { get; set; } = null;
    public MovementStationary? MovementStationary { get; set; } = null;
}