using TrinityCore._3._3._5.ClientLibrary.Dbc.Attributes;

namespace TrinityCore._3._3._5.ClientLibrary.Dbc.Definitions
{
    [DbcFile("CharHairTextures.dbc")]
    public class CharHairTextures : DbcFile
    {
        [DbcColumn(0, Enums.DbcColumnDataType.Int32)]
        public int Id { get; set; }

        [DbcColumn(1, Enums.DbcColumnDataType.Int32)]
        public int Field0533368001Race { get; set; }

        [DbcColumn(2, Enums.DbcColumnDataType.Int32)]
        public int Field0533368002Gender { get; set; }

        [DbcColumn(3, Enums.DbcColumnDataType.Int32)]
        public int Field0533368003 { get; set; }

        [DbcColumn(4, Enums.DbcColumnDataType.Int32)]
        public int Field0533368004Mayberacemask { get; set; }

        [DbcColumn(5, Enums.DbcColumnDataType.Int32)]
        public int Field0533368005TheXInHairXyBlp { get; set; }

        [DbcColumn(6, Enums.DbcColumnDataType.Int32)]
        public int Field0533368006 { get; set; }

        [DbcColumn(7, Enums.DbcColumnDataType.Int32)]
        public int Field0533368007 { get; set; }

        public ChrRaces? GetField0533368001RaceChrRaces()
        {
               return DbcDirectory.Open<ChrRaces>()?.Where(c => c.Id == this.Field0533368001Race).FirstOrDefault();
        }

     }
}
