using TrinityCore._3._3._5.ClientLibrary.Dbc.Attributes;

namespace TrinityCore._3._3._5.ClientLibrary.Dbc.Definitions
{
    [DbcFile("CharStartOutfit.dbc")]
    public class CharStartOutfit : DbcFile
    {
        [DbcColumn(0, Enums.DbcColumnDataType.Int32)]
        public int Id { get; set; }

        [DbcColumn(1, Enums.DbcColumnDataType.Byte)]
        public byte RaceId { get; set; }

        [DbcColumn(2, Enums.DbcColumnDataType.Byte)]
        public byte ClassId { get; set; }

        [DbcColumn(3, Enums.DbcColumnDataType.Byte)]
        public byte SexId { get; set; }

        [DbcColumn(4, Enums.DbcColumnDataType.Byte)]
        public byte OutfitId { get; set; }

        [DbcColumn(5, Enums.DbcColumnDataType.ArrayOfUint32, 24)]
        public int[]? ItemId { get; set; }

        [DbcColumn(6, Enums.DbcColumnDataType.ArrayOfUint32, 24)]
        public int[]? DisplayItemId { get; set; }

        [DbcColumn(7, Enums.DbcColumnDataType.ArrayOfUint32, 24)]
        public int[]? InventoryType { get; set; }

        public ChrRaces? GetRaceIdChrRaces()
        {
               return DbcDirectory.Open<ChrRaces>()?.Where(c => c.Id == this.RaceId).FirstOrDefault();
        }

        public ChrClasses? GetClassIdChrClasses()
        {
               return DbcDirectory.Open<ChrClasses>()?.Where(c => c.Id == this.ClassId).FirstOrDefault();
        }

        public Item[]? GetItemIdItems()
        {
               return DbcDirectory.Open<Item>()?.Where(c => this.ItemId != null && this.ItemId.Contains(c.Id)).ToArray();
        }

        public ItemDisplayInfo[]? GetDisplayItemIdItemDisplayInfos()
        {
               return DbcDirectory.Open<ItemDisplayInfo>()?.Where(c => this.DisplayItemId != null && this.DisplayItemId.Contains(c.Id)).ToArray();
        }

     }
}
