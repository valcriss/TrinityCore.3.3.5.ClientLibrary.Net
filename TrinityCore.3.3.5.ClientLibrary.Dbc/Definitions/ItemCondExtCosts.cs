using TrinityCore._3._3._5.ClientLibrary.Dbc.Attributes;

namespace TrinityCore._3._3._5.ClientLibrary.Dbc.Definitions
{
    [DbcFile("ItemCondExtCosts.dbc")]
    public class ItemCondExtCosts : DbcFile
    {
        [DbcColumn(0, Enums.DbcColumnDataType.Int32)]
        public int Id { get; set; }

        [DbcColumn(1, Enums.DbcColumnDataType.Int32)]
        public int CondExtendedCost { get; set; }

        [DbcColumn(2, Enums.DbcColumnDataType.Int32)]
        public int ItemExtendedCostEntry { get; set; }

        [DbcColumn(3, Enums.DbcColumnDataType.Int32)]
        public int ArenaSeason { get; set; }

        public ItemExtendedCost? GetItemExtendedCostEntryItemExtendedCost()
        {
               return DbcDirectory.Open<ItemExtendedCost>()?.Where(c => c.Id == this.ItemExtendedCostEntry).FirstOrDefault();
        }

     }
}
