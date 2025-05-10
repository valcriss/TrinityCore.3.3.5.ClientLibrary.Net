using TrinityCore._3._3._5.ClientLibrary.Dbc.Attributes;
using TrinityCore._3._3._5.ClientLibrary.Dbc.Enums;

namespace TrinityCore._3._3._5.ClientLibrary.Dbc.Definitions;

[DbcFile("CharVariations.dbc")]
public class CharVariations : DbcFile
{
    [DbcColumn(0, DbcColumnDataType.Int32)]
    public int RaceId { get; set; }

    [DbcColumn(1, DbcColumnDataType.Int32)]
    public int SexId { get; set; }

    [DbcColumn(2, DbcColumnDataType.ArrayOfUint32, 4)]
    public int[]? TextureHoldLayer { get; set; }

    public ChrRaces? GetRaceIdChrRaces()
    {
        return DbcDirectory.Open<ChrRaces>()?.Where(c => c.Id == RaceId).FirstOrDefault();
    }
}