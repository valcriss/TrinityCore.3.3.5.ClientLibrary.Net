using System.Diagnostics;
using TrinityCore._3._3._5.ClientLibrary.Map;
using TrinityCore._3._3._5.ClientLibrary.Map.MmapTile;
using TrinityCore._3._3._5.ClientLibrary.Map.Tools;
using TrinityCore._3._3._5.ClientLibrary.Shared.Math;

namespace TrinityCore._3._3._5.ClientLibrary.Pathfinding;

public class PathFinding
{
    public PathFinding(MmapFilesCollection collection)
    {
        Collection = collection;
    }

    private MmapFilesCollection Collection { get; }

    public Path? FindPath(int mapId, Coord start, Coord end, float speed, int maxPathLength = 50)
    {
        MmapFile? mmap = Collection.GetMap(mapId);
        MmapTileFile? startTile = mmap?.GetMmapTileFileFromCoord(start);
        if (startTile == null) return null;
        MmapTileFile? endTile = mmap?.GetMmapTileFileFromCoord(end);
        if (endTile == null) return null;

        if (startTile.Key != endTile.Key) return null;

        MmapMeshPoly? startPoly = startTile.GetNearestPoly(start);
        if (startPoly == null) return null;
        MmapMeshPoly? endPoly = endTile.GetNearestPoly(end);
        if (endPoly == null) return null;

        List<string> done = new();
        List<MmapMeshPoly> mmapMeshPolies = [startPoly];
        Queue<List<MmapMeshPoly>> queue = new();
        queue.Enqueue(mmapMeshPolies);

        DateTime s = DateTime.Now;

        while (queue.Count > 0)
        {
            List<MmapMeshPoly> current = queue.Dequeue();
            MmapMeshPoly last = current[^1];

            foreach (MmapMeshPoly poly in last.GetNeighbors(startTile).OrderBy(c => (c.Center() - end).Length()))
            {
                if (done.Contains(poly.Key)) continue;

                if (poly.Key == endPoly.Key)
                {
                    current.Add(poly);
                    Debug.WriteLine("Duration :" + DateTime.Now.Subtract(s).TotalMilliseconds);
                    List<Point> points = current.ToPoints();
                    points.Add(new Point(end.X, end.Y, end.Z));
                    return new Path(points, speed, mapId);
                }

                done.Add(poly.Key);

                if (current.Count >= maxPathLength) continue;
                List<MmapMeshPoly> clone = current.ToArray().ToList();
                clone.Add(poly);
                queue.Enqueue(clone);
            }
        }

        return null;
    }
}