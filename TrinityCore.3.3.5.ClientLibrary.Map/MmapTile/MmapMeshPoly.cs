using TrinityCore._3._3._5.ClientLibrary.Shared.Math;
using BinaryReader = TrinityCore._3._3._5.ClientLibrary.Map.Tools.BinaryReader;

namespace TrinityCore._3._3._5.ClientLibrary.Map.MmapTile;

public class MmapMeshPoly
{
    #region Public Fields

    private const uint DT_NULL_LINK = 0xffffffff;

    #endregion Public Fields

    #region Public Properties

    private const int DT_SALT_BITS = 12;
    private const int DT_TILE_BITS = 21;
    private const int DT_POLY_BITS = 31;

    public byte AreaAndType { get; set; }
    public uint FirstLink { get; set; }
    public ushort Flags { get; set; }
    public required ushort[] Neis { get; set; }
    public byte VertCount { get; set; }
    public required ushort[] Verts { get; set; }
    public required MmapMeshTriangle[] Triangles { get; set; }

    public string Key => Center().X + "|" + Center().Y + "|" + Center().Z;

    #endregion Public Properties

    #region Public Methods

    private Coord? _center;

    public Coord Center()
    {
        if (_center == null)
        {
            float x = Triangles.Sum(c => c.Center().X) / Triangles.Length;
            float y = Triangles.Sum(c => c.Center().Y) / Triangles.Length;
            float z = Triangles.Sum(c => c.Center().Z) / Triangles.Length;
            _center = new Coord(x, y, z);
        }

        return _center.Value;
    }

    public List<MmapMeshPoly> GetNeighbors(MmapTileFile? tile)
    {
        if (tile == null) return new List<MmapMeshPoly>();
        if (FirstLink == DT_NULL_LINK) return new List<MmapMeshPoly>();
        if (tile.Mesh == null) return new List<MmapMeshPoly>();
        List<MmapMeshPoly> results = [];
        for (uint i = FirstLink; i != DT_NULL_LINK; i = tile.Mesh.Links[(int)i].Next)
        {
            long neighbourRef = tile.Mesh.Links[(int)i].Reference;
            uint polyIndex = GetPolyRefIndex(neighbourRef);
            MmapMeshPoly nextPoly = tile.Mesh.Polys[(int)polyIndex];
            results.Add(nextPoly);
        }

        return results;
    }

    private uint GetPolyRefIndex(long @ref)
    {
        uint saltMask = ((uint)1 << DT_SALT_BITS) - 1;
        uint tileMask = ((uint)1 << DT_TILE_BITS) - 1;
        uint polyMask = ((uint)1 << DT_POLY_BITS) - 1;
        uint salt = (uint)((@ref >> (DT_POLY_BITS + DT_TILE_BITS)) & saltMask);
        uint it = (uint)((@ref >> DT_POLY_BITS) & tileMask);
        uint ip = (uint)(@ref & polyMask);
        return ip;
    }

    public static MmapMeshPoly LoadBinaryReader(MmapMesh mesh, BinaryReader reader)
    {
        MmapMeshPoly poly = new()
        {
            FirstLink = reader.ReadUint(),
            Verts = reader.ReadUShorts(6),
            Neis = reader.ReadUShorts(6),
            Flags = reader.ReadUShort(),
            VertCount = reader.ReadByte(),
            AreaAndType = reader.ReadByte(),
            Triangles = []
        };


        switch (poly.VertCount)
        {
            case 3:
                poly.Triangles = new MmapMeshTriangle[1];
                poly.Triangles[0] = new MmapMeshTriangle
                {
                    Vertices = [poly.Verts[0], poly.Verts[1], poly.Verts[2]],
                    Points = [mesh.Verts[poly.Verts[0]].Coord, mesh.Verts[poly.Verts[1]].Coord, mesh.Verts[poly.Verts[2]].Coord]
                };
                break;
            case 4:
                poly.Triangles = new MmapMeshTriangle[2];
                poly.Triangles[0] = new MmapMeshTriangle
                {
                    Vertices = [poly.Verts[0], poly.Verts[1], poly.Verts[2]],
                    Points = [mesh.Verts[poly.Verts[0]].Coord, mesh.Verts[poly.Verts[1]].Coord, mesh.Verts[poly.Verts[2]].Coord]
                };
                poly.Triangles[1] = new MmapMeshTriangle
                {
                    Vertices = [poly.Verts[0], poly.Verts[2], poly.Verts[3]],
                    Points = [mesh.Verts[poly.Verts[0]].Coord, mesh.Verts[poly.Verts[2]].Coord, mesh.Verts[poly.Verts[3]].Coord]
                };
                break;
            case 5:
                poly.Triangles = new MmapMeshTriangle[3];
                poly.Triangles[0] = new MmapMeshTriangle
                {
                    Vertices = [poly.Verts[0], poly.Verts[1], poly.Verts[2]],
                    Points = [mesh.Verts[poly.Verts[0]].Coord, mesh.Verts[poly.Verts[1]].Coord, mesh.Verts[poly.Verts[2]].Coord]
                };
                poly.Triangles[1] = new MmapMeshTriangle
                {
                    Vertices = [poly.Verts[0], poly.Verts[2], poly.Verts[3]],
                    Points = [mesh.Verts[poly.Verts[0]].Coord, mesh.Verts[poly.Verts[2]].Coord, mesh.Verts[poly.Verts[3]].Coord]
                };
                poly.Triangles[2] = new MmapMeshTriangle
                {
                    Vertices = [poly.Verts[0], poly.Verts[3], poly.Verts[4]],
                    Points = [mesh.Verts[poly.Verts[0]].Coord, mesh.Verts[poly.Verts[3]].Coord, mesh.Verts[poly.Verts[4]].Coord]
                };
                break;
            case 6:
                poly.Triangles = new MmapMeshTriangle[4];
                poly.Triangles[0] = new MmapMeshTriangle
                {
                    Vertices = [poly.Verts[0], poly.Verts[1], poly.Verts[2]],
                    Points = [mesh.Verts[poly.Verts[0]].Coord, mesh.Verts[poly.Verts[1]].Coord, mesh.Verts[poly.Verts[2]].Coord]
                };
                poly.Triangles[1] = new MmapMeshTriangle
                {
                    Vertices = [poly.Verts[0], poly.Verts[2], poly.Verts[3]],
                    Points = [mesh.Verts[poly.Verts[0]].Coord, mesh.Verts[poly.Verts[2]].Coord, mesh.Verts[poly.Verts[3]].Coord]
                };
                poly.Triangles[2] = new MmapMeshTriangle
                {
                    Vertices = [poly.Verts[0], poly.Verts[3], poly.Verts[4]],
                    Points = [mesh.Verts[poly.Verts[0]].Coord, mesh.Verts[poly.Verts[3]].Coord, mesh.Verts[poly.Verts[4]].Coord]
                };
                poly.Triangles[3] = new MmapMeshTriangle
                {
                    Vertices = [poly.Verts[5], poly.Verts[0], poly.Verts[4]],
                    Points = [mesh.Verts[poly.Verts[5]].Coord, mesh.Verts[poly.Verts[0]].Coord, mesh.Verts[poly.Verts[4]].Coord]
                };
                break;
        }


        return poly;
    }

    #endregion Public Methods
}