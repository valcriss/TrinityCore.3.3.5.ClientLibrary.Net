using TrinityCore._3._3._5.ClientLibrary.Dbc.Attributes;

namespace TrinityCore._3._3._5.ClientLibrary.Dbc.Definitions
{
    [DbcFile("CharSections.dbc")]
    public class CharSections : DbcFile
    {
        [DbcColumn(0, Enums.DbcColumnDataType.Int32)]
        public int Id { get; set; }

        [DbcColumn(1, Enums.DbcColumnDataType.Int32)]
        public int RaceId { get; set; }

        [DbcColumn(2, Enums.DbcColumnDataType.Int32)]
        public int SexId { get; set; }

        [DbcColumn(3, Enums.DbcColumnDataType.Int32)]
        public int BaseSection { get; set; }

        [DbcColumn(4, Enums.DbcColumnDataType.ArrayOfStringRef, 3)]
        public string[]? TextureName { get; set; }

        [DbcColumn(5, Enums.DbcColumnDataType.Int32)]
        public int Flags { get; set; }

        [DbcColumn(6, Enums.DbcColumnDataType.Int32)]
        public int VariationIndex { get; set; }

        [DbcColumn(7, Enums.DbcColumnDataType.Int32)]
        public int ColorIndex { get; set; }

        public ChrRaces? GetRaceIdChrRaces()
        {
               return DbcDirectory.Open<ChrRaces>()?.Where(c => c.Id == this.RaceId).FirstOrDefault();
        }

     }
}
