using TrinityCore._3._3._5.ClientLibrary.Dbc.Attributes;
using TrinityCore._3._3._5.ClientLibrary.Dbc.Enums;

namespace TrinityCore._3._3._5.ClientLibrary.Dbc.Definitions;

[DbcFile("Stationery.dbc")]
public class Stationery : DbcFile
{
    [DbcColumn(0, DbcColumnDataType.Int32)]
    public int Id { get; set; }

    [DbcColumn(1, DbcColumnDataType.Int32)]
    public int ItemId { get; set; }

    [DbcColumn(2, DbcColumnDataType.StringRef)]
    public string? Texture { get; set; }

    [DbcColumn(3, DbcColumnDataType.Int32)]
    public int Flags { get; set; }

    public Item? GetItemIdItem()
    {
        return DbcDirectory.Open<Item>()?.Where(c => c.Id == ItemId).FirstOrDefault();
    }
}