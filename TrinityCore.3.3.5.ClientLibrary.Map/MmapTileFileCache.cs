namespace TrinityCore._3._3._5.ClientLibrary.Map;

public class MmapTileFileCache
{
    private static MmapTileFileCache? _instance;


    private MmapTileFileCache()
    {
        Items = new Dictionary<string, MmapTileFileCacheItem>();
    }

    public static MmapTileFileCache Instance
    {
        get
        {
            if (_instance == null) _instance = new MmapTileFileCache();
            return _instance;
        }
    }

    private Dictionary<string, MmapTileFileCacheItem> Items { get; }

    public MmapTileFile? Get(string key)
    {
        lock (Items)
        {
            if (Items.ContainsKey(key))
            {
                Items[key].LastUsage = DateTime.Now;
                return Items[key].Tile;
            }

            string[] removeKeys = Items.Where(c => DateTime.Now.Subtract(c.Value.LastUsage).TotalMinutes > 5).Select(c => c.Key).ToArray();
            foreach (string removeKey in removeKeys) Items.Remove(removeKey);
        }

        return null;
    }

    public void Set(string key, MmapTileFile value)
    {
        lock (Items)
        {
            if (Items.ContainsKey(key))
            {
                Items[key].LastUsage = DateTime.Now;
                Items[key].Tile = value;
            }
            else
            {
                Items.Add(key, new MmapTileFileCacheItem { LastUsage = DateTime.Now, Tile = value });
            }
        }
    }
}

public class MmapTileFileCacheItem
{
    public DateTime LastUsage { get; set; }
    public required MmapTileFile Tile { get; set; }
}