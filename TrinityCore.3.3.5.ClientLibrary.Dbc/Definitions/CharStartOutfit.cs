using TrinityCore._3._3._5.ClientLibrary.Dbc.Attributes;
using TrinityCore._3._3._5.ClientLibrary.Dbc.Enums;

namespace TrinityCore._3._3._5.ClientLibrary.Dbc.Definitions;

[DbcFile("CharStartOutfit.dbc")]
public class CharStartOutfit : DbcFile
{
    [DbcColumn(0, DbcColumnDataType.Int32)]
    public int Id { get; set; }

    [DbcColumn(1, DbcColumnDataType.Byte)]
    public byte RaceId { get; set; }

    [DbcColumn(2, DbcColumnDataType.Byte)]
    public byte ClassId { get; set; }

    [DbcColumn(3, DbcColumnDataType.Byte)]
    public byte SexId { get; set; }

    [DbcColumn(4, DbcColumnDataType.Byte)]
    public byte OutfitId { get; set; }

    [DbcColumn(5, DbcColumnDataType.ArrayOfUint32, 24)]
    public int[]? ItemId { get; set; }

    [DbcColumn(6, DbcColumnDataType.ArrayOfUint32, 24)]
    public int[]? DisplayItemId { get; set; }

    [DbcColumn(7, DbcColumnDataType.ArrayOfUint32, 24)]
    public int[]? InventoryType { get; set; }

    public ChrRaces? GetRaceIdChrRaces()
    {
        return DbcDirectory.Open<ChrRaces>()?.Where(c => c.Id == RaceId).FirstOrDefault();
    }

    public ChrClasses? GetClassIdChrClasses()
    {
        return DbcDirectory.Open<ChrClasses>()?.Where(c => c.Id == ClassId).FirstOrDefault();
    }

    public Item[]? GetItemIdItems()
    {
        return DbcDirectory.Open<Item>()?.Where(c => ItemId != null && ItemId.Contains(c.Id)).ToArray();
    }

    public ItemDisplayInfo[]? GetDisplayItemIdItemDisplayInfos()
    {
        return DbcDirectory.Open<ItemDisplayInfo>()?.Where(c => DisplayItemId != null && DisplayItemId.Contains(c.Id)).ToArray();
    }
}