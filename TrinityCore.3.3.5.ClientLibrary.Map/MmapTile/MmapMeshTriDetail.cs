using BinaryReader = TrinityCore._3._3._5.ClientLibrary.Map.Tools.BinaryReader;

namespace TrinityCore._3._3._5.ClientLibrary.Map.MmapTile;

using BinaryReader = BinaryReader;

public class MmapMeshTriDetail
{
    #region Public Properties

    public required byte[] Tri { get; set; }

    #endregion Public Properties

    #region Public Methods

    public static MmapMeshTriDetail LoadBinaryReader(BinaryReader reader)
    {
        MmapMeshTriDetail triDetail = new()
        {
            Tri = reader.ReadBytes(4)
        };
        return triDetail;
    }

    #endregion Public Methods
}