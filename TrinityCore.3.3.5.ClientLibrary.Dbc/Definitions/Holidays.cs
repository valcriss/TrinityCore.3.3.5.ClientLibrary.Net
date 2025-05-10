using TrinityCore._3._3._5.ClientLibrary.Dbc.Attributes;
using TrinityCore._3._3._5.ClientLibrary.Dbc.Enums;

namespace TrinityCore._3._3._5.ClientLibrary.Dbc.Definitions;

[DbcFile("Holidays.dbc")]
public class Holidays : DbcFile
{
    [DbcColumn(0, DbcColumnDataType.Int32)]
    public int Id { get; set; }

    [DbcColumn(1, DbcColumnDataType.ArrayOfUint32, 10)]
    public int[]? Duration { get; set; }

    [DbcColumn(2, DbcColumnDataType.ArrayOfUint32, 26)]
    public int[]? Date { get; set; }

    [DbcColumn(3, DbcColumnDataType.Int32)]
    public int Region { get; set; }

    [DbcColumn(4, DbcColumnDataType.Int32)]
    public int Looping { get; set; }

    [DbcColumn(5, DbcColumnDataType.ArrayOfUint32, 10)]
    public int[]? CalendarFlags { get; set; }

    [DbcColumn(6, DbcColumnDataType.Int32)]
    public int HolidayNameId { get; set; }

    [DbcColumn(7, DbcColumnDataType.Int32)]
    public int HolidayDescriptionId { get; set; }

    [DbcColumn(8, DbcColumnDataType.StringRef)]
    public string? TextureFileName { get; set; }

    [DbcColumn(9, DbcColumnDataType.Int32)]
    public int Priority { get; set; }

    [DbcColumn(10, DbcColumnDataType.Int32)]
    public int CalendarFilterType { get; set; }

    [DbcColumn(11, DbcColumnDataType.Int32)]
    public int Flags { get; set; }

    public HolidayNames? GetHolidayNameIdHolidayNames()
    {
        return DbcDirectory.Open<HolidayNames>()?.Where(c => c.Id == HolidayNameId).FirstOrDefault();
    }

    public HolidayDescriptions? GetHolidayDescriptionIdHolidayDescriptions()
    {
        return DbcDirectory.Open<HolidayDescriptions>()?.Where(c => c.Id == HolidayDescriptionId).FirstOrDefault();
    }
}