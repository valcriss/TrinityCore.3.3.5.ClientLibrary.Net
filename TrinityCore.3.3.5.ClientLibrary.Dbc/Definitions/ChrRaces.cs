using TrinityCore._3._3._5.ClientLibrary.Dbc.Attributes;
using TrinityCore._3._3._5.ClientLibrary.Dbc.Enums;

namespace TrinityCore._3._3._5.ClientLibrary.Dbc.Definitions;

[DbcFile("ChrRaces.dbc")]
public class ChrRaces : DbcFile
{
    [DbcColumn(0, DbcColumnDataType.Int32)]
    public int Id { get; set; }

    [DbcColumn(1, DbcColumnDataType.Int32)]
    public int Flags { get; set; }

    [DbcColumn(2, DbcColumnDataType.Int32)]
    public int FactionId { get; set; }

    [DbcColumn(3, DbcColumnDataType.Int32)]
    public int ExplorationSoundId { get; set; }

    [DbcColumn(4, DbcColumnDataType.Int32)]
    public int MaleDisplayId { get; set; }

    [DbcColumn(5, DbcColumnDataType.Int32)]
    public int FemaleDisplayId { get; set; }

    [DbcColumn(6, DbcColumnDataType.StringRef)]
    public string? ClientPrefix { get; set; }

    [DbcColumn(7, DbcColumnDataType.Int32)]
    public int BaseLanguage { get; set; }

    [DbcColumn(8, DbcColumnDataType.Int32)]
    public int CreatureType { get; set; }

    [DbcColumn(9, DbcColumnDataType.Int32)]
    public int ResSicknessSpellId { get; set; }

    [DbcColumn(10, DbcColumnDataType.Int32)]
    public int SplashSoundId { get; set; }

    [DbcColumn(11, DbcColumnDataType.StringRef)]
    public string? ClientFileString { get; set; }

    [DbcColumn(12, DbcColumnDataType.Int32)]
    public int CinematicSequenceId { get; set; }

    [DbcColumn(13, DbcColumnDataType.Int32)]
    public int Alliance { get; set; }

    [DbcColumn(14, DbcColumnDataType.Loc)]
    public string? NameLang { get; set; }

    [DbcColumn(15, DbcColumnDataType.Loc)]
    public string? NameFemale { get; set; }

    [DbcColumn(16, DbcColumnDataType.Loc)]
    public string? NameMale { get; set; }

    [DbcColumn(17, DbcColumnDataType.ArrayOfStringRef, 2)]
    public string[]? FacialHairCustomization { get; set; }

    [DbcColumn(18, DbcColumnDataType.StringRef)]
    public string? HairCustomization { get; set; }

    [DbcColumn(19, DbcColumnDataType.Int32)]
    public int RequiredExpansion { get; set; }

    public FactionTemplate? GetFactionIdFactionTemplate()
    {
        return DbcDirectory.Open<FactionTemplate>()?.Where(c => c.Id == FactionId).FirstOrDefault();
    }

    public SoundEntries? GetExplorationSoundIdSoundEntries()
    {
        return DbcDirectory.Open<SoundEntries>()?.Where(c => c.Id == ExplorationSoundId).FirstOrDefault();
    }

    public CreatureDisplayInfo? GetMaleDisplayIdCreatureDisplayInfo()
    {
        return DbcDirectory.Open<CreatureDisplayInfo>()?.Where(c => c.Id == MaleDisplayId).FirstOrDefault();
    }

    public CreatureDisplayInfo? GetFemaleDisplayIdCreatureDisplayInfo()
    {
        return DbcDirectory.Open<CreatureDisplayInfo>()?.Where(c => c.Id == FemaleDisplayId).FirstOrDefault();
    }

    public Languages? GetBaseLanguageLanguages()
    {
        return DbcDirectory.Open<Languages>()?.Where(c => c.Id == BaseLanguage).FirstOrDefault();
    }

    public CreatureType? GetCreatureTypeCreatureType()
    {
        return DbcDirectory.Open<CreatureType>()?.Where(c => c.Id == CreatureType).FirstOrDefault();
    }

    public Spell? GetResSicknessSpellIdSpell()
    {
        return DbcDirectory.Open<Spell>()?.Where(c => c.Id == ResSicknessSpellId).FirstOrDefault();
    }

    public SoundEntries? GetSplashSoundIdSoundEntries()
    {
        return DbcDirectory.Open<SoundEntries>()?.Where(c => c.Id == SplashSoundId).FirstOrDefault();
    }

    public CinematicSequences? GetCinematicSequenceIdCinematicSequences()
    {
        return DbcDirectory.Open<CinematicSequences>()?.Where(c => c.Id == CinematicSequenceId).FirstOrDefault();
    }
}