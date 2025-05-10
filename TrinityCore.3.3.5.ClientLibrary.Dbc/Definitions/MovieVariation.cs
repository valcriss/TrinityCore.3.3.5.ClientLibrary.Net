using TrinityCore._3._3._5.ClientLibrary.Dbc.Attributes;

namespace TrinityCore._3._3._5.ClientLibrary.Dbc.Definitions
{
    [DbcFile("MovieVariation.dbc")]
    public class MovieVariation : DbcFile
    {
        [DbcColumn(0, Enums.DbcColumnDataType.Int32)]
        public int Id { get; set; }

        [DbcColumn(1, Enums.DbcColumnDataType.Int32)]
        public int MovieId { get; set; }

        [DbcColumn(2, Enums.DbcColumnDataType.Int32)]
        public int FileDataId { get; set; }

        public Movie? GetMovieIdMovie()
        {
               return DbcDirectory.Open<Movie>()?.Where(c => c.Id == this.MovieId).FirstOrDefault();
        }

        public FileData? GetFileDataIdFileData()
        {
               return DbcDirectory.Open<FileData>()?.Where(c => c.Id == this.FileDataId).FirstOrDefault();
        }

     }
}
