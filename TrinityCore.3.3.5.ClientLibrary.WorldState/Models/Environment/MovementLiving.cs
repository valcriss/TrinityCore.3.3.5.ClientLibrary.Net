using TrinityCore._3._3._5.ClientLibrary.WorldState.Enums;

namespace TrinityCore._3._3._5.ClientLibrary.WorldState.Models.Environment;

public class MovementLiving
{
    public MovementOptions ExtraMovementFlags { get; set; }

    public uint FallTime { get; set; }

    public float? JumpCosAngle { get; set; }

    public float? JumpSinAngle { get; set; }

    public float? JumpXySpeed { get; set; }

    // MOVEMENTFLAG_FALLING
    public float? JumpZSpeed { get; set; }

    public MovementTypes MovementFlags { get; set; }

    // MOVEMENTFLAG_SPLINE_ENABLED
    public MovementSpline MovementSpline { get; set; } = new();

    // MOVEMENTFLAG_SWIMMING || MOVEMENTFLAG_FLYING || MOVEMENTFLAG2_ALWAYS_ALLOW_PITCHING
    public float? Pitch { get; set; }

    public Position Position { get; set; } = new();

    // SPEEDS
    public Dictionary<UnitMoveType, float> Speeds { get; set; } = new();

    // MOVEMENTFLAG_SPLINE_ELEVATION
    public float? SplineElevation { get; set; }

    public uint Time { get; set; }

    // MOVEMENTFLAG_ONTRANSPORT
    public ulong? TransportGuid { get; set; }

    public Position TransportPosition { get; set; } = new();

    public byte? TransportSeat { get; set; }

    public ulong? TransportTime { get; set; }

    public ulong? TransportTime2 { get; set; }
}