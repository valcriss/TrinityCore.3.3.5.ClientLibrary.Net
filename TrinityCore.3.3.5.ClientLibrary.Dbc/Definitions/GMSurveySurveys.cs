using TrinityCore._3._3._5.ClientLibrary.Dbc.Attributes;
using TrinityCore._3._3._5.ClientLibrary.Dbc.Enums;

namespace TrinityCore._3._3._5.ClientLibrary.Dbc.Definitions;

[DbcFile("GMSurveySurveys.dbc")]
public class GMSurveySurveys : DbcFile
{
    [DbcColumn(0, DbcColumnDataType.Int32)]
    public int Id { get; set; }

    [DbcColumn(1, DbcColumnDataType.ArrayOfUint32, 10)]
    public int[]? Q { get; set; }

    public GMSurveyQuestions[]? GetQGMSurveyQuestionss()
    {
        return DbcDirectory.Open<GMSurveyQuestions>()?.Where(c => Q != null && Q.Contains(c.Id)).ToArray();
    }
}