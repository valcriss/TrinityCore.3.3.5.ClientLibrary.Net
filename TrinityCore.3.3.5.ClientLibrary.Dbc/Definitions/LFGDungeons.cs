using TrinityCore._3._3._5.ClientLibrary.Dbc.Attributes;
using TrinityCore._3._3._5.ClientLibrary.Dbc.Enums;

namespace TrinityCore._3._3._5.ClientLibrary.Dbc.Definitions;

[DbcFile("LFGDungeons.dbc")]
public class LFGDungeons : DbcFile
{
    [DbcColumn(0, DbcColumnDataType.Int32)]
    public int Id { get; set; }

    [DbcColumn(1, DbcColumnDataType.Loc)]
    public string? NameLang { get; set; }

    [DbcColumn(2, DbcColumnDataType.Int32)]
    public int MinLevel { get; set; }

    [DbcColumn(3, DbcColumnDataType.Int32)]
    public int MaxLevel { get; set; }

    [DbcColumn(4, DbcColumnDataType.Int32)]
    public int TargetLevel { get; set; }

    [DbcColumn(5, DbcColumnDataType.Int32)]
    public int TargetLevelMin { get; set; }

    [DbcColumn(6, DbcColumnDataType.Int32)]
    public int TargetLevelMax { get; set; }

    [DbcColumn(7, DbcColumnDataType.Int32)]
    public int MapId { get; set; }

    [DbcColumn(8, DbcColumnDataType.Int32)]
    public int Difficulty { get; set; }

    [DbcColumn(9, DbcColumnDataType.Int32)]
    public int Flags { get; set; }

    [DbcColumn(10, DbcColumnDataType.Int32)]
    public int TypeId { get; set; }

    [DbcColumn(11, DbcColumnDataType.Int32)]
    public int Faction { get; set; }

    [DbcColumn(12, DbcColumnDataType.StringRef)]
    public string? TextureFilename { get; set; }

    [DbcColumn(13, DbcColumnDataType.Int32)]
    public int ExpansionLevel { get; set; }

    [DbcColumn(14, DbcColumnDataType.Int32)]
    public int OrderIndex { get; set; }

    [DbcColumn(15, DbcColumnDataType.Int32)]
    public int GroupId { get; set; }

    [DbcColumn(16, DbcColumnDataType.Loc)]
    public string? Description { get; set; }

    public Map? GetMapIdMap()
    {
        return DbcDirectory.Open<Map>()?.Where(c => c.Id == MapId).FirstOrDefault();
    }

    public Faction? GetFactionFaction()
    {
        return DbcDirectory.Open<Faction>()?.Where(c => c.Id == Faction).FirstOrDefault();
    }
}