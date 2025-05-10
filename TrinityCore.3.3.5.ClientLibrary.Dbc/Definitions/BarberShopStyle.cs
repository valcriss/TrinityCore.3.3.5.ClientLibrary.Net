using TrinityCore._3._3._5.ClientLibrary.Dbc.Attributes;
using TrinityCore._3._3._5.ClientLibrary.Dbc.Enums;

namespace TrinityCore._3._3._5.ClientLibrary.Dbc.Definitions;

[DbcFile("BarberShopStyle.dbc")]
public class BarberShopStyle : DbcFile
{
    [DbcColumn(0, DbcColumnDataType.Int32)]
    public int Id { get; set; }

    [DbcColumn(1, DbcColumnDataType.Int32)]
    public int Type { get; set; }

    [DbcColumn(2, DbcColumnDataType.Loc)]
    public string? DisplayNameLang { get; set; }

    [DbcColumn(3, DbcColumnDataType.Loc)]
    public string? Description { get; set; }

    [DbcColumn(4, DbcColumnDataType.Float)]
    public float CostModifier { get; set; }

    [DbcColumn(5, DbcColumnDataType.Int32)]
    public int Race { get; set; }

    [DbcColumn(6, DbcColumnDataType.Int32)]
    public int Sex { get; set; }

    [DbcColumn(7, DbcColumnDataType.Int32)]
    public int Data { get; set; }

    public ChrRaces? GetRaceChrRaces()
    {
        return DbcDirectory.Open<ChrRaces>()?.Where(c => c.Id == Race).FirstOrDefault();
    }
}