using TrinityCore._3._3._5.ClientLibrary.Dbc.Attributes;
using TrinityCore._3._3._5.ClientLibrary.Dbc.Enums;

namespace TrinityCore._3._3._5.ClientLibrary.Dbc.Definitions;

[DbcFile("TaxiPath.dbc")]
public class TaxiPath : DbcFile
{
    [DbcColumn(0, DbcColumnDataType.Int32)]
    public int Id { get; set; }

    [DbcColumn(1, DbcColumnDataType.Int32)]
    public int FromTaxiNode { get; set; }

    [DbcColumn(2, DbcColumnDataType.Int32)]
    public int ToTaxiNode { get; set; }

    [DbcColumn(3, DbcColumnDataType.Int32)]
    public int Cost { get; set; }

    public TaxiNodes? GetFromTaxiNodeTaxiNodes()
    {
        return DbcDirectory.Open<TaxiNodes>()?.Where(c => c.Id == FromTaxiNode).FirstOrDefault();
    }

    public TaxiNodes? GetToTaxiNodeTaxiNodes()
    {
        return DbcDirectory.Open<TaxiNodes>()?.Where(c => c.Id == ToTaxiNode).FirstOrDefault();
    }
}