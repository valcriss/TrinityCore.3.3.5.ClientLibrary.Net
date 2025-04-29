using TrinityCore._3._3._5.ClientLibrary.Shared.Math;
using TrinityCore._3._3._5.ClientLibrary.WorldState.Enums;

namespace TrinityCore._3._3._5.ClientLibrary.WorldState.Models.Environment;

public class MonsterMoveData
{
    public ulong MoverGuid { get; set; }
    public Coord CurrentPosition { get; set; }
    public Coord Destination { get; set; }
    public uint MoveTime { get; set; }
    public MonsterMoveType MoveType { get; set; }
    public SplineFlags Flags { get; set; }
    public float? Orientation { get; set; }
    public Coord? FacingSpot { get; set; }
    public ulong? FacingTarget { get; set; }
    public List<Coord> WayPoints { get; set; } = new();
}