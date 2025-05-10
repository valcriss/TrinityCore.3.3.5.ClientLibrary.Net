using TrinityCore._3._3._5.ClientLibrary.Dbc.Attributes;
using TrinityCore._3._3._5.ClientLibrary.Dbc.Enums;

namespace TrinityCore._3._3._5.ClientLibrary.Dbc.Definitions;

[DbcFile("AuctionHouse.dbc")]
public class AuctionHouse : DbcFile
{
    [DbcColumn(0, DbcColumnDataType.Int32)]
    public int Id { get; set; }

    [DbcColumn(1, DbcColumnDataType.Int32)]
    public int FactionId { get; set; }

    [DbcColumn(2, DbcColumnDataType.Int32)]
    public int DepositRate { get; set; }

    [DbcColumn(3, DbcColumnDataType.Int32)]
    public int ConsignmentRate { get; set; }

    [DbcColumn(4, DbcColumnDataType.Loc)]
    public string? NameLang { get; set; }

    public Faction? GetFactionIdFaction()
    {
        return DbcDirectory.Open<Faction>()?.Where(c => c.Id == FactionId).FirstOrDefault();
    }
}