using TrinityCore._3._3._5.ClientLibrary.Dbc.Attributes;

namespace TrinityCore._3._3._5.ClientLibrary.Dbc.Definitions
{
    [DbcFile("CreatureDisplayInfo.dbc")]
    public class CreatureDisplayInfo : DbcFile
    {
        [DbcColumn(0, Enums.DbcColumnDataType.Int32)]
        public int Id { get; set; }

        [DbcColumn(1, Enums.DbcColumnDataType.Int32)]
        public int ModelId { get; set; }

        [DbcColumn(2, Enums.DbcColumnDataType.Int32)]
        public int SoundId { get; set; }

        [DbcColumn(3, Enums.DbcColumnDataType.Int32)]
        public int ExtendedDisplayInfoId { get; set; }

        [DbcColumn(4, Enums.DbcColumnDataType.Float)]
        public float CreatureModelScale { get; set; }

        [DbcColumn(5, Enums.DbcColumnDataType.Int32)]
        public int CreatureModelAlpha { get; set; }

        [DbcColumn(6, Enums.DbcColumnDataType.ArrayOfStringRef, 3)]
        public string[]? TextureVariation { get; set; }

        [DbcColumn(7, Enums.DbcColumnDataType.StringRef)]
        public string? PortraitTextureName { get; set; }

        [DbcColumn(8, Enums.DbcColumnDataType.Int32)]
        public int SizeClass { get; set; }

        [DbcColumn(9, Enums.DbcColumnDataType.Int32)]
        public int BloodId { get; set; }

        [DbcColumn(10, Enums.DbcColumnDataType.Int32)]
        public int NPCSoundId { get; set; }

        [DbcColumn(11, Enums.DbcColumnDataType.Int32)]
        public int ParticleColorId { get; set; }

        [DbcColumn(12, Enums.DbcColumnDataType.Int32)]
        public int CreatureGeosetData { get; set; }

        [DbcColumn(13, Enums.DbcColumnDataType.Int32)]
        public int ObjectEffectPackageId { get; set; }

        public CreatureModelData? GetModelIdCreatureModelData()
        {
               return DbcDirectory.Open<CreatureModelData>()?.Where(c => c.Id == this.ModelId).FirstOrDefault();
        }

        public CreatureSoundData? GetSoundIdCreatureSoundData()
        {
               return DbcDirectory.Open<CreatureSoundData>()?.Where(c => c.Id == this.SoundId).FirstOrDefault();
        }

        public CreatureDisplayInfoExtra? GetExtendedDisplayInfoIdCreatureDisplayInfoExtra()
        {
               return DbcDirectory.Open<CreatureDisplayInfoExtra>()?.Where(c => c.Id == this.ExtendedDisplayInfoId).FirstOrDefault();
        }

        public UnitBlood? GetBloodIdUnitBlood()
        {
               return DbcDirectory.Open<UnitBlood>()?.Where(c => c.Id == this.BloodId).FirstOrDefault();
        }

        public NPCSounds? GetNPCSoundIdNPCSounds()
        {
               return DbcDirectory.Open<NPCSounds>()?.Where(c => c.Id == this.NPCSoundId).FirstOrDefault();
        }

        public ParticleColor? GetParticleColorIdParticleColor()
        {
               return DbcDirectory.Open<ParticleColor>()?.Where(c => c.Id == this.ParticleColorId).FirstOrDefault();
        }

        public ObjectEffectPackage? GetObjectEffectPackageIdObjectEffectPackage()
        {
               return DbcDirectory.Open<ObjectEffectPackage>()?.Where(c => c.Id == this.ObjectEffectPackageId).FirstOrDefault();
        }

     }
}
