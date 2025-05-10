using TrinityCore._3._3._5.ClientLibrary.Dbc.Attributes;
using TrinityCore._3._3._5.ClientLibrary.Dbc.Enums;

namespace TrinityCore._3._3._5.ClientLibrary.Dbc.Definitions;

[DbcFile("WeaponImpactSounds.dbc")]
public class WeaponImpactSounds : DbcFile
{
    [DbcColumn(0, DbcColumnDataType.Int32)]
    public int Id { get; set; }

    [DbcColumn(1, DbcColumnDataType.Int32)]
    public int WeaponSubClassId { get; set; }

    [DbcColumn(2, DbcColumnDataType.Int32)]
    public int ParrySoundType { get; set; }

    [DbcColumn(3, DbcColumnDataType.ArrayOfUint32, 10)]
    public int[]? ImpactSoundId { get; set; }

    [DbcColumn(4, DbcColumnDataType.ArrayOfUint32, 10)]
    public int[]? CritImpactSoundId { get; set; }

    public SoundEntries[]? GetImpactSoundIdSoundEntriess()
    {
        return DbcDirectory.Open<SoundEntries>()?.Where(c => ImpactSoundId != null && ImpactSoundId.Contains(c.Id)).ToArray();
    }

    public SoundEntries[]? GetCritImpactSoundIdSoundEntriess()
    {
        return DbcDirectory.Open<SoundEntries>()?.Where(c => CritImpactSoundId != null && CritImpactSoundId.Contains(c.Id)).ToArray();
    }
}