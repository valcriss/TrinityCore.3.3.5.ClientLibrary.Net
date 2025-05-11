using TrinityCore._3._3._5.ClientLibrary.Map.Exceptions;
using TrinityCore._3._3._5.ClientLibrary.Shared.Math;
using StringExtensions = TrinityCore._3._3._5.ClientLibrary.Map.Tools.StringExtensions;
using BinaryReader = TrinityCore._3._3._5.ClientLibrary.Map.Tools.BinaryReader;

namespace TrinityCore._3._3._5.ClientLibrary.Map;

public class MmapFile
{
    #region Private Constructors

    private MmapFile(string file, int mapId, Coord origin, float tileWidth, float tileHeight, uint maxTiles, uint maxPoly)
    {
        File = file;
        MapId = mapId;
        Origin = origin;
        TileWidth = tileWidth;
        TileHeight = tileHeight;
        MaxTiles = maxTiles;
        MaxPoly = maxPoly;
    }

    #endregion Private Constructors

    #region Public Properties

    public string File { get; set; }
    public int MapId { get; set; }
    public uint MaxPoly { get; set; }
    public uint MaxTiles { get; set; }
    public Coord Origin { get; set; }
    public float TileHeight { get; set; }
    public float TileWidth { get; set; }

    #endregion Public Properties

    #region Public Methods

    /// <summary>
    /// </summary>
    /// <param name="file"></param>
    /// <returns></returns>
    /// <exception cref="FileBadExtensionException"></exception>
    public static MmapFile Load(string file)
    {
        CheckFile(file);

        int mapId = GetMapIdFromFilename(file);

        BinaryReader? reader = BinaryReader.FromFile(file);

        if (reader == null) throw new FileNotFoundException("File not found", file);

        if (reader.Length != Constants.MMAP_FILE_EXPECTED_LENGTH) throw new FileBadLengthException(reader.Length, Constants.MMAP_FILE_EXPECTED_LENGTH);

        Coord origin = reader.ReadCoord();
        float tileWidth = reader.ReadFloat();
        float tileHeight = reader.ReadFloat();
        uint maxTiles = reader.ReadUint();
        uint maxPoly = reader.ReadUint();

        return new MmapFile(file, mapId, origin, tileWidth, tileHeight, maxTiles, maxPoly);
    }

    public List<MmapTileFile> GetMmapTiles()
    {
        List<MmapTileFile> list = [];

        foreach (string file in Directory.GetFiles(Path.GetDirectoryName(File) ?? string.Empty, MapId.ToString("000") + "*." + Constants.MMAP_TILE_FILE_EXTENSION)) list.Add(MmapTileFile.Load(file));

        return list;
    }

    public string GetMmapTileKeyFromCoord(float x, float y, float z)
    {
        return GetMmapTileKeyFromCoord(new Coord(x, y, z));
    }

    public string GetMmapTileKeyFromCoord(Coord position)
    {
        int tileX = (int)(32 - position.X / TileWidth);
        int tileY = (int)(32 - position.Y / TileHeight);
        return MapId.ToString("000") + tileX.ToString("00") + tileY.ToString("00");
    }

    public MmapTileFile? GetMmapTileFileFromCoord(float x, float y, float z)
    {
        return GetMmapTileFileFromCoord(new Coord(x, y, z));
    }

    public MmapTileFile? GetMmapTileFileFromCoord(Coord position)
    {
        string key = GetMmapTileKeyFromCoord(position);
        return GetMmapTileFileFromKey(key);
    }

    public MmapTileFile? GetMmapTileFileFromKey(string key)
    {
        MmapTileFile? fromCache = MmapTileFileCache.Instance.Get(key);
        if (fromCache != null) return fromCache;
        string filename = key + "." + Constants.MMAP_TILE_FILE_EXTENSION;
        string file = Path.Combine(Path.GetDirectoryName(File) ?? string.Empty, filename);
        if (System.IO.File.Exists(file))
        {
            MmapTileFile tile = MmapTileFile.Load(file);
            MmapTileFileCache.Instance.Set(key, tile);
            return tile;
        }

        return null;
    }

    #endregion Public Methods

    #region Private Methods

    private static void CheckFile(string file)
    {
        if (!StringExtensions.Exists(file)) throw new FileNotFoundException();

        if (!StringExtensions.CheckExtension(file, Constants.MMAP_FILE_EXTENSION)) throw new FileBadExtensionException(Constants.MMAP_FILE_EXTENSION);

        if (!StringExtensions.CheckRegExp(file, Constants.MMAP_FILE_CHECK_REGEXP)) throw new FileBadFilenamePatternException(Constants.MMAP_FILE_EXTENSION, Constants.MMAP_FILE_CHECK_REGEXP);
    }

    private static int GetMapIdFromFilename(string file)
    {
        try
        {
            return int.Parse(Path.GetFileNameWithoutExtension(file));
        }
        catch (Exception)
        {
            throw new FileBadFilenamePatternException(Constants.MMAP_FILE_EXTENSION, Constants.MMAP_FILE_CHECK_REGEXP);
        }
    }

    #endregion Private Methods
}