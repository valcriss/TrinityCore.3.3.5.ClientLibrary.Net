using TrinityCore._3._3._5.ClientLibrary.Dbc.Attributes;
using TrinityCore._3._3._5.ClientLibrary.Dbc.Enums;

namespace TrinityCore._3._3._5.ClientLibrary.Dbc.Definitions;

[DbcFile("DeclinedWordCases.dbc")]
public class DeclinedWordCases : DbcFile
{
    [DbcColumn(0, DbcColumnDataType.Int32)]
    public int Id { get; set; }

    [DbcColumn(1, DbcColumnDataType.Int32)]
    public int DeclinedWordId { get; set; }

    [DbcColumn(2, DbcColumnDataType.Int32)]
    public int CaseIndex { get; set; }

    [DbcColumn(3, DbcColumnDataType.StringRef)]
    public string? DeclinedWord { get; set; }

    public DeclinedWord? GetDeclinedWordIdDeclinedWord()
    {
        return DbcDirectory.Open<DeclinedWord>()?.Where(c => c.Id == DeclinedWordId).FirstOrDefault();
    }
}