using TrinityCore._3._3._5.ClientLibrary.Dbc.Attributes;

namespace TrinityCore._3._3._5.ClientLibrary.Dbc.Definitions
{
    [DbcFile("ItemExtendedCost.dbc")]
    public class ItemExtendedCost : DbcFile
    {
        [DbcColumn(0, Enums.DbcColumnDataType.Int32)]
        public int Id { get; set; }

        [DbcColumn(1, Enums.DbcColumnDataType.Int32)]
        public int HonorPoints { get; set; }

        [DbcColumn(2, Enums.DbcColumnDataType.Int32)]
        public int ArenaPoints { get; set; }

        [DbcColumn(3, Enums.DbcColumnDataType.Int32)]
        public int ArenaBracket { get; set; }

        [DbcColumn(4, Enums.DbcColumnDataType.ArrayOfUint32, 5)]
        public int[]? ItemId { get; set; }

        [DbcColumn(5, Enums.DbcColumnDataType.ArrayOfUint32, 5)]
        public int[]? ItemCount { get; set; }

        [DbcColumn(6, Enums.DbcColumnDataType.Int32)]
        public int RequiredArenaRating { get; set; }

        [DbcColumn(7, Enums.DbcColumnDataType.Int32)]
        public int ItemPurchaseGroup { get; set; }

        public Item[]? GetItemIdItems()
        {
               return DbcDirectory.Open<Item>()?.Where(c => this.ItemId != null && this.ItemId.Contains(c.Id)).ToArray();
        }

        public ItemPurchaseGroup? GetItemPurchaseGroupItemPurchaseGroup()
        {
               return DbcDirectory.Open<ItemPurchaseGroup>()?.Where(c => c.Id == this.ItemPurchaseGroup).FirstOrDefault();
        }

     }
}
