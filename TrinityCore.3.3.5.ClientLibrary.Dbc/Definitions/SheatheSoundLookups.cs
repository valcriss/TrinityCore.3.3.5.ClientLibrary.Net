using TrinityCore._3._3._5.ClientLibrary.Dbc.Attributes;
using TrinityCore._3._3._5.ClientLibrary.Dbc.Enums;

namespace TrinityCore._3._3._5.ClientLibrary.Dbc.Definitions;

[DbcFile("SheatheSoundLookups.dbc")]
public class SheatheSoundLookups : DbcFile
{
    [DbcColumn(0, DbcColumnDataType.Int32)]
    public int Id { get; set; }

    [DbcColumn(1, DbcColumnDataType.Int32)]
    public int ClassId { get; set; }

    [DbcColumn(2, DbcColumnDataType.Int32)]
    public int SubclassId { get; set; }

    [DbcColumn(3, DbcColumnDataType.Int32)]
    public int Material { get; set; }

    [DbcColumn(4, DbcColumnDataType.Int32)]
    public int CheckMaterial { get; set; }

    [DbcColumn(5, DbcColumnDataType.Int32)]
    public int SheatheSound { get; set; }

    [DbcColumn(6, DbcColumnDataType.Int32)]
    public int UnsheatheSound { get; set; }

    public ItemSubClass? GetClassIdItemSubClass()
    {
        return DbcDirectory.Open<ItemSubClass>()?.Where(c => c.ClassId == ClassId).FirstOrDefault();
    }

    public ItemSubClass? GetSubclassIdItemSubClass()
    {
        return DbcDirectory.Open<ItemSubClass>()?.Where(c => c.SubClassId == SubclassId).FirstOrDefault();
    }

    public Material? GetMaterialMaterial()
    {
        return DbcDirectory.Open<Material>()?.Where(c => c.Id == Material).FirstOrDefault();
    }
}