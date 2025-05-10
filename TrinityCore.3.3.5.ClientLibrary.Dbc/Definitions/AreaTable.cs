using TrinityCore._3._3._5.ClientLibrary.Dbc.Attributes;
using TrinityCore._3._3._5.ClientLibrary.Dbc.Enums;

namespace TrinityCore._3._3._5.ClientLibrary.Dbc.Definitions;

[DbcFile("AreaTable.dbc")]
public class AreaTable : DbcFile
{
    [DbcColumn(0, DbcColumnDataType.Int32)]
    public int Id { get; set; }

    [DbcColumn(1, DbcColumnDataType.Int32)]
    public int ContinentId { get; set; }

    [DbcColumn(2, DbcColumnDataType.Int32)]
    public int ParentAreaId { get; set; }

    [DbcColumn(3, DbcColumnDataType.Int32)]
    public int AreaBit { get; set; }

    [DbcColumn(4, DbcColumnDataType.Int32)]
    public int Flags { get; set; }

    [DbcColumn(5, DbcColumnDataType.Int32)]
    public int SoundProviderPref { get; set; }

    [DbcColumn(6, DbcColumnDataType.Int32)]
    public int SoundProviderPrefUnderwater { get; set; }

    [DbcColumn(7, DbcColumnDataType.Int32)]
    public int AmbienceId { get; set; }

    [DbcColumn(8, DbcColumnDataType.Int32)]
    public int ZoneMusic { get; set; }

    [DbcColumn(9, DbcColumnDataType.Int32)]
    public int IntroSound { get; set; }

    [DbcColumn(10, DbcColumnDataType.Int32)]
    public int ExplorationLevel { get; set; }

    [DbcColumn(11, DbcColumnDataType.Loc)]
    public string? AreaNameLang { get; set; }

    [DbcColumn(12, DbcColumnDataType.Int32)]
    public int FactionGroupMask { get; set; }

    [DbcColumn(13, DbcColumnDataType.ArrayOfUint32, 4)]
    public int[]? LiquidTypeId { get; set; }

    [DbcColumn(14, DbcColumnDataType.Float)]
    public float MinElevation { get; set; }

    [DbcColumn(15, DbcColumnDataType.Float)]
    public float AmbientMultiplier { get; set; }

    [DbcColumn(16, DbcColumnDataType.Int32)]
    public int LightId { get; set; }

    public Map? GetContinentIdMap()
    {
        return DbcDirectory.Open<Map>()?.Where(c => c.Id == ContinentId).FirstOrDefault();
    }

    public AreaTable? GetParentAreaIdAreaTable()
    {
        return DbcDirectory.Open<AreaTable>()?.Where(c => c.Id == ParentAreaId).FirstOrDefault();
    }

    public SoundProviderPreferences? GetSoundProviderPrefSoundProviderPreferences()
    {
        return DbcDirectory.Open<SoundProviderPreferences>()?.Where(c => c.Id == SoundProviderPref).FirstOrDefault();
    }

    public SoundProviderPreferences? GetSoundProviderPrefUnderwaterSoundProviderPreferences()
    {
        return DbcDirectory.Open<SoundProviderPreferences>()?.Where(c => c.Id == SoundProviderPrefUnderwater).FirstOrDefault();
    }

    public SoundAmbience? GetAmbienceIdSoundAmbience()
    {
        return DbcDirectory.Open<SoundAmbience>()?.Where(c => c.Id == AmbienceId).FirstOrDefault();
    }

    public ZoneMusic? GetZoneMusicZoneMusic()
    {
        return DbcDirectory.Open<ZoneMusic>()?.Where(c => c.Id == ZoneMusic).FirstOrDefault();
    }

    public ZoneIntroMusicTable? GetIntroSoundZoneIntroMusicTable()
    {
        return DbcDirectory.Open<ZoneIntroMusicTable>()?.Where(c => c.Id == IntroSound).FirstOrDefault();
    }

    public LiquidType[]? GetLiquidTypeIdLiquidTypes()
    {
        return DbcDirectory.Open<LiquidType>()?.Where(c => LiquidTypeId != null && LiquidTypeId.Contains(c.Id)).ToArray();
    }

    public Light? GetLightIdLight()
    {
        return DbcDirectory.Open<Light>()?.Where(c => c.Id == LightId).FirstOrDefault();
    }
}