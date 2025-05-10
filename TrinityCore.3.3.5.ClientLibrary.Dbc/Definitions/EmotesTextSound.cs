using TrinityCore._3._3._5.ClientLibrary.Dbc.Attributes;
using TrinityCore._3._3._5.ClientLibrary.Dbc.Enums;

namespace TrinityCore._3._3._5.ClientLibrary.Dbc.Definitions;

[DbcFile("EmotesTextSound.dbc")]
public class EmotesTextSound : DbcFile
{
    [DbcColumn(0, DbcColumnDataType.Int32)]
    public int Id { get; set; }

    [DbcColumn(1, DbcColumnDataType.Int32)]
    public int EmotesTextId { get; set; }

    [DbcColumn(2, DbcColumnDataType.Int32)]
    public int RaceId { get; set; }

    [DbcColumn(3, DbcColumnDataType.Int32)]
    public int SexId { get; set; }

    [DbcColumn(4, DbcColumnDataType.Int32)]
    public int SoundId { get; set; }

    public EmotesText? GetEmotesTextIdEmotesText()
    {
        return DbcDirectory.Open<EmotesText>()?.Where(c => c.Id == EmotesTextId).FirstOrDefault();
    }

    public ChrRaces? GetRaceIdChrRaces()
    {
        return DbcDirectory.Open<ChrRaces>()?.Where(c => c.Id == RaceId).FirstOrDefault();
    }

    public SoundEntries? GetSoundIdSoundEntries()
    {
        return DbcDirectory.Open<SoundEntries>()?.Where(c => c.Id == SoundId).FirstOrDefault();
    }
}