using TrinityCore._3._3._5.ClientLibrary.Dbc.Attributes;
using TrinityCore._3._3._5.ClientLibrary.Dbc.Enums;

namespace TrinityCore._3._3._5.ClientLibrary.Dbc.Definitions;

[DbcFile("EmotesText.dbc")]
public class EmotesText : DbcFile
{
    [DbcColumn(0, DbcColumnDataType.Int32)]
    public int Id { get; set; }

    [DbcColumn(1, DbcColumnDataType.StringRef)]
    public string? Name { get; set; }

    [DbcColumn(2, DbcColumnDataType.Int32)]
    public int EmoteId { get; set; }

    [DbcColumn(3, DbcColumnDataType.ArrayOfUint32, 16)]
    public int[]? EmoteText { get; set; }

    public Emotes? GetEmoteIdEmotes()
    {
        return DbcDirectory.Open<Emotes>()?.Where(c => c.Id == EmoteId).FirstOrDefault();
    }

    public EmotesTextData[]? GetEmoteTextEmotesTextDatas()
    {
        return DbcDirectory.Open<EmotesTextData>()?.Where(c => EmoteText != null && EmoteText.Contains(c.Id)).ToArray();
    }
}