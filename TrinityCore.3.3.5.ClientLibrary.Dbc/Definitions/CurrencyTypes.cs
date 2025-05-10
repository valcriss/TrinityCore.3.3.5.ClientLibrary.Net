using TrinityCore._3._3._5.ClientLibrary.Dbc.Attributes;

namespace TrinityCore._3._3._5.ClientLibrary.Dbc.Definitions
{
    [DbcFile("CurrencyTypes.dbc")]
    public class CurrencyTypes : DbcFile
    {
        [DbcColumn(0, Enums.DbcColumnDataType.Int32)]
        public int Id { get; set; }

        [DbcColumn(1, Enums.DbcColumnDataType.Int32)]
        public int ItemId { get; set; }

        [DbcColumn(2, Enums.DbcColumnDataType.Int32)]
        public int CategoryId { get; set; }

        [DbcColumn(3, Enums.DbcColumnDataType.Int32)]
        public int BitIndex { get; set; }

        public Item? GetItemIdItem()
        {
               return DbcDirectory.Open<Item>()?.Where(c => c.Id == this.ItemId).FirstOrDefault();
        }

        public CurrencyCategory? GetCategoryIdCurrencyCategory()
        {
               return DbcDirectory.Open<CurrencyCategory>()?.Where(c => c.Id == this.CategoryId).FirstOrDefault();
        }

     }
}
