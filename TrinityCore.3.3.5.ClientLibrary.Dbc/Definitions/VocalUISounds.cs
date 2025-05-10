using TrinityCore._3._3._5.ClientLibrary.Dbc.Attributes;

namespace TrinityCore._3._3._5.ClientLibrary.Dbc.Definitions
{
    [DbcFile("VocalUISounds.dbc")]
    public class VocalUISounds : DbcFile
    {
        [DbcColumn(0, Enums.DbcColumnDataType.Int32)]
        public int Id { get; set; }

        [DbcColumn(1, Enums.DbcColumnDataType.Int32)]
        public int VocalUIEnum { get; set; }

        [DbcColumn(2, Enums.DbcColumnDataType.Int32)]
        public int RaceId { get; set; }

        [DbcColumn(3, Enums.DbcColumnDataType.ArrayOfUint32, 2)]
        public int[]? NormalSoundId { get; set; }

        [DbcColumn(4, Enums.DbcColumnDataType.ArrayOfUint32, 2)]
        public int[]? PissedSoundId { get; set; }

        public ChrRaces? GetRaceIdChrRaces()
        {
               return DbcDirectory.Open<ChrRaces>()?.Where(c => c.Id == this.RaceId).FirstOrDefault();
        }

     }
}
