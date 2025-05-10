using TrinityCore._3._3._5.ClientLibrary.Dbc.Attributes;
using TrinityCore._3._3._5.ClientLibrary.Dbc.Enums;

namespace TrinityCore._3._3._5.ClientLibrary.Dbc.Definitions;

[DbcFile("SoundEntriesAdvanced.dbc")]
public class SoundEntriesAdvanced : DbcFile
{
    [DbcColumn(0, DbcColumnDataType.Int32)]
    public int Id { get; set; }

    [DbcColumn(1, DbcColumnDataType.Int32)]
    public int SoundEntryId { get; set; }

    [DbcColumn(2, DbcColumnDataType.Float)]
    public float InnerRadius2D { get; set; }

    [DbcColumn(3, DbcColumnDataType.Int32)]
    public int TimeA { get; set; }

    [DbcColumn(4, DbcColumnDataType.Int32)]
    public int TimeB { get; set; }

    [DbcColumn(5, DbcColumnDataType.Int32)]
    public int TimeC { get; set; }

    [DbcColumn(6, DbcColumnDataType.Int32)]
    public int TimeD { get; set; }

    [DbcColumn(7, DbcColumnDataType.Int32)]
    public int RandomOffsetRange { get; set; }

    [DbcColumn(8, DbcColumnDataType.Int32)]
    public int Usage { get; set; }

    [DbcColumn(9, DbcColumnDataType.Int32)]
    public int TimeIntervalMin { get; set; }

    [DbcColumn(10, DbcColumnDataType.Int32)]
    public int TimeIntervalMax { get; set; }

    [DbcColumn(11, DbcColumnDataType.Int32)]
    public int VolumeSliderCategory { get; set; }

    [DbcColumn(12, DbcColumnDataType.Float)]
    public float DuckToSFX { get; set; }

    [DbcColumn(13, DbcColumnDataType.Float)]
    public float DuckToMusic { get; set; }

    [DbcColumn(14, DbcColumnDataType.Float)]
    public float DuckToAmbience { get; set; }

    [DbcColumn(15, DbcColumnDataType.Float)]
    public float InnerRadiusOfInfluence { get; set; }

    [DbcColumn(16, DbcColumnDataType.Float)]
    public float OuterRadiusOfInfluence { get; set; }

    [DbcColumn(17, DbcColumnDataType.Int32)]
    public int TimeToDuck { get; set; }

    [DbcColumn(18, DbcColumnDataType.Int32)]
    public int TimeToUnduck { get; set; }

    [DbcColumn(19, DbcColumnDataType.Float)]
    public float InsideAngle { get; set; }

    [DbcColumn(20, DbcColumnDataType.Float)]
    public float OutsideAngle { get; set; }

    [DbcColumn(21, DbcColumnDataType.Float)]
    public float OutsideVolume { get; set; }

    [DbcColumn(22, DbcColumnDataType.Float)]
    public float OuterRadius2D { get; set; }

    [DbcColumn(23, DbcColumnDataType.StringRef)]
    public string? Name { get; set; }

    public SoundEntries? GetSoundEntryIdSoundEntries()
    {
        return DbcDirectory.Open<SoundEntries>()?.Where(c => c.Id == SoundEntryId).FirstOrDefault();
    }
}