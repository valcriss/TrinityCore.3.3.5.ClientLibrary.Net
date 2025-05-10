using TrinityCore._3._3._5.ClientLibrary.Shared.Math;

namespace TrinityCore._3._3._5.ClientLibrary.Map.MmapTile;

public class MmapMeshTriangle
{
    public MmapMeshTriangle()
    {
        Vertices = new ushort[3];
        Points = new Coord[3];
    }

    public ushort[] Vertices { get; set; }
    public Coord[] Points { get; set; }

    public Coord Center()
    {
        return new Coord(
            (Points[0].X + Points[1].X + Points[2].X) / 3,
            (Points[0].Y + Points[1].Y + Points[2].Y) / 3,
            (Points[0].Z + Points[1].Z + Points[2].Z) / 3
        );
    }

    public bool PointInTriangle(Coord position)
    {
        bool b1 = Sign(position, Points[0], Points[1]) < 0.0f;
        bool b2 = Sign(position, Points[1], Points[2]) < 0.0f;
        bool b3 = Sign(position, Points[2], Points[0]) < 0.0f;

        return b1 == b2 && b2 == b3;
    }

    private float Sign(Coord p1, Coord p2, Coord p3)
    {
        return (p1.X - p3.X) * (p2.Z - p3.Z) - (p2.X - p3.X) * (p1.Z - p3.Z);
    }
}