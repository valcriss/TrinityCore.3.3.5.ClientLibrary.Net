namespace TrinityCore._3._3._5.ClientLibrary.WorldState.Models.Environment;

public class UpdateMovement
{
    public ulong Guid { get; set; }
    public MovementInfo Movement { get; set; } = new();
}