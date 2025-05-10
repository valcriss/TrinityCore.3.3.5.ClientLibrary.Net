using TrinityCore._3._3._5.ClientLibrary.Dbc.Attributes;

namespace TrinityCore._3._3._5.ClientLibrary.Dbc.Definitions
{
    [DbcFile("GMSurveyCurrentSurvey.dbc")]
    public class GMSurveyCurrentSurvey : DbcFile
    {
        [DbcColumn(0, Enums.DbcColumnDataType.Int32)]
        public int LANGId { get; set; }

        [DbcColumn(1, Enums.DbcColumnDataType.Int32)]
        public int GMSURVEYId { get; set; }

        public GMSurveySurveys? GetGMSURVEYIdGMSurveySurveys()
        {
               return DbcDirectory.Open<GMSurveySurveys>()?.Where(c => c.Id == this.GMSURVEYId).FirstOrDefault();
        }

     }
}
