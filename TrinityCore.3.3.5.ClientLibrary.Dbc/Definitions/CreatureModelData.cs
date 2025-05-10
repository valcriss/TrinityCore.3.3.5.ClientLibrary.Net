using TrinityCore._3._3._5.ClientLibrary.Dbc.Attributes;
using TrinityCore._3._3._5.ClientLibrary.Dbc.Enums;

namespace TrinityCore._3._3._5.ClientLibrary.Dbc.Definitions;

[DbcFile("CreatureModelData.dbc")]
public class CreatureModelData : DbcFile
{
    [DbcColumn(0, DbcColumnDataType.Int32)]
    public int Id { get; set; }

    [DbcColumn(1, DbcColumnDataType.Int32)]
    public int Flags { get; set; }

    [DbcColumn(2, DbcColumnDataType.StringRef)]
    public string? ModelName { get; set; }

    [DbcColumn(3, DbcColumnDataType.Int32)]
    public int SizeClass { get; set; }

    [DbcColumn(4, DbcColumnDataType.Float)]
    public float ModelScale { get; set; }

    [DbcColumn(5, DbcColumnDataType.Int32)]
    public int BloodId { get; set; }

    [DbcColumn(6, DbcColumnDataType.Int32)]
    public int FootprintTextureId { get; set; }

    [DbcColumn(7, DbcColumnDataType.Float)]
    public float FootprintTextureLength { get; set; }

    [DbcColumn(8, DbcColumnDataType.Float)]
    public float FootprintTextureWidth { get; set; }

    [DbcColumn(9, DbcColumnDataType.Float)]
    public float FootprintParticleScale { get; set; }

    [DbcColumn(10, DbcColumnDataType.Int32)]
    public int FoleyMaterialId { get; set; }

    [DbcColumn(11, DbcColumnDataType.Int32)]
    public int FootstepShakeSize { get; set; }

    [DbcColumn(12, DbcColumnDataType.Int32)]
    public int DeathThudShakeSize { get; set; }

    [DbcColumn(13, DbcColumnDataType.Int32)]
    public int SoundId { get; set; }

    [DbcColumn(14, DbcColumnDataType.Float)]
    public float CollisionWidth { get; set; }

    [DbcColumn(15, DbcColumnDataType.Float)]
    public float CollisionHeight { get; set; }

    [DbcColumn(16, DbcColumnDataType.Float)]
    public float MountHeight { get; set; }

    [DbcColumn(17, DbcColumnDataType.Float)]
    public float GeoBoxMinX { get; set; }

    [DbcColumn(18, DbcColumnDataType.Float)]
    public float GeoBoxMinY { get; set; }

    [DbcColumn(19, DbcColumnDataType.Float)]
    public float GeoBoxMinZ { get; set; }

    [DbcColumn(20, DbcColumnDataType.Float)]
    public float GeoBoxMaxX { get; set; }

    [DbcColumn(21, DbcColumnDataType.Float)]
    public float GeoBoxMaxY { get; set; }

    [DbcColumn(22, DbcColumnDataType.Float)]
    public float GeoBoxMaxZ { get; set; }

    [DbcColumn(23, DbcColumnDataType.Float)]
    public float WorldEffectScale { get; set; }

    [DbcColumn(24, DbcColumnDataType.Float)]
    public float AttachedEffectScale { get; set; }

    [DbcColumn(25, DbcColumnDataType.Float)]
    public float MissileCollisionRadius { get; set; }

    [DbcColumn(26, DbcColumnDataType.Float)]
    public float MissileCollisionPush { get; set; }

    [DbcColumn(27, DbcColumnDataType.Float)]
    public float MissileCollisionRaise { get; set; }

    public UnitBlood? GetBloodIdUnitBlood()
    {
        return DbcDirectory.Open<UnitBlood>()?.Where(c => c.Id == BloodId).FirstOrDefault();
    }

    public FootprintTextures? GetFootprintTextureIdFootprintTextures()
    {
        return DbcDirectory.Open<FootprintTextures>()?.Where(c => c.Id == FootprintTextureId).FirstOrDefault();
    }

    public Material? GetFoleyMaterialIdMaterial()
    {
        return DbcDirectory.Open<Material>()?.Where(c => c.Id == FoleyMaterialId).FirstOrDefault();
    }

    public CreatureSoundData? GetSoundIdCreatureSoundData()
    {
        return DbcDirectory.Open<CreatureSoundData>()?.Where(c => c.Id == SoundId).FirstOrDefault();
    }
}