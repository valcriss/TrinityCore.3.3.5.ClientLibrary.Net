using TrinityCore._3._3._5.ClientLibrary.Dbc.Attributes;
using TrinityCore._3._3._5.ClientLibrary.Dbc.Enums;

namespace TrinityCore._3._3._5.ClientLibrary.Dbc.Definitions;

[DbcFile("MovieVariation.dbc")]
public class MovieVariation : DbcFile
{
    [DbcColumn(0, DbcColumnDataType.Int32)]
    public int Id { get; set; }

    [DbcColumn(1, DbcColumnDataType.Int32)]
    public int MovieId { get; set; }

    [DbcColumn(2, DbcColumnDataType.Int32)]
    public int FileDataId { get; set; }

    public Movie? GetMovieIdMovie()
    {
        return DbcDirectory.Open<Movie>()?.Where(c => c.Id == MovieId).FirstOrDefault();
    }

    public FileData? GetFileDataIdFileData()
    {
        return DbcDirectory.Open<FileData>()?.Where(c => c.Id == FileDataId).FirstOrDefault();
    }
}