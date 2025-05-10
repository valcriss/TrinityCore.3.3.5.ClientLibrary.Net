using TrinityCore._3._3._5.ClientLibrary.Dbc.Attributes;
using TrinityCore._3._3._5.ClientLibrary.Dbc.Enums;

namespace TrinityCore._3._3._5.ClientLibrary.Dbc.Definitions;

[DbcFile("LoadingScreenTaxiSplines.dbc")]
public class LoadingScreenTaxiSplines : DbcFile
{
    [DbcColumn(0, DbcColumnDataType.Int32)]
    public int Id { get; set; }

    [DbcColumn(1, DbcColumnDataType.Int32)]
    public int PathId { get; set; }

    [DbcColumn(2, DbcColumnDataType.ArrayOfFloat, 8)]
    public float[]? Locx { get; set; }

    [DbcColumn(3, DbcColumnDataType.ArrayOfFloat, 8)]
    public float[]? Locy { get; set; }

    [DbcColumn(4, DbcColumnDataType.Int32)]
    public int LegIndex { get; set; }

    public TaxiPath? GetPathIdTaxiPath()
    {
        return DbcDirectory.Open<TaxiPath>()?.Where(c => c.Id == PathId).FirstOrDefault();
    }
}