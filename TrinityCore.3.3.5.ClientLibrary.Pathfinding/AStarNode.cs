using TrinityCore._3._3._5.ClientLibrary.Map.MmapTile;

namespace TrinityCore._3._3._5.ClientLibrary.Pathfinding;

public class AStarNode : IComparable<AStarNode>
{
    public AStarNode(MmapMeshPoly poly, AStarNode? parent, float g, float h)
    {
        Poly = poly;
        Parent = parent;
        G = g;
        H = h;
    }

    public MmapMeshPoly Poly { get; }
    public AStarNode? Parent { get; }
    public float G { get; } // Coût réel depuis le départ
    public float H { get; } // Heuristique (estimation jusqu'à l'arrivée)
    public float F => G + H; // Coût total estimé

    public int CompareTo(AStarNode? other)
    {
        if (other == null) return -1;
        return F.CompareTo(other.F);
    }
}