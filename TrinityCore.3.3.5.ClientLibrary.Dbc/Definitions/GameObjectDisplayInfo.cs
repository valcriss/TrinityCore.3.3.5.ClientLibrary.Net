using TrinityCore._3._3._5.ClientLibrary.Dbc.Attributes;
using TrinityCore._3._3._5.ClientLibrary.Dbc.Enums;

namespace TrinityCore._3._3._5.ClientLibrary.Dbc.Definitions;

[DbcFile("GameObjectDisplayInfo.dbc")]
public class GameObjectDisplayInfo : DbcFile
{
    [DbcColumn(0, DbcColumnDataType.Int32)]
    public int Id { get; set; }

    [DbcColumn(1, DbcColumnDataType.StringRef)]
    public string? ModelName { get; set; }

    [DbcColumn(2, DbcColumnDataType.ArrayOfUint32, 10)]
    public int[]? Sound { get; set; }

    [DbcColumn(3, DbcColumnDataType.ArrayOfFloat, 3)]
    public float[]? GeoBoxMin { get; set; }

    [DbcColumn(4, DbcColumnDataType.ArrayOfFloat, 3)]
    public float[]? GeoBoxMax { get; set; }

    [DbcColumn(5, DbcColumnDataType.Int32)]
    public int ObjectEffectPackageId { get; set; }

    public ObjectEffectPackage? GetObjectEffectPackageIdObjectEffectPackage()
    {
        return DbcDirectory.Open<ObjectEffectPackage>()?.Where(c => c.Id == ObjectEffectPackageId).FirstOrDefault();
    }
}