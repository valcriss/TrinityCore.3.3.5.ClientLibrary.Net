using TrinityCore._3._3._5.ClientLibrary.Dbc.Attributes;
using TrinityCore._3._3._5.ClientLibrary.Dbc.Enums;

namespace TrinityCore._3._3._5.ClientLibrary.Dbc.Definitions;

[DbcFile("CharHairTextures.dbc")]
public class CharHairTextures : DbcFile
{
    [DbcColumn(0, DbcColumnDataType.Int32)]
    public int Id { get; set; }

    [DbcColumn(1, DbcColumnDataType.Int32)]
    public int Field0533368001Race { get; set; }

    [DbcColumn(2, DbcColumnDataType.Int32)]
    public int Field0533368002Gender { get; set; }

    [DbcColumn(3, DbcColumnDataType.Int32)]
    public int Field0533368003 { get; set; }

    [DbcColumn(4, DbcColumnDataType.Int32)]
    public int Field0533368004Mayberacemask { get; set; }

    [DbcColumn(5, DbcColumnDataType.Int32)]
    public int Field0533368005TheXInHairXyBlp { get; set; }

    [DbcColumn(6, DbcColumnDataType.Int32)]
    public int Field0533368006 { get; set; }

    [DbcColumn(7, DbcColumnDataType.Int32)]
    public int Field0533368007 { get; set; }

    public ChrRaces? GetField0533368001RaceChrRaces()
    {
        return DbcDirectory.Open<ChrRaces>()?.Where(c => c.Id == Field0533368001Race).FirstOrDefault();
    }
}