using TrinityCore._3._3._5.ClientLibrary.Dbc.Attributes;
using TrinityCore._3._3._5.ClientLibrary.Dbc.Enums;

namespace TrinityCore._3._3._5.ClientLibrary.Dbc.Definitions;

[DbcFile("DeathThudLookups.dbc")]
public class DeathThudLookups : DbcFile
{
    [DbcColumn(0, DbcColumnDataType.Int32)]
    public int Id { get; set; }

    [DbcColumn(1, DbcColumnDataType.Int32)]
    public int SizeClass { get; set; }

    [DbcColumn(2, DbcColumnDataType.Int32)]
    public int TerrainTypeSoundId { get; set; }

    [DbcColumn(3, DbcColumnDataType.Int32)]
    public int SoundEntryId { get; set; }

    [DbcColumn(4, DbcColumnDataType.Int32)]
    public int SoundEntryIdWater { get; set; }

    public TerrainTypeSounds? GetTerrainTypeSoundIdTerrainTypeSounds()
    {
        return DbcDirectory.Open<TerrainTypeSounds>()?.Where(c => c.Id == TerrainTypeSoundId).FirstOrDefault();
    }

    public SoundEntries? GetSoundEntryIdSoundEntries()
    {
        return DbcDirectory.Open<SoundEntries>()?.Where(c => c.Id == SoundEntryId).FirstOrDefault();
    }

    public SoundEntries? GetSoundEntryIdWaterSoundEntries()
    {
        return DbcDirectory.Open<SoundEntries>()?.Where(c => c.Id == SoundEntryIdWater).FirstOrDefault();
    }
}