using TrinityCore._3._3._5.ClientLibrary.Dbc.Attributes;
using TrinityCore._3._3._5.ClientLibrary.Dbc.Enums;

namespace TrinityCore._3._3._5.ClientLibrary.Dbc.Definitions;

[DbcFile("SoundEntries.dbc")]
public class SoundEntries : DbcFile
{
    [DbcColumn(0, DbcColumnDataType.Int32)]
    public int Id { get; set; }

    [DbcColumn(1, DbcColumnDataType.Int32)]
    public int SoundType { get; set; }

    [DbcColumn(2, DbcColumnDataType.StringRef)]
    public string? Name { get; set; }

    [DbcColumn(3, DbcColumnDataType.ArrayOfStringRef, 10)]
    public string[]? File { get; set; }

    [DbcColumn(4, DbcColumnDataType.ArrayOfUint32, 10)]
    public int[]? Freq { get; set; }

    [DbcColumn(5, DbcColumnDataType.StringRef)]
    public string? DirectoryBase { get; set; }

    [DbcColumn(6, DbcColumnDataType.Float)]
    public float VolumeFloat { get; set; }

    [DbcColumn(7, DbcColumnDataType.Int32)]
    public int Flags { get; set; }

    [DbcColumn(8, DbcColumnDataType.Float)]
    public float MinDistance { get; set; }

    [DbcColumn(9, DbcColumnDataType.Float)]
    public float DistanceCutoff { get; set; }

    [DbcColumn(10, DbcColumnDataType.Int32)]
    public int EAXDef { get; set; }

    [DbcColumn(11, DbcColumnDataType.Int32)]
    public int SoundEntriesAdvancedId { get; set; }

    public SoundEntriesAdvanced? GetSoundEntriesAdvancedIdSoundEntriesAdvanced()
    {
        return DbcDirectory.Open<SoundEntriesAdvanced>()?.Where(c => c.Id == SoundEntriesAdvancedId).FirstOrDefault();
    }
}