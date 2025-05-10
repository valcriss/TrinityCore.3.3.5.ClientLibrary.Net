using TrinityCore._3._3._5.ClientLibrary.Dbc.Attributes;
using TrinityCore._3._3._5.ClientLibrary.Dbc.Enums;

namespace TrinityCore._3._3._5.ClientLibrary.Dbc.Definitions;

[DbcFile("CreatureDisplayInfo.dbc")]
public class CreatureDisplayInfo : DbcFile
{
    [DbcColumn(0, DbcColumnDataType.Int32)]
    public int Id { get; set; }

    [DbcColumn(1, DbcColumnDataType.Int32)]
    public int ModelId { get; set; }

    [DbcColumn(2, DbcColumnDataType.Int32)]
    public int SoundId { get; set; }

    [DbcColumn(3, DbcColumnDataType.Int32)]
    public int ExtendedDisplayInfoId { get; set; }

    [DbcColumn(4, DbcColumnDataType.Float)]
    public float CreatureModelScale { get; set; }

    [DbcColumn(5, DbcColumnDataType.Int32)]
    public int CreatureModelAlpha { get; set; }

    [DbcColumn(6, DbcColumnDataType.ArrayOfStringRef, 3)]
    public string[]? TextureVariation { get; set; }

    [DbcColumn(7, DbcColumnDataType.StringRef)]
    public string? PortraitTextureName { get; set; }

    [DbcColumn(8, DbcColumnDataType.Int32)]
    public int SizeClass { get; set; }

    [DbcColumn(9, DbcColumnDataType.Int32)]
    public int BloodId { get; set; }

    [DbcColumn(10, DbcColumnDataType.Int32)]
    public int NPCSoundId { get; set; }

    [DbcColumn(11, DbcColumnDataType.Int32)]
    public int ParticleColorId { get; set; }

    [DbcColumn(12, DbcColumnDataType.Int32)]
    public int CreatureGeosetData { get; set; }

    [DbcColumn(13, DbcColumnDataType.Int32)]
    public int ObjectEffectPackageId { get; set; }

    public CreatureModelData? GetModelIdCreatureModelData()
    {
        return DbcDirectory.Open<CreatureModelData>()?.Where(c => c.Id == ModelId).FirstOrDefault();
    }

    public CreatureSoundData? GetSoundIdCreatureSoundData()
    {
        return DbcDirectory.Open<CreatureSoundData>()?.Where(c => c.Id == SoundId).FirstOrDefault();
    }

    public CreatureDisplayInfoExtra? GetExtendedDisplayInfoIdCreatureDisplayInfoExtra()
    {
        return DbcDirectory.Open<CreatureDisplayInfoExtra>()?.Where(c => c.Id == ExtendedDisplayInfoId).FirstOrDefault();
    }

    public UnitBlood? GetBloodIdUnitBlood()
    {
        return DbcDirectory.Open<UnitBlood>()?.Where(c => c.Id == BloodId).FirstOrDefault();
    }

    public NPCSounds? GetNPCSoundIdNPCSounds()
    {
        return DbcDirectory.Open<NPCSounds>()?.Where(c => c.Id == NPCSoundId).FirstOrDefault();
    }

    public ParticleColor? GetParticleColorIdParticleColor()
    {
        return DbcDirectory.Open<ParticleColor>()?.Where(c => c.Id == ParticleColorId).FirstOrDefault();
    }

    public ObjectEffectPackage? GetObjectEffectPackageIdObjectEffectPackage()
    {
        return DbcDirectory.Open<ObjectEffectPackage>()?.Where(c => c.Id == ObjectEffectPackageId).FirstOrDefault();
    }
}