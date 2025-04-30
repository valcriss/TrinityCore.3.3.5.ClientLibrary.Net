using TrinityCore._3._3._5.ClientLibrary.Shared.Math;

namespace TrinityCore._3._3._5.ClientLibrary.WorldState.Models.Environment;

public class SpellExtraTarget
{
    public Coord Position { get; set; } = new();
    public ulong TargetGUID { get; set; }
}