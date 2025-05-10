using TrinityCore._3._3._5.ClientLibrary.Dbc.Attributes;
using TrinityCore._3._3._5.ClientLibrary.Dbc.Enums;

namespace TrinityCore._3._3._5.ClientLibrary.Dbc.Definitions;

[DbcFile("WeaponSwingSounds2.dbc")]
public class WeaponSwingSounds2 : DbcFile
{
    [DbcColumn(0, DbcColumnDataType.Int32)]
    public int Id { get; set; }

    [DbcColumn(1, DbcColumnDataType.Int32)]
    public int SwingType { get; set; }

    [DbcColumn(2, DbcColumnDataType.Int32)]
    public int Crit { get; set; }

    [DbcColumn(3, DbcColumnDataType.Int32)]
    public int SoundId { get; set; }

    public SoundEntries? GetSoundIdSoundEntries()
    {
        return DbcDirectory.Open<SoundEntries>()?.Where(c => c.Id == SoundId).FirstOrDefault();
    }
}