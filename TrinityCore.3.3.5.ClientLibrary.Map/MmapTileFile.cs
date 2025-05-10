using System.Diagnostics;
using TrinityCore._3._3._5.ClientLibrary.Map.Exceptions;
using TrinityCore._3._3._5.ClientLibrary.Map.MmapTile;
using TrinityCore._3._3._5.ClientLibrary.Map.Tools;
using TrinityCore._3._3._5.ClientLibrary.Shared.Math;
using BinaryReader = TrinityCore._3._3._5.ClientLibrary.Map.Tools.BinaryReader;

namespace TrinityCore._3._3._5.ClientLibrary.Map;

public class MmapTileFile
{
    #region Private Constructors

    private MmapTileFile(string file, int mapId, int tileX, int tileY)
    {
        File = file;
        Key = Path.GetFileNameWithoutExtension(file);
        MapId = mapId;
        TileX = tileX;
        TileY = tileY;
    }

    #endregion Private Constructors

    #region Public Properties

    public string File { get; set; }

    public string Key { get; set; }

    public MmapTileHeader? Header
    {
        get
        {
            if (!_loaded)
                LoadOnDemand();
            return _mmapTileHeader;
        }
    }

    public int MapId { get; set; }

    public MmapMesh? Mesh
    {
        get
        {
            if (!_loaded)
                LoadOnDemand();
            return _mmapMesh;
        }
    }

    public int TileX { get; set; }
    public int TileY { get; set; }

    internal float? GetHeightAtPosition(Coord position)
    {
        position = position.ToFileFormat();
        if (Mesh == null) return null;
        MmapMeshVert? vert = Mesh.Verts.OrderBy(c => (c.Coord - position).Length()).FirstOrDefault();
        if (vert == null) return null;
        return vert.Y;
    }

    #endregion Public Properties

    #region Private Fields

    private bool _loaded;

    private MmapMesh? _mmapMesh;
    private MmapTileHeader? _mmapTileHeader;

    #endregion Private Fields

    #region Public Methods

    public static MmapTileFile Load(string file)
    {
        CheckFile(file);

        int mapId = GetMapIdFromFilename(file);
        int tileX = GetTileXFromFilename(file);
        int tileY = GetTileYFromFilename(file);

        return new MmapTileFile(file, mapId, tileX, tileY);
    }

    public MmapMeshPoly? GetNearestPoly(Coord position)
    {
        position = position.ToFileFormat();
        if (Mesh == null) return null;
        MmapMeshPoly? poly = Mesh.Polys.FirstOrDefault(c => c.Triangles.Any(d => d.PointInTriangle(position)));
        if (poly == null) poly = Mesh.Polys.OrderBy(c => c.Triangles.Min(d => Coord.Distance(position, d.Center()))).FirstOrDefault();
        return poly;
    }

    #endregion Public Methods

    #region Private Methods

    private static void CheckFile(string file)
    {
        if (!file.Exists()) throw new FileNotFoundException();

        if (!file.CheckExtension(Constants.MMAP_TILE_FILE_EXTENSION)) throw new FileBadExtensionException(Constants.MMAP_TILE_FILE_EXTENSION);

        if (!file.CheckRegExp(Constants.MMAP_TILE_FILE_CHECK_REGEXP)) throw new FileBadFilenamePatternException(Constants.MMAP_TILE_FILE_EXTENSION, Constants.MMAP_TILE_FILE_CHECK_REGEXP);
    }

    private static int GetMapIdFromFilename(string file)
    {
        try
        {
            return int.Parse(Path.GetFileNameWithoutExtension(file).Substring(0, 3));
        }
        catch (Exception)
        {
            throw new FileBadFilenamePatternException(Constants.MMAP_TILE_FILE_EXTENSION, Constants.MMAP_TILE_FILE_CHECK_REGEXP);
        }
    }

    private static int GetTileXFromFilename(string file)
    {
        try
        {
            return int.Parse(Path.GetFileNameWithoutExtension(file).Substring(3, 2));
        }
        catch (Exception)
        {
            throw new FileBadFilenamePatternException(Constants.MMAP_TILE_FILE_EXTENSION, Constants.MMAP_TILE_FILE_CHECK_REGEXP);
        }
    }

    private static int GetTileYFromFilename(string file)
    {
        try
        {
            return int.Parse(Path.GetFileNameWithoutExtension(file).Substring(5, 2));
        }
        catch (Exception)
        {
            throw new FileBadFilenamePatternException(Constants.MMAP_TILE_FILE_EXTENSION, Constants.MMAP_TILE_FILE_CHECK_REGEXP);
        }
    }

    private void LoadOnDemand()
    {
        DateTime start = DateTime.Now;
        BinaryReader? reader = BinaryReader.FromFile(File);
        if (reader == null) throw new FileNotFoundException();
        _mmapTileHeader = MmapTileHeader.FromBinaryReader(reader);
        _mmapMesh = MmapMesh.FromBinaryReader(reader);
        if (reader.BytesLeft > 0) throw new Exception("Bytes left");
        _loaded = true;
        Debug.WriteLine("LoadOnDemand [" + Path.GetFileName(File) + "] Duration :" + DateTime.Now.Subtract(start).TotalMilliseconds + " ms");
    }

    #endregion Private Methods
}