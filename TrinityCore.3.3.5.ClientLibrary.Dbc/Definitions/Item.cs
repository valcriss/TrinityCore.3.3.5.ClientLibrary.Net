using TrinityCore._3._3._5.ClientLibrary.Dbc.Attributes;

namespace TrinityCore._3._3._5.ClientLibrary.Dbc.Definitions
{
    [DbcFile("Item.dbc")]
    public class Item : DbcFile
    {
        [DbcColumn(0, Enums.DbcColumnDataType.Int32)]
        public int Id { get; set; }

        [DbcColumn(1, Enums.DbcColumnDataType.Int32)]
        public int ClassId { get; set; }

        [DbcColumn(2, Enums.DbcColumnDataType.Int32)]
        public int SubclassId { get; set; }

        [DbcColumn(3, Enums.DbcColumnDataType.Int32)]
        public int SoundOverrideSubclassId { get; set; }

        [DbcColumn(4, Enums.DbcColumnDataType.Int32)]
        public int Material { get; set; }

        [DbcColumn(5, Enums.DbcColumnDataType.Int32)]
        public int DisplayInfoId { get; set; }

        [DbcColumn(6, Enums.DbcColumnDataType.Int32)]
        public int InventoryType { get; set; }

        [DbcColumn(7, Enums.DbcColumnDataType.Int32)]
        public int SheatheType { get; set; }

        public ItemClass? GetClassIdItemClass()
        {
               return DbcDirectory.Open<ItemClass>()?.Where(c => c.ClassId == this.ClassId).FirstOrDefault();
        }

        public Material? GetMaterialMaterial()
        {
               return DbcDirectory.Open<Material>()?.Where(c => c.Id == this.Material).FirstOrDefault();
        }

     }
}
