using TrinityCore._3._3._5.ClientLibrary.Dbc.Attributes;
using TrinityCore._3._3._5.ClientLibrary.Dbc.Enums;

namespace TrinityCore._3._3._5.ClientLibrary.Dbc.Definitions;

[DbcFile("ItemPurchaseGroup.dbc")]
public class ItemPurchaseGroup : DbcFile
{
    [DbcColumn(0, DbcColumnDataType.Int32)]
    public int Id { get; set; }

    [DbcColumn(1, DbcColumnDataType.ArrayOfUint32, 8)]
    public int[]? ItemId { get; set; }

    [DbcColumn(2, DbcColumnDataType.Loc)]
    public string? NameLang { get; set; }

    public Item[]? GetItemIdItems()
    {
        return DbcDirectory.Open<Item>()?.Where(c => ItemId != null && ItemId.Contains(c.Id)).ToArray();
    }
}