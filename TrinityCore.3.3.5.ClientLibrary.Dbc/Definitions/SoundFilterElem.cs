using TrinityCore._3._3._5.ClientLibrary.Dbc.Attributes;
using TrinityCore._3._3._5.ClientLibrary.Dbc.Enums;

namespace TrinityCore._3._3._5.ClientLibrary.Dbc.Definitions;

[DbcFile("SoundFilterElem.dbc")]
public class SoundFilterElem : DbcFile
{
    [DbcColumn(0, DbcColumnDataType.Int32)]
    public int Id { get; set; }

    [DbcColumn(1, DbcColumnDataType.Int32)]
    public int SoundFilterId { get; set; }

    [DbcColumn(2, DbcColumnDataType.Int32)]
    public int OrderIndex { get; set; }

    [DbcColumn(3, DbcColumnDataType.Int32)]
    public int FilterType { get; set; }

    [DbcColumn(4, DbcColumnDataType.ArrayOfFloat, 9)]
    public float[]? Params { get; set; }

    public SoundFilter? GetSoundFilterIdSoundFilter()
    {
        return DbcDirectory.Open<SoundFilter>()?.Where(c => c.Id == SoundFilterId).FirstOrDefault();
    }
}