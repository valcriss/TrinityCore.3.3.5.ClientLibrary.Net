using TrinityCore._3._3._5.ClientLibrary.Dbc.Attributes;
using TrinityCore._3._3._5.ClientLibrary.Dbc.Enums;

namespace TrinityCore._3._3._5.ClientLibrary.Dbc.Definitions;

[DbcFile("CurrencyTypes.dbc")]
public class CurrencyTypes : DbcFile
{
    [DbcColumn(0, DbcColumnDataType.Int32)]
    public int Id { get; set; }

    [DbcColumn(1, DbcColumnDataType.Int32)]
    public int ItemId { get; set; }

    [DbcColumn(2, DbcColumnDataType.Int32)]
    public int CategoryId { get; set; }

    [DbcColumn(3, DbcColumnDataType.Int32)]
    public int BitIndex { get; set; }

    public Item? GetItemIdItem()
    {
        return DbcDirectory.Open<Item>()?.Where(c => c.Id == ItemId).FirstOrDefault();
    }

    public CurrencyCategory? GetCategoryIdCurrencyCategory()
    {
        return DbcDirectory.Open<CurrencyCategory>()?.Where(c => c.Id == CategoryId).FirstOrDefault();
    }
}