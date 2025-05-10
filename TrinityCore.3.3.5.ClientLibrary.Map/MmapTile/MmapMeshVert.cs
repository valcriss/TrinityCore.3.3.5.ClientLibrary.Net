using TrinityCore._3._3._5.ClientLibrary.Shared.Math;
using BinaryReader = TrinityCore._3._3._5.ClientLibrary.Map.Tools.BinaryReader;

namespace TrinityCore._3._3._5.ClientLibrary.Map.MmapTile;

public class MmapMeshVert
{
    #region Public Methods

    public static MmapMeshVert LoadBinaryReader(BinaryReader reader)
    {
        MmapMeshVert vert = new();
        vert.X = reader.ReadFloat();
        vert.Y = reader.ReadFloat();
        vert.Z = reader.ReadFloat();
        vert.Coord = new Coord(vert.X, vert.Y, vert.Z);
        return vert;
    }

    #endregion Public Methods

    #region Public Properties

    public float X { get; set; }
    public float Y { get; set; }
    public float Z { get; set; }
    public Coord Coord { get; set; }

    #endregion Public Properties
}