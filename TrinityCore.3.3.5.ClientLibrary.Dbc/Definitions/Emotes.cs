using TrinityCore._3._3._5.ClientLibrary.Dbc.Attributes;
using TrinityCore._3._3._5.ClientLibrary.Dbc.Enums;

namespace TrinityCore._3._3._5.ClientLibrary.Dbc.Definitions;

[DbcFile("Emotes.dbc")]
public class Emotes : DbcFile
{
    [DbcColumn(0, DbcColumnDataType.Int32)]
    public int Id { get; set; }

    [DbcColumn(1, DbcColumnDataType.StringRef)]
    public string? EmoteSlashCommand { get; set; }

    [DbcColumn(2, DbcColumnDataType.Int32)]
    public int AnimId { get; set; }

    [DbcColumn(3, DbcColumnDataType.Int32)]
    public int EmoteFlags { get; set; }

    [DbcColumn(4, DbcColumnDataType.Int32)]
    public int EmoteSpecProc { get; set; }

    [DbcColumn(5, DbcColumnDataType.Int32)]
    public int EmoteSpecProcParam { get; set; }

    [DbcColumn(6, DbcColumnDataType.Int32)]
    public int EventSoundId { get; set; }

    public AnimationData? GetAnimIdAnimationData()
    {
        return DbcDirectory.Open<AnimationData>()?.Where(c => c.Id == AnimId).FirstOrDefault();
    }

    public SoundEntries? GetEventSoundIdSoundEntries()
    {
        return DbcDirectory.Open<SoundEntries>()?.Where(c => c.Id == EventSoundId).FirstOrDefault();
    }
}