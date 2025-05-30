using TrinityCore._3._3._5.ClientLibrary.Dbc.Attributes;
using TrinityCore._3._3._5.ClientLibrary.Dbc.Enums;

namespace TrinityCore._3._3._5.ClientLibrary.Dbc.Definitions;

[DbcFile("CharHairGeosets.dbc")]
public class CharHairGeosets : DbcFile
{
    [DbcColumn(0, DbcColumnDataType.Int32)]
    public int Id { get; set; }

    [DbcColumn(1, DbcColumnDataType.Int32)]
    public int RaceId { get; set; }

    [DbcColumn(2, DbcColumnDataType.Int32)]
    public int SexId { get; set; }

    [DbcColumn(3, DbcColumnDataType.Int32)]
    public int VariationId { get; set; }

    [DbcColumn(4, DbcColumnDataType.Int32)]
    public int GeosetId { get; set; }

    [DbcColumn(5, DbcColumnDataType.Int32)]
    public int Showscalp { get; set; }

    public ChrRaces? GetRaceIdChrRaces()
    {
        return DbcDirectory.Open<ChrRaces>()?.Where(c => c.Id == RaceId).FirstOrDefault();
    }
}