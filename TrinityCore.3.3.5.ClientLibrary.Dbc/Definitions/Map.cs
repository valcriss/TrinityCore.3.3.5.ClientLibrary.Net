using TrinityCore._3._3._5.ClientLibrary.Dbc.Attributes;
using TrinityCore._3._3._5.ClientLibrary.Dbc.Enums;

namespace TrinityCore._3._3._5.ClientLibrary.Dbc.Definitions;

[DbcFile("Map.dbc")]
public class Map : DbcFile
{
    [DbcColumn(0, DbcColumnDataType.Int32)]
    public int Id { get; set; }

    [DbcColumn(1, DbcColumnDataType.StringRef)]
    public string? Directory { get; set; }

    [DbcColumn(2, DbcColumnDataType.Int32)]
    public int InstanceType { get; set; }

    [DbcColumn(3, DbcColumnDataType.Int32)]
    public int Flags { get; set; }

    [DbcColumn(4, DbcColumnDataType.Int32)]
    public int PVP { get; set; }

    [DbcColumn(5, DbcColumnDataType.Loc)]
    public string? MapNameLang { get; set; }

    [DbcColumn(6, DbcColumnDataType.Int32)]
    public int AreaTableId { get; set; }

    [DbcColumn(7, DbcColumnDataType.Loc)]
    public string? MapDescription0 { get; set; }

    [DbcColumn(8, DbcColumnDataType.Loc)]
    public string? MapDescription1 { get; set; }

    [DbcColumn(9, DbcColumnDataType.Int32)]
    public int LoadingScreenId { get; set; }

    [DbcColumn(10, DbcColumnDataType.Float)]
    public float MinimapIconScale { get; set; }

    [DbcColumn(11, DbcColumnDataType.Int32)]
    public int CorpseMapId { get; set; }

    [DbcColumn(12, DbcColumnDataType.ArrayOfFloat, 2)]
    public float[]? Corpse { get; set; }

    [DbcColumn(13, DbcColumnDataType.Int32)]
    public int TimeOfDayOverride { get; set; }

    [DbcColumn(14, DbcColumnDataType.Int32)]
    public int ExpansionId { get; set; }

    [DbcColumn(15, DbcColumnDataType.Int32)]
    public int RaidOffset { get; set; }

    [DbcColumn(16, DbcColumnDataType.Int32)]
    public int MaxPlayers { get; set; }

    public AreaTable? GetAreaTableIdAreaTable()
    {
        return DbcDirectory.Open<AreaTable>()?.Where(c => c.Id == AreaTableId).FirstOrDefault();
    }

    public LoadingScreens? GetLoadingScreenIdLoadingScreens()
    {
        return DbcDirectory.Open<LoadingScreens>()?.Where(c => c.Id == LoadingScreenId).FirstOrDefault();
    }

    public Map? GetCorpseMapIdMap()
    {
        return DbcDirectory.Open<Map>()?.Where(c => c.Id == CorpseMapId).FirstOrDefault();
    }
}