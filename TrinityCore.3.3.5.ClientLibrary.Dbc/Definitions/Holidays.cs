using TrinityCore._3._3._5.ClientLibrary.Dbc.Attributes;

namespace TrinityCore._3._3._5.ClientLibrary.Dbc.Definitions
{
    [DbcFile("Holidays.dbc")]
    public class Holidays : DbcFile
    {
        [DbcColumn(0, Enums.DbcColumnDataType.Int32)]
        public int Id { get; set; }

        [DbcColumn(1, Enums.DbcColumnDataType.ArrayOfUint32, 10)]
        public int[]? Duration { get; set; }

        [DbcColumn(2, Enums.DbcColumnDataType.ArrayOfUint32, 26)]
        public int[]? Date { get; set; }

        [DbcColumn(3, Enums.DbcColumnDataType.Int32)]
        public int Region { get; set; }

        [DbcColumn(4, Enums.DbcColumnDataType.Int32)]
        public int Looping { get; set; }

        [DbcColumn(5, Enums.DbcColumnDataType.ArrayOfUint32, 10)]
        public int[]? CalendarFlags { get; set; }

        [DbcColumn(6, Enums.DbcColumnDataType.Int32)]
        public int HolidayNameId { get; set; }

        [DbcColumn(7, Enums.DbcColumnDataType.Int32)]
        public int HolidayDescriptionId { get; set; }

        [DbcColumn(8, Enums.DbcColumnDataType.StringRef)]
        public string? TextureFileName { get; set; }

        [DbcColumn(9, Enums.DbcColumnDataType.Int32)]
        public int Priority { get; set; }

        [DbcColumn(10, Enums.DbcColumnDataType.Int32)]
        public int CalendarFilterType { get; set; }

        [DbcColumn(11, Enums.DbcColumnDataType.Int32)]
        public int Flags { get; set; }

        public HolidayNames? GetHolidayNameIdHolidayNames()
        {
               return DbcDirectory.Open<HolidayNames>()?.Where(c => c.Id == this.HolidayNameId).FirstOrDefault();
        }

        public HolidayDescriptions? GetHolidayDescriptionIdHolidayDescriptions()
        {
               return DbcDirectory.Open<HolidayDescriptions>()?.Where(c => c.Id == this.HolidayDescriptionId).FirstOrDefault();
        }

     }
}
