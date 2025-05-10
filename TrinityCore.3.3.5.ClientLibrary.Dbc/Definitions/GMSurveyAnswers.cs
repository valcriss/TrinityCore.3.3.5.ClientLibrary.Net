using TrinityCore._3._3._5.ClientLibrary.Dbc.Attributes;
using TrinityCore._3._3._5.ClientLibrary.Dbc.Enums;

namespace TrinityCore._3._3._5.ClientLibrary.Dbc.Definitions;

[DbcFile("GMSurveyAnswers.dbc")]
public class GMSurveyAnswers : DbcFile
{
    [DbcColumn(0, DbcColumnDataType.Int32)]
    public int Id { get; set; }

    [DbcColumn(1, DbcColumnDataType.Int32)]
    public int SortIndex { get; set; }

    [DbcColumn(2, DbcColumnDataType.Int32)]
    public int GMSurveyQuestionId { get; set; }

    [DbcColumn(3, DbcColumnDataType.Loc)]
    public string? Answer { get; set; }

    public GMSurveyQuestions? GetGMSurveyQuestionIdGMSurveyQuestions()
    {
        return DbcDirectory.Open<GMSurveyQuestions>()?.Where(c => c.Id == GMSurveyQuestionId).FirstOrDefault();
    }
}