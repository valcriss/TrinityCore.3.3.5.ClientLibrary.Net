using BinaryReader = TrinityCore._3._3._5.ClientLibrary.Map.Tools.BinaryReader;

namespace TrinityCore._3._3._5.ClientLibrary.Map.MmapTile;

public class MmapMeshHeader
{
    #region Public Methods

    public static MmapMeshHeader LoadFromBinaryReader(BinaryReader reader)
    {
        MmapMeshHeader header = new()
        {
            TileMagic = reader.ReadInt(),
            TileVersion = reader.ReadInt(),
            X = reader.ReadInt(),
            Y = reader.ReadInt(),
            Layer = reader.ReadInt(),
            UserId = reader.ReadUint(),
            PolyCount = reader.ReadInt(),
            VertCount = reader.ReadInt(),
            MaxLinkCount = reader.ReadInt(),
            DetailMeshCount = reader.ReadInt(),
            DetailVertCount = reader.ReadInt(),
            DetailTriCount = reader.ReadInt(),
            NodeCount = reader.ReadInt(),
            OffMeshConCount = reader.ReadInt(),
            OffMeshBase = reader.ReadInt(),
            WalkableHeight = reader.ReadFloat(),
            WalkableRadius = reader.ReadFloat(),
            WalkableClimb = reader.ReadFloat(),
            Bmin = reader.ReadFloats(3),
            Bmax = reader.ReadFloats(3),
            QuantFactor = reader.ReadFloat()
        };

        return header;
    }

    #endregion Public Methods

    #region Public Properties

    public required float[] Bmax { get; set; }
    public required float[] Bmin { get; set; }
    public int DetailMeshCount { get; set; }
    public int DetailTriCount { get; set; }
    public int DetailVertCount { get; set; }
    public int Layer { get; set; }
    public int MaxLinkCount { get; set; }
    public int NodeCount { get; set; }
    public int OffMeshBase { get; set; }
    public int OffMeshConCount { get; set; }
    public int PolyCount { get; set; }
    public float QuantFactor { get; set; }
    public int TileMagic { get; set; }
    public int TileVersion { get; set; }
    public uint UserId { get; set; }
    public int VertCount { get; set; }
    public float WalkableClimb { get; set; }
    public float WalkableHeight { get; set; }
    public float WalkableRadius { get; set; }
    public int X { get; set; }
    public int Y { get; set; }

    #endregion Public Properties
}