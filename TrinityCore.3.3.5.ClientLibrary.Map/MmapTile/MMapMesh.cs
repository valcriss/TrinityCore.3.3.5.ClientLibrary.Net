using BinaryReader = TrinityCore._3._3._5.ClientLibrary.Map.Tools.BinaryReader;

namespace TrinityCore._3._3._5.ClientLibrary.Map.MmapTile;

public class MmapMesh
{
    #region Public Constructors

    public MmapMesh()
    {
        Verts = [];
        Polys = [];
        Links = [];
        PolyDetails = [];
        VertDetails = [];
        TriDetails = [];
        Tree = [];
        OffMeshConnections = [];
    }

    #endregion Public Constructors

    #region Public Methods

    public static MmapMesh FromBinaryReader(BinaryReader reader)
    {
        MmapMesh mesh = new();

        mesh.Header = MmapMeshHeader.LoadFromBinaryReader(reader);

        for (int i = 0; i < mesh.Header.VertCount; i++) mesh.Verts.Add(MmapMeshVert.LoadBinaryReader(reader));
        for (int i = 0; i < mesh.Header.PolyCount; i++) mesh.Polys.Add(MmapMeshPoly.LoadBinaryReader(mesh, reader));
        for (int i = 0; i < mesh.Header.MaxLinkCount; i++) mesh.Links.Add(MmapMeshLink.LoadBinaryReader(reader));
        for (int i = 0; i < mesh.Header.DetailMeshCount; i++) mesh.PolyDetails.Add(MmapMeshPolyDetail.LoadBinaryReader(reader));
        for (int i = 0; i < mesh.Header.DetailVertCount; i++) mesh.VertDetails.Add(MmapMeshVert.LoadBinaryReader(reader));
        for (int i = 0; i < mesh.Header.DetailTriCount; i++) mesh.TriDetails.Add(MmapMeshTriDetail.LoadBinaryReader(reader));
        for (int i = 0; i < mesh.Header.NodeCount; i++) mesh.Tree.Add(MmapMeshNode.LoadBinaryReader(reader));
        for (int i = 0; i < mesh.Header.OffMeshConCount; i++) mesh.OffMeshConnections.Add(MmapMeshOffMeshConnection.LoadBinaryReader(reader));

        return mesh;
    }

    #endregion Public Methods

    #region Public Properties

    public MmapMeshHeader? Header { get; set; }
    public List<MmapMeshLink> Links { get; set; }
    public List<MmapMeshOffMeshConnection> OffMeshConnections { get; set; }
    public List<MmapMeshPolyDetail> PolyDetails { get; set; }
    public List<MmapMeshPoly> Polys { get; set; }
    public List<MmapMeshNode> Tree { get; set; }
    public List<MmapMeshTriDetail> TriDetails { get; set; }
    public List<MmapMeshVert> VertDetails { get; set; }
    public List<MmapMeshVert> Verts { get; set; }

    #endregion Public Properties
}