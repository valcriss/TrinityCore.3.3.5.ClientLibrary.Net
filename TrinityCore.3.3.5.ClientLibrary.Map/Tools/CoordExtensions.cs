using TrinityCore._3._3._5.ClientLibrary.Shared.Math;

namespace TrinityCore._3._3._5.ClientLibrary.Map.Tools;

public static class CoordExtensions
{
    public static Coord ToFileFormat(this Coord position)
    {
        return new Coord(position.Y, position.Z, position.X);
    }
}