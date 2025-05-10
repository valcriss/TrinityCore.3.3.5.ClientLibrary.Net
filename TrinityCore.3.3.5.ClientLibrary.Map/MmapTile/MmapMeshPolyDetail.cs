using BinaryReader = TrinityCore._3._3._5.ClientLibrary.Map.Tools.BinaryReader;

namespace TrinityCore._3._3._5.ClientLibrary.Map.MmapTile;

using BinaryReader = BinaryReader;

public class MmapMeshPolyDetail
{
    #region Public Methods

    public static MmapMeshPolyDetail LoadBinaryReader(BinaryReader reader)
    {
        MmapMeshPolyDetail polyDetail = new()
        {
            VertBase = reader.ReadUint(),
            TriBase = reader.ReadUint(),
            VertCount = reader.ReadByte(),
            TriCount = reader.ReadByte(),
            Padding = reader.ReadBytes(2)
        };

        return polyDetail;
    }

    #endregion Public Methods

    #region Public Properties

    public required byte[] Padding { get; set; }
    public uint TriBase { get; set; }
    public byte TriCount { get; set; }
    public uint VertBase { get; set; }
    public byte VertCount { get; set; }

    #endregion Public Properties
}