using TrinityCore._3._3._5.ClientLibrary.Map.Exceptions;

namespace TrinityCore._3._3._5.ClientLibrary.Map;

public class MmapFilesCollection
{
    public MmapFilesCollection()
    {
        MmapFiles = [];
    }

    public List<MmapFile> MmapFiles { get; set; }

    public MmapFile? GetMap(int mapId)
    {
        return MmapFiles.FirstOrDefault(c => c.MapId == mapId);
    }

    public static MmapFilesCollection Load(string mmapsDirectory)
    {
        MmapFilesCollection collection = new();

        if (!Directory.Exists(mmapsDirectory) || !File.Exists(Path.Combine(mmapsDirectory, "000.mmap"))) throw new DirectoryInvalidException();

        foreach (string file in Directory.GetFiles(mmapsDirectory, "*." + Constants.MMAP_FILE_EXTENSION)) collection.MmapFiles.Add(MmapFile.Load(file));

        return collection;
    }
}