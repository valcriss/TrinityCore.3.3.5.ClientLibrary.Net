using TrinityCore._3._3._5.ClientLibrary.Dbc.Attributes;
using TrinityCore._3._3._5.ClientLibrary.Dbc.Enums;

namespace TrinityCore._3._3._5.ClientLibrary.Dbc.Definitions;

[DbcFile("ObjectEffectPackageElem.dbc")]
public class ObjectEffectPackageElem : DbcFile
{
    [DbcColumn(0, DbcColumnDataType.Int32)]
    public int Id { get; set; }

    [DbcColumn(1, DbcColumnDataType.Int32)]
    public int ObjectEffectPackageId { get; set; }

    [DbcColumn(2, DbcColumnDataType.Int32)]
    public int ObjectEffectGroupId { get; set; }

    [DbcColumn(3, DbcColumnDataType.Int32)]
    public int StateType { get; set; }

    public ObjectEffectPackage? GetObjectEffectPackageIdObjectEffectPackage()
    {
        return DbcDirectory.Open<ObjectEffectPackage>()?.Where(c => c.Id == ObjectEffectPackageId).FirstOrDefault();
    }

    public ObjectEffectGroup? GetObjectEffectGroupIdObjectEffectGroup()
    {
        return DbcDirectory.Open<ObjectEffectGroup>()?.Where(c => c.Id == ObjectEffectGroupId).FirstOrDefault();
    }
}