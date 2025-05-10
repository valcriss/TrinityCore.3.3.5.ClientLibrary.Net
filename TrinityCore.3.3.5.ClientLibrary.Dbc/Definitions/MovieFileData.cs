using TrinityCore._3._3._5.ClientLibrary.Dbc.Attributes;
using TrinityCore._3._3._5.ClientLibrary.Dbc.Enums;

namespace TrinityCore._3._3._5.ClientLibrary.Dbc.Definitions;

[DbcFile("MovieFileData.dbc")]
public class MovieFileData : DbcFile
{
    [DbcColumn(0, DbcColumnDataType.Int32)]
    public int FileDataId { get; set; }

    [DbcColumn(1, DbcColumnDataType.Int32)]
    public int Resolution { get; set; }

    public FileData? GetFileDataIdFileData()
    {
        return DbcDirectory.Open<FileData>()?.Where(c => c.Id == FileDataId).FirstOrDefault();
    }
}