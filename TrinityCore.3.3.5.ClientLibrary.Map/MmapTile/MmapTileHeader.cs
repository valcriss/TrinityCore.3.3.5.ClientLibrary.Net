using TrinityCore._3._3._5.ClientLibrary.Map.Exceptions;
using StringExtensions = TrinityCore._3._3._5.ClientLibrary.Map.Tools.StringExtensions;
using BinaryReader = TrinityCore._3._3._5.ClientLibrary.Map.Tools.BinaryReader;

namespace TrinityCore._3._3._5.ClientLibrary.Map.MmapTile;

public class MmapTileHeader
{
    #region Public Methods

    public static MmapTileHeader FromBinaryReader(BinaryReader reader)
    {
        if (reader.Length < Constants.MMAP_TILE_FILE_HEADER_SIZE) throw new FileBadLengthException(reader.Length, Constants.MMAP_TILE_FILE_HEADER_SIZE);

        MmapTileHeader header = new()
        {
            TileMagic = reader.ReadUint(),
            NavMeshVersion = reader.ReadUint(),
            MMapVersion = reader.ReadUint(),
            Size = reader.ReadUint(),
            UseLiquids = reader.ReadByte(),
            Padding = reader.ReadBytes(3)
        };

        return header;
    }

    #endregion Public Methods

    #region Private Methods

    private static void CheckFile(string file)
    {
        if (!StringExtensions.Exists(file)) throw new FileNotFoundException();

        if (!StringExtensions.CheckExtension(file, Constants.MMAP_TILE_FILE_EXTENSION)) throw new FileBadExtensionException(Constants.MMAP_TILE_FILE_EXTENSION);

        if (!StringExtensions.CheckRegExp(file, Constants.MMAP_TILE_FILE_CHECK_REGEXP)) throw new FileBadFilenamePatternException(Constants.MMAP_TILE_FILE_EXTENSION, Constants.MMAP_TILE_FILE_CHECK_REGEXP);
    }

    #endregion Private Methods

    #region Public Properties

    public uint MMapVersion { get; set; }
    public uint NavMeshVersion { get; set; }
    public required byte[] Padding { get; set; }
    public uint Size { get; set; }
    public uint TileMagic { get; set; }
    public byte UseLiquids { get; set; }

    #endregion Public Properties
}