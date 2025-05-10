using TrinityCore._3._3._5.ClientLibrary.Dbc.Attributes;

namespace TrinityCore._3._3._5.ClientLibrary.Dbc.Definitions
{
    [DbcFile("ItemSubClass.dbc")]
    public class ItemSubClass : DbcFile
    {
        [DbcColumn(0, Enums.DbcColumnDataType.Int32)]
        public int ClassId { get; set; }

        [DbcColumn(1, Enums.DbcColumnDataType.Int32)]
        public int SubClassId { get; set; }

        [DbcColumn(2, Enums.DbcColumnDataType.Int32)]
        public int PrerequisiteProficiency { get; set; }

        [DbcColumn(3, Enums.DbcColumnDataType.Int32)]
        public int PostrequisiteProficiency { get; set; }

        [DbcColumn(4, Enums.DbcColumnDataType.Int32)]
        public int Flags { get; set; }

        [DbcColumn(5, Enums.DbcColumnDataType.Int32)]
        public int DisplayFlags { get; set; }

        [DbcColumn(6, Enums.DbcColumnDataType.Int32)]
        public int WeaponParrySeq { get; set; }

        [DbcColumn(7, Enums.DbcColumnDataType.Int32)]
        public int WeaponReadySeq { get; set; }

        [DbcColumn(8, Enums.DbcColumnDataType.Int32)]
        public int WeaponAttackSeq { get; set; }

        [DbcColumn(9, Enums.DbcColumnDataType.Int32)]
        public int WeaponSwingSize { get; set; }

        [DbcColumn(10, Enums.DbcColumnDataType.Loc)]
        public string? DisplayNameLang { get; set; }

        [DbcColumn(11, Enums.DbcColumnDataType.Loc)]
        public string? VerboseNameLang { get; set; }

        public ItemClass? GetClassIdItemClass()
        {
               return DbcDirectory.Open<ItemClass>()?.Where(c => c.ClassId == this.ClassId).FirstOrDefault();
        }

     }
}
