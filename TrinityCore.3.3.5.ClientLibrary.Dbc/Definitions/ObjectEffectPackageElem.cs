using TrinityCore._3._3._5.ClientLibrary.Dbc.Attributes;

namespace TrinityCore._3._3._5.ClientLibrary.Dbc.Definitions
{
    [DbcFile("ObjectEffectPackageElem.dbc")]
    public class ObjectEffectPackageElem : DbcFile
    {
        [DbcColumn(0, Enums.DbcColumnDataType.Int32)]
        public int Id { get; set; }

        [DbcColumn(1, Enums.DbcColumnDataType.Int32)]
        public int ObjectEffectPackageId { get; set; }

        [DbcColumn(2, Enums.DbcColumnDataType.Int32)]
        public int ObjectEffectGroupId { get; set; }

        [DbcColumn(3, Enums.DbcColumnDataType.Int32)]
        public int StateType { get; set; }

        public ObjectEffectPackage? GetObjectEffectPackageIdObjectEffectPackage()
        {
               return DbcDirectory.Open<ObjectEffectPackage>()?.Where(c => c.Id == this.ObjectEffectPackageId).FirstOrDefault();
        }

        public ObjectEffectGroup? GetObjectEffectGroupIdObjectEffectGroup()
        {
               return DbcDirectory.Open<ObjectEffectGroup>()?.Where(c => c.Id == this.ObjectEffectGroupId).FirstOrDefault();
        }

     }
}
