using TrinityCore._3._3._5.ClientLibrary.Dbc.Attributes;
using TrinityCore._3._3._5.ClientLibrary.Dbc.Enums;

namespace TrinityCore._3._3._5.ClientLibrary.Dbc.Definitions;

[DbcFile("VocalUISounds.dbc")]
public class VocalUISounds : DbcFile
{
    [DbcColumn(0, DbcColumnDataType.Int32)]
    public int Id { get; set; }

    [DbcColumn(1, DbcColumnDataType.Int32)]
    public int VocalUIEnum { get; set; }

    [DbcColumn(2, DbcColumnDataType.Int32)]
    public int RaceId { get; set; }

    [DbcColumn(3, DbcColumnDataType.ArrayOfUint32, 2)]
    public int[]? NormalSoundId { get; set; }

    [DbcColumn(4, DbcColumnDataType.ArrayOfUint32, 2)]
    public int[]? PissedSoundId { get; set; }

    public ChrRaces? GetRaceIdChrRaces()
    {
        return DbcDirectory.Open<ChrRaces>()?.Where(c => c.Id == RaceId).FirstOrDefault();
    }
}