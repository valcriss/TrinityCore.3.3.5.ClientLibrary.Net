using TrinityCore._3._3._5.ClientLibrary.Map.MmapTile;
using TrinityCore._3._3._5.ClientLibrary.Shared.Math;

namespace TrinityCore._3._3._5.ClientLibrary.Map.Tools;

public static class MmapMeshPolyExtensions
{
    public static List<Point> ToPoints(this List<MmapMeshPoly> polies)
    {
        List<Point> points = [];
        foreach (MmapMeshPoly poly in polies)
        {
            Coord center = poly.Center();
            points.Add(new Point(center.Z, center.X, center.Y));
        }

        return points;
    }
}