using TrinityCore._3._3._5.ClientLibrary.Dbc.Attributes;

namespace TrinityCore._3._3._5.ClientLibrary.Dbc.Definitions
{
    [DbcFile("ChrRaces.dbc")]
    public class ChrRaces : DbcFile
    {
        [DbcColumn(0, Enums.DbcColumnDataType.Int32)]
        public int Id { get; set; }

        [DbcColumn(1, Enums.DbcColumnDataType.Int32)]
        public int Flags { get; set; }

        [DbcColumn(2, Enums.DbcColumnDataType.Int32)]
        public int FactionId { get; set; }

        [DbcColumn(3, Enums.DbcColumnDataType.Int32)]
        public int ExplorationSoundId { get; set; }

        [DbcColumn(4, Enums.DbcColumnDataType.Int32)]
        public int MaleDisplayId { get; set; }

        [DbcColumn(5, Enums.DbcColumnDataType.Int32)]
        public int FemaleDisplayId { get; set; }

        [DbcColumn(6, Enums.DbcColumnDataType.StringRef)]
        public string? ClientPrefix { get; set; }

        [DbcColumn(7, Enums.DbcColumnDataType.Int32)]
        public int BaseLanguage { get; set; }

        [DbcColumn(8, Enums.DbcColumnDataType.Int32)]
        public int CreatureType { get; set; }

        [DbcColumn(9, Enums.DbcColumnDataType.Int32)]
        public int ResSicknessSpellId { get; set; }

        [DbcColumn(10, Enums.DbcColumnDataType.Int32)]
        public int SplashSoundId { get; set; }

        [DbcColumn(11, Enums.DbcColumnDataType.StringRef)]
        public string? ClientFileString { get; set; }

        [DbcColumn(12, Enums.DbcColumnDataType.Int32)]
        public int CinematicSequenceId { get; set; }

        [DbcColumn(13, Enums.DbcColumnDataType.Int32)]
        public int Alliance { get; set; }

        [DbcColumn(14, Enums.DbcColumnDataType.Loc)]
        public string? NameLang { get; set; }

        [DbcColumn(15, Enums.DbcColumnDataType.Loc)]
        public string? NameFemale { get; set; }

        [DbcColumn(16, Enums.DbcColumnDataType.Loc)]
        public string? NameMale { get; set; }

        [DbcColumn(17, Enums.DbcColumnDataType.ArrayOfStringRef, 2)]
        public string[]? FacialHairCustomization { get; set; }

        [DbcColumn(18, Enums.DbcColumnDataType.StringRef)]
        public string? HairCustomization { get; set; }

        [DbcColumn(19, Enums.DbcColumnDataType.Int32)]
        public int RequiredExpansion { get; set; }

        public FactionTemplate? GetFactionIdFactionTemplate()
        {
               return DbcDirectory.Open<FactionTemplate>()?.Where(c => c.Id == this.FactionId).FirstOrDefault();
        }

        public SoundEntries? GetExplorationSoundIdSoundEntries()
        {
               return DbcDirectory.Open<SoundEntries>()?.Where(c => c.Id == this.ExplorationSoundId).FirstOrDefault();
        }

        public CreatureDisplayInfo? GetMaleDisplayIdCreatureDisplayInfo()
        {
               return DbcDirectory.Open<CreatureDisplayInfo>()?.Where(c => c.Id == this.MaleDisplayId).FirstOrDefault();
        }

        public CreatureDisplayInfo? GetFemaleDisplayIdCreatureDisplayInfo()
        {
               return DbcDirectory.Open<CreatureDisplayInfo>()?.Where(c => c.Id == this.FemaleDisplayId).FirstOrDefault();
        }

        public Languages? GetBaseLanguageLanguages()
        {
               return DbcDirectory.Open<Languages>()?.Where(c => c.Id == this.BaseLanguage).FirstOrDefault();
        }

        public CreatureType? GetCreatureTypeCreatureType()
        {
               return DbcDirectory.Open<CreatureType>()?.Where(c => c.Id == this.CreatureType).FirstOrDefault();
        }

        public Spell? GetResSicknessSpellIdSpell()
        {
               return DbcDirectory.Open<Spell>()?.Where(c => c.Id == this.ResSicknessSpellId).FirstOrDefault();
        }

        public SoundEntries? GetSplashSoundIdSoundEntries()
        {
               return DbcDirectory.Open<SoundEntries>()?.Where(c => c.Id == this.SplashSoundId).FirstOrDefault();
        }

        public CinematicSequences? GetCinematicSequenceIdCinematicSequences()
        {
               return DbcDirectory.Open<CinematicSequences>()?.Where(c => c.Id == this.CinematicSequenceId).FirstOrDefault();
        }

     }
}
