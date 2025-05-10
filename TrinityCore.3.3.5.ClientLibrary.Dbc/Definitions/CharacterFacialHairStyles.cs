using TrinityCore._3._3._5.ClientLibrary.Dbc.Attributes;
using TrinityCore._3._3._5.ClientLibrary.Dbc.Enums;

namespace TrinityCore._3._3._5.ClientLibrary.Dbc.Definitions;

[DbcFile("CharacterFacialHairStyles.dbc")]
public class CharacterFacialHairStyles : DbcFile
{
    [DbcColumn(0, DbcColumnDataType.Int32)]
    public int RaceId { get; set; }

    [DbcColumn(1, DbcColumnDataType.Int32)]
    public int SexId { get; set; }

    [DbcColumn(2, DbcColumnDataType.Int32)]
    public int VariationId { get; set; }

    [DbcColumn(3, DbcColumnDataType.ArrayOfUint32, 5)]
    public int[]? Geoset { get; set; }

    public ChrRaces? GetRaceIdChrRaces()
    {
        return DbcDirectory.Open<ChrRaces>()?.Where(c => c.Id == RaceId).FirstOrDefault();
    }
}