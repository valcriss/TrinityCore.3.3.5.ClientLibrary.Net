using BinaryReader = TrinityCore._3._3._5.ClientLibrary.Map.Tools.BinaryReader;

namespace TrinityCore._3._3._5.ClientLibrary.Map.MmapTile;

using BinaryReader = BinaryReader;

public class MmapMeshNode
{
    #region Public Methods

    public static MmapMeshNode LoadBinaryReader(BinaryReader reader)
    {
        MmapMeshNode node = new()
        {
            Bmin = reader.ReadUShorts(3),
            Bmax = reader.ReadUShorts(3),
            I = reader.ReadInt()
        };
        return node;
    }

    #endregion Public Methods

    #region Public Properties

    public required ushort[] Bmax { get; set; }
    public required ushort[] Bmin { get; set; }
    public int I { get; set; }

    #endregion Public Properties
}