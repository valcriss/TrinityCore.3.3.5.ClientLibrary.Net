using TrinityCore._3._3._5.ClientLibrary.Shared.Math;
using BinaryReader = TrinityCore._3._3._5.ClientLibrary.Map.Tools.BinaryReader;

namespace TrinityCore._3._3._5.ClientLibrary.Map.MmapTile;

public class MmapMeshOffMeshConnection
{
    #region Public Methods

    public static MmapMeshOffMeshConnection LoadBinaryReader(BinaryReader reader)
    {
        MmapMeshOffMeshConnection offMeshConnection = new();
        offMeshConnection.Connection1 = reader.ReadCoord();
        offMeshConnection.Connection2 = reader.ReadCoord();

        offMeshConnection.Radius = reader.ReadFloat();
        offMeshConnection.Poly = reader.ReadUShort();
        offMeshConnection.Flags = reader.ReadByte();

        offMeshConnection.Side = reader.ReadByte();
        offMeshConnection.UserId = reader.ReadUint();

        return offMeshConnection;
    }

    #endregion Public Methods

    #region Public Properties

    public Coord Connection1 { get; set; }
    public Coord Connection2 { get; set; }
    public byte Flags { get; set; }
    public ushort Poly { get; set; }
    public float Radius { get; set; }
    public byte Side { get; set; }
    public uint UserId { get; set; }

    #endregion Public Properties
}