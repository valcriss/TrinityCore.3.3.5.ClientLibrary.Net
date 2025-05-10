using TrinityCore._3._3._5.ClientLibrary.Dbc.Attributes;

namespace TrinityCore._3._3._5.ClientLibrary.Dbc.Definitions
{
    [DbcFile("ChrClasses.dbc")]
    public class ChrClasses : DbcFile
    {
        [DbcColumn(0, Enums.DbcColumnDataType.Int32)]
        public int Id { get; set; }

        [DbcColumn(1, Enums.DbcColumnDataType.Int32)]
        public int DamageBonusStat { get; set; }

        [DbcColumn(2, Enums.DbcColumnDataType.Int32)]
        public int DisplayPower { get; set; }

        [DbcColumn(3, Enums.DbcColumnDataType.StringRef)]
        public string? PetNameToken { get; set; }

        [DbcColumn(4, Enums.DbcColumnDataType.Loc)]
        public string? NameLang { get; set; }

        [DbcColumn(5, Enums.DbcColumnDataType.Loc)]
        public string? NameFemale { get; set; }

        [DbcColumn(6, Enums.DbcColumnDataType.Loc)]
        public string? NameMale { get; set; }

        [DbcColumn(7, Enums.DbcColumnDataType.StringRef)]
        public string? Filename { get; set; }

        [DbcColumn(8, Enums.DbcColumnDataType.Int32)]
        public int SpellClassSet { get; set; }

        [DbcColumn(9, Enums.DbcColumnDataType.Int32)]
        public int Flags { get; set; }

        [DbcColumn(10, Enums.DbcColumnDataType.Int32)]
        public int CinematicSequenceId { get; set; }

        [DbcColumn(11, Enums.DbcColumnDataType.Int32)]
        public int RequiredExpansion { get; set; }

        public CinematicSequences? GetCinematicSequenceIdCinematicSequences()
        {
               return DbcDirectory.Open<CinematicSequences>()?.Where(c => c.Id == this.CinematicSequenceId).FirstOrDefault();
        }

     }
}
