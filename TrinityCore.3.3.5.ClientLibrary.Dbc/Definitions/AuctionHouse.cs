using TrinityCore._3._3._5.ClientLibrary.Dbc.Attributes;

namespace TrinityCore._3._3._5.ClientLibrary.Dbc.Definitions
{
    [DbcFile("AuctionHouse.dbc")]
    public class AuctionHouse : DbcFile
    {
        [DbcColumn(0, Enums.DbcColumnDataType.Int32)]
        public int Id { get; set; }

        [DbcColumn(1, Enums.DbcColumnDataType.Int32)]
        public int FactionId { get; set; }

        [DbcColumn(2, Enums.DbcColumnDataType.Int32)]
        public int DepositRate { get; set; }

        [DbcColumn(3, Enums.DbcColumnDataType.Int32)]
        public int ConsignmentRate { get; set; }

        [DbcColumn(4, Enums.DbcColumnDataType.Loc)]
        public string? NameLang { get; set; }

        public Faction? GetFactionIdFaction()
        {
               return DbcDirectory.Open<Faction>()?.Where(c => c.Id == this.FactionId).FirstOrDefault();
        }

     }
}
