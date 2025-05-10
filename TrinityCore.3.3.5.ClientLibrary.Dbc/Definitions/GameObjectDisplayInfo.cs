using TrinityCore._3._3._5.ClientLibrary.Dbc.Attributes;

namespace TrinityCore._3._3._5.ClientLibrary.Dbc.Definitions
{
    [DbcFile("GameObjectDisplayInfo.dbc")]
    public class GameObjectDisplayInfo : DbcFile
    {
        [DbcColumn(0, Enums.DbcColumnDataType.Int32)]
        public int Id { get; set; }

        [DbcColumn(1, Enums.DbcColumnDataType.StringRef)]
        public string? ModelName { get; set; }

        [DbcColumn(2, Enums.DbcColumnDataType.ArrayOfUint32, 10)]
        public int[]? Sound { get; set; }

        [DbcColumn(3, Enums.DbcColumnDataType.ArrayOfFloat, 3)]
        public float[]? GeoBoxMin { get; set; }

        [DbcColumn(4, Enums.DbcColumnDataType.ArrayOfFloat, 3)]
        public float[]? GeoBoxMax { get; set; }

        [DbcColumn(5, Enums.DbcColumnDataType.Int32)]
        public int ObjectEffectPackageId { get; set; }

        public ObjectEffectPackage? GetObjectEffectPackageIdObjectEffectPackage()
        {
               return DbcDirectory.Open<ObjectEffectPackage>()?.Where(c => c.Id == this.ObjectEffectPackageId).FirstOrDefault();
        }

     }
}
