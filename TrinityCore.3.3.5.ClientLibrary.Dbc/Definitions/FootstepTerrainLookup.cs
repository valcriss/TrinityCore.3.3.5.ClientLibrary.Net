using TrinityCore._3._3._5.ClientLibrary.Dbc.Attributes;
using TrinityCore._3._3._5.ClientLibrary.Dbc.Enums;

namespace TrinityCore._3._3._5.ClientLibrary.Dbc.Definitions;

[DbcFile("FootstepTerrainLookup.dbc")]
public class FootstepTerrainLookup : DbcFile
{
    [DbcColumn(0, DbcColumnDataType.Int32)]
    public int Id { get; set; }

    [DbcColumn(1, DbcColumnDataType.Int32)]
    public int CreatureFootstepId { get; set; }

    [DbcColumn(2, DbcColumnDataType.Int32)]
    public int TerrainSoundId { get; set; }

    [DbcColumn(3, DbcColumnDataType.Int32)]
    public int SoundId { get; set; }

    [DbcColumn(4, DbcColumnDataType.Int32)]
    public int SoundIdSplash { get; set; }

    public TerrainType? GetTerrainSoundIdTerrainType()
    {
        return DbcDirectory.Open<TerrainType>()?.Where(c => c.TerrainId == TerrainSoundId).FirstOrDefault();
    }

    public SoundEntries? GetSoundIdSoundEntries()
    {
        return DbcDirectory.Open<SoundEntries>()?.Where(c => c.Id == SoundId).FirstOrDefault();
    }

    public SoundEntries? GetSoundIdSplashSoundEntries()
    {
        return DbcDirectory.Open<SoundEntries>()?.Where(c => c.Id == SoundIdSplash).FirstOrDefault();
    }
}