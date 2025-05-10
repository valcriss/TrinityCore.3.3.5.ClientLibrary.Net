using TrinityCore._3._3._5.ClientLibrary.Dbc.Attributes;
using TrinityCore._3._3._5.ClientLibrary.Dbc.Enums;

namespace TrinityCore._3._3._5.ClientLibrary.Dbc.Definitions;

[DbcFile("ItemCondExtCosts.dbc")]
public class ItemCondExtCosts : DbcFile
{
    [DbcColumn(0, DbcColumnDataType.Int32)]
    public int Id { get; set; }

    [DbcColumn(1, DbcColumnDataType.Int32)]
    public int CondExtendedCost { get; set; }

    [DbcColumn(2, DbcColumnDataType.Int32)]
    public int ItemExtendedCostEntry { get; set; }

    [DbcColumn(3, DbcColumnDataType.Int32)]
    public int ArenaSeason { get; set; }

    public ItemExtendedCost? GetItemExtendedCostEntryItemExtendedCost()
    {
        return DbcDirectory.Open<ItemExtendedCost>()?.Where(c => c.Id == ItemExtendedCostEntry).FirstOrDefault();
    }
}