using TrinityCore._3._3._5.ClientLibrary.Dbc.Attributes;
using TrinityCore._3._3._5.ClientLibrary.Dbc.Enums;

namespace TrinityCore._3._3._5.ClientLibrary.Dbc.Definitions;

[DbcFile("ItemDisplayInfo.dbc")]
public class ItemDisplayInfo : DbcFile
{
    [DbcColumn(0, DbcColumnDataType.Int32)]
    public int Id { get; set; }

    [DbcColumn(1, DbcColumnDataType.ArrayOfStringRef, 2)]
    public string[]? ModelName { get; set; }

    [DbcColumn(2, DbcColumnDataType.ArrayOfStringRef, 2)]
    public string[]? ModelTexture { get; set; }

    [DbcColumn(3, DbcColumnDataType.ArrayOfStringRef, 2)]
    public string[]? InventoryIcon { get; set; }

    [DbcColumn(4, DbcColumnDataType.ArrayOfUint32, 3)]
    public int[]? GeosetGroup { get; set; }

    [DbcColumn(5, DbcColumnDataType.Int32)]
    public int Flags { get; set; }

    [DbcColumn(6, DbcColumnDataType.Int32)]
    public int SpellVisualId { get; set; }

    [DbcColumn(7, DbcColumnDataType.Int32)]
    public int GroupSoundIndex { get; set; }

    [DbcColumn(8, DbcColumnDataType.ArrayOfUint32, 2)]
    public int[]? HelmetGeosetVisId { get; set; }

    [DbcColumn(9, DbcColumnDataType.ArrayOfStringRef, 8)]
    public string[]? Texture { get; set; }

    [DbcColumn(10, DbcColumnDataType.Int32)]
    public int ItemVisual { get; set; }

    [DbcColumn(11, DbcColumnDataType.Int32)]
    public int ParticleColorId { get; set; }

    public SpellVisual? GetSpellVisualIdSpellVisual()
    {
        return DbcDirectory.Open<SpellVisual>()?.Where(c => c.Id == SpellVisualId).FirstOrDefault();
    }

    public ParticleColor? GetParticleColorIdParticleColor()
    {
        return DbcDirectory.Open<ParticleColor>()?.Where(c => c.Id == ParticleColorId).FirstOrDefault();
    }
}