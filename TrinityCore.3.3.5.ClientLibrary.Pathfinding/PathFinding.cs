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
        // Débuter le chronométrage
        DateTime s = DateTime.Now;
        MmapFile? mmap = Collection.GetMap(mapId);
        if (mmap == null) return null;
        MmapTileFile? startTile = mmap?.GetMmapTileFileFromCoord(start);
        if (startTile == null) return null;
        MmapTileFile? endTile = mmap?.GetMmapTileFileFromCoord(end);
        if (endTile == null) return null;
        List<MmapTileFile> workingTiles = new();
        if (startTile.Key == endTile.Key)
        {
            workingTiles = new List<MmapTileFile> { startTile };
        }
        else
        {
            int stepX = Math.Sign(endTile.TileX - startTile.TileX);
            int stepY = Math.Sign(endTile.TileY - startTile.TileY);
            for (int x = startTile.TileX; x != endTile.TileX + stepX; x += stepX)
            for (int y = startTile.TileY; y != endTile.TileY + stepY; y += stepY)
            {
                string key = mmap.GetMmapTileKeyFromValues(x, y);
                MmapTileFile? tile = mmap.GetMmapTileFileFromKey(key);
                if (tile != null)
                    workingTiles.Add(tile);
            }
        }

        MmapMeshPoly? startPoly = startTile.GetNearestPoly(start);
        if (startPoly == null) return null;
        MmapMeshPoly? endPoly = endTile.GetNearestPoly(end);
        if (endPoly == null) return null;

        // Liste des polygones déjà traités (liste fermée)
        HashSet<string> closedSet = new();

        // Liste prioritaire des nœuds à explorer (liste ouverte)
        PriorityQueue<AStarNode, float> openQueue = new();

        // Dictionnaire pour suivre les nœuds par leur clé poly
        Dictionary<string, AStarNode> nodeMap = new();

        // Créer et ajouter le nœud de départ
        float heuristic = CalculateHeuristic(startPoly.Center(), end);
        AStarNode startNode = new(startPoly, null, 0, heuristic);
        openQueue.Enqueue(startNode, startNode.F);
        nodeMap[startPoly.Key] = startNode;

        while (openQueue.Count > 0)
        {
            // Obtenir le nœud avec le coût F le plus bas
            AStarNode currentNode = openQueue.Dequeue();

            // Si nous avons atteint la destination
            if (currentNode.Poly.Key == endPoly.Key)
            {
                Debug.WriteLine("Duration :" + DateTime.Now.Subtract(s).TotalMilliseconds);

                // Reconstruire le chemin
                List<MmapMeshPoly> path = ReconstructPath(currentNode);
                List<Point> points = path.ToPoints();
                points.Add(new Point(end.X, end.Y, end.Z));
                return new Path(points, speed, mapId);
            }

            // Ajouter le nœud actuel à la liste fermée
            closedSet.Add(currentNode.Poly.Key);

            // Vérifier la limite de longueur du chemin
            if (GetPathLength(currentNode) >= maxPathLength)
                continue;

            // Explorer les voisins
            foreach (NeighbourTileMeshPoly neighbor in currentNode.Poly.GetNeighbors(workingTiles))
            {
                // Ignorer les voisins déjà traités
                if (closedSet.Contains(neighbor.Poly.Key))
                    continue;

                // Calculer le nouveau coût G
                float newG = currentNode.G + CalculateDistance(currentNode.Poly.Center(), neighbor.Poly.Center());

                // Si ce voisin est déjà dans la file avec un meilleur coût, ignorer
                if (nodeMap.TryGetValue(neighbor.Poly.Key, out AStarNode? existingNode) && newG >= existingNode.G)
                    continue;

                // Créer un nouveau nœud pour ce voisin
                heuristic = CalculateHeuristic(neighbor.Poly.Center(), end);
                AStarNode neighborNode = new(neighbor.Poly, currentNode, newG, heuristic);

                // Ajouter ou mettre à jour le nœud dans la file
                nodeMap[neighbor.Poly.Key] = neighborNode;
                openQueue.Enqueue(neighborNode, neighborNode.F);
            }
        }

        // Aucun chemin trouvé
        return null;
    }

    // Calculer l'heuristique (distance estimée jusqu'à la destination)
    private float CalculateHeuristic(Coord current, Coord end)
    {
        return (current - end).Length();
    }

    // Calculer la distance entre deux points
    private float CalculateDistance(Coord a, Coord b)
    {
        return (a - b).Length();
    }

    // Reconstruire le chemin à partir du nœud final
    private List<MmapMeshPoly> ReconstructPath(AStarNode? node)
    {
        List<MmapMeshPoly> path = new();

        // Suivre les parents pour reconstruire le chemin
        while (node != null)
        {
            path.Add(node.Poly);
            node = node.Parent;
        }

        // Inverser le chemin pour avoir le début au début
        path.Reverse();
        return path;
    }

    // Calculer la longueur du chemin jusqu'à ce nœud
    private int GetPathLength(AStarNode? node)
    {
        int length = 0;
        while (node != null)
        {
            length++;
            node = node.Parent;
        }

        return length;
    }
}