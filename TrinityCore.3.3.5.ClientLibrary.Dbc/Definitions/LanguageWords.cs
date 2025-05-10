using TrinityCore._3._3._5.ClientLibrary.Dbc.Attributes;

namespace TrinityCore._3._3._5.ClientLibrary.Dbc.Definitions
{
    [DbcFile("LanguageWords.dbc")]
    public class LanguageWords : DbcFile
    {
        [DbcColumn(0, Enums.DbcColumnDataType.Int32)]
        public int Id { get; set; }

        [DbcColumn(1, Enums.DbcColumnDataType.Int32)]
        public int LanguageId { get; set; }

        [DbcColumn(2, Enums.DbcColumnDataType.StringRef)]
        public string? Word { get; set; }

        public Languages? GetLanguageIdLanguages()
        {
               return DbcDirectory.Open<Languages>()?.Where(c => c.Id == this.LanguageId).FirstOrDefault();
        }

     }
}
