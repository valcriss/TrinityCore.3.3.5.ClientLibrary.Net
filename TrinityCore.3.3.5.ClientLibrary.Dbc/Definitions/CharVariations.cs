using TrinityCore._3._3._5.ClientLibrary.Dbc.Attributes;

namespace TrinityCore._3._3._5.ClientLibrary.Dbc.Definitions
{
    [DbcFile("CharVariations.dbc")]
    public class CharVariations : DbcFile
    {
        [DbcColumn(0, Enums.DbcColumnDataType.Int32)]
        public int RaceId { get; set; }

        [DbcColumn(1, Enums.DbcColumnDataType.Int32)]
        public int SexId { get; set; }

        [DbcColumn(2, Enums.DbcColumnDataType.ArrayOfUint32, 4)]
        public int[]? TextureHoldLayer { get; set; }

        public ChrRaces? GetRaceIdChrRaces()
        {
               return DbcDirectory.Open<ChrRaces>()?.Where(c => c.Id == this.RaceId).FirstOrDefault();
        }

     }
}
