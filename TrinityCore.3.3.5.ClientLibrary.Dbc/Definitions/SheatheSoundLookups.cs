using TrinityCore._3._3._5.ClientLibrary.Dbc.Attributes;

namespace TrinityCore._3._3._5.ClientLibrary.Dbc.Definitions
{
    [DbcFile("SheatheSoundLookups.dbc")]
    public class SheatheSoundLookups : DbcFile
    {
        [DbcColumn(0, Enums.DbcColumnDataType.Int32)]
        public int Id { get; set; }

        [DbcColumn(1, Enums.DbcColumnDataType.Int32)]
        public int ClassId { get; set; }

        [DbcColumn(2, Enums.DbcColumnDataType.Int32)]
        public int SubclassId { get; set; }

        [DbcColumn(3, Enums.DbcColumnDataType.Int32)]
        public int Material { get; set; }

        [DbcColumn(4, Enums.DbcColumnDataType.Int32)]
        public int CheckMaterial { get; set; }

        [DbcColumn(5, Enums.DbcColumnDataType.Int32)]
        public int SheatheSound { get; set; }

        [DbcColumn(6, Enums.DbcColumnDataType.Int32)]
        public int UnsheatheSound { get; set; }

        public ItemSubClass? GetClassIdItemSubClass()
        {
               return DbcDirectory.Open<ItemSubClass>()?.Where(c => c.ClassId == this.ClassId).FirstOrDefault();
        }

        public ItemSubClass? GetSubclassIdItemSubClass()
        {
               return DbcDirectory.Open<ItemSubClass>()?.Where(c => c.SubClassId == this.SubclassId).FirstOrDefault();
        }

        public Material? GetMaterialMaterial()
        {
               return DbcDirectory.Open<Material>()?.Where(c => c.Id == this.Material).FirstOrDefault();
        }

     }
}
