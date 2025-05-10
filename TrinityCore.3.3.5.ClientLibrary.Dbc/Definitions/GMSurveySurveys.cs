using TrinityCore._3._3._5.ClientLibrary.Dbc.Attributes;

namespace TrinityCore._3._3._5.ClientLibrary.Dbc.Definitions
{
    [DbcFile("GMSurveySurveys.dbc")]
    public class GMSurveySurveys : DbcFile
    {
        [DbcColumn(0, Enums.DbcColumnDataType.Int32)]
        public int Id { get; set; }

        [DbcColumn(1, Enums.DbcColumnDataType.ArrayOfUint32, 10)]
        public int[]? Q { get; set; }

        public GMSurveyQuestions[]? GetQGMSurveyQuestionss()
        {
               return DbcDirectory.Open<GMSurveyQuestions>()?.Where(c => this.Q != null && this.Q.Contains(c.Id)).ToArray();
        }

     }
}
