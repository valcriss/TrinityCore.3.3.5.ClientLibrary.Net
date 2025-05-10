using TrinityCore._3._3._5.ClientLibrary.Dbc.Attributes;
using TrinityCore._3._3._5.ClientLibrary.Dbc.Enums;

namespace TrinityCore._3._3._5.ClientLibrary.Dbc.Definitions;

[DbcFile("ItemSubClass.dbc")]
public class ItemSubClass : DbcFile
{
    [DbcColumn(0, DbcColumnDataType.Int32)]
    public int ClassId { get; set; }

    [DbcColumn(1, DbcColumnDataType.Int32)]
    public int SubClassId { get; set; }

    [DbcColumn(2, DbcColumnDataType.Int32)]
    public int PrerequisiteProficiency { get; set; }

    [DbcColumn(3, DbcColumnDataType.Int32)]
    public int PostrequisiteProficiency { get; set; }

    [DbcColumn(4, DbcColumnDataType.Int32)]
    public int Flags { get; set; }

    [DbcColumn(5, DbcColumnDataType.Int32)]
    public int DisplayFlags { get; set; }

    [DbcColumn(6, DbcColumnDataType.Int32)]
    public int WeaponParrySeq { get; set; }

    [DbcColumn(7, DbcColumnDataType.Int32)]
    public int WeaponReadySeq { get; set; }

    [DbcColumn(8, DbcColumnDataType.Int32)]
    public int WeaponAttackSeq { get; set; }

    [DbcColumn(9, DbcColumnDataType.Int32)]
    public int WeaponSwingSize { get; set; }

    [DbcColumn(10, DbcColumnDataType.Loc)]
    public string? DisplayNameLang { get; set; }

    [DbcColumn(11, DbcColumnDataType.Loc)]
    public string? VerboseNameLang { get; set; }

    public ItemClass? GetClassIdItemClass()
    {
        return DbcDirectory.Open<ItemClass>()?.Where(c => c.ClassId == ClassId).FirstOrDefault();
    }
}