using TrinityCore._3._3._5.ClientLibrary.Dbc.Attributes;
using TrinityCore._3._3._5.ClientLibrary.Dbc.Enums;

namespace TrinityCore._3._3._5.ClientLibrary.Dbc.Definitions;

[DbcFile("ItemSubClassMask.dbc")]
public class ItemSubClassMask : DbcFile
{
    [DbcColumn(0, DbcColumnDataType.Int32)]
    public int ClassId { get; set; }

    [DbcColumn(1, DbcColumnDataType.Int32)]
    public int Mask { get; set; }

    [DbcColumn(2, DbcColumnDataType.Loc)]
    public string? NameLang { get; set; }

    public ItemClass? GetClassIdItemClass()
    {
        return DbcDirectory.Open<ItemClass>()?.Where(c => c.ClassId == ClassId).FirstOrDefault();
    }
}