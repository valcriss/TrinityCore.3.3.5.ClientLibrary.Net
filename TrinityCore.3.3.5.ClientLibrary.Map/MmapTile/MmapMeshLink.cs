using BinaryReader = TrinityCore._3._3._5.ClientLibrary.Map.Tools.BinaryReader;

namespace TrinityCore._3._3._5.ClientLibrary.Map.MmapTile;

using BinaryReader = BinaryReader;

public class MmapMeshLink
{
    #region Public Methods

    public static MmapMeshLink LoadBinaryReader(BinaryReader reader)
    {
        MmapMeshLink link = new();
        link.Reference = reader.ReadInt64();
        link.Next = reader.ReadUint();
        link.Edge = reader.ReadByte();
        link.Side = reader.ReadByte();
        link.Bmin = reader.ReadByte();
        link.Bmax = reader.ReadByte();
        return link;
    }

    #endregion Public Methods

    #region Public Properties

    public byte Bmax { get; set; }
    public byte Bmin { get; set; }
    public byte Edge { get; set; }
    public uint Next { get; set; }
    public long Reference { get; set; }
    public byte Side { get; set; }

    #endregion Public Properties
}