using TrinityCore._3._3._5.ClientLibrary.Dbc.Attributes;

namespace TrinityCore._3._3._5.ClientLibrary.Dbc.Definitions
{
    [DbcFile("LiquidType.dbc")]
    public class LiquidType : DbcFile
    {
        [DbcColumn(0, Enums.DbcColumnDataType.Int32)]
        public int Id { get; set; }

        [DbcColumn(1, Enums.DbcColumnDataType.StringRef)]
        public string? Name { get; set; }

        [DbcColumn(2, Enums.DbcColumnDataType.Int32)]
        public int Flags { get; set; }

        [DbcColumn(3, Enums.DbcColumnDataType.Int32)]
        public int SoundBank { get; set; }

        [DbcColumn(4, Enums.DbcColumnDataType.Int32)]
        public int SoundId { get; set; }

        [DbcColumn(5, Enums.DbcColumnDataType.Int32)]
        public int SpellId { get; set; }

        [DbcColumn(6, Enums.DbcColumnDataType.Float)]
        public float MaxDarkenDepth { get; set; }

        [DbcColumn(7, Enums.DbcColumnDataType.Float)]
        public float FogDarkenIntensity { get; set; }

        [DbcColumn(8, Enums.DbcColumnDataType.Float)]
        public float AmbDarkenIntensity { get; set; }

        [DbcColumn(9, Enums.DbcColumnDataType.Float)]
        public float DirDarkenIntensity { get; set; }

        [DbcColumn(10, Enums.DbcColumnDataType.Int32)]
        public int LightId { get; set; }

        [DbcColumn(11, Enums.DbcColumnDataType.Float)]
        public float ParticleScale { get; set; }

        [DbcColumn(12, Enums.DbcColumnDataType.Int32)]
        public int ParticleMovement { get; set; }

        [DbcColumn(13, Enums.DbcColumnDataType.Int32)]
        public int ParticleTexSlots { get; set; }

        [DbcColumn(14, Enums.DbcColumnDataType.Int32)]
        public int MaterialId { get; set; }

        [DbcColumn(15, Enums.DbcColumnDataType.ArrayOfStringRef, 6)]
        public string[]? Texture { get; set; }

        [DbcColumn(16, Enums.DbcColumnDataType.ArrayOfUint32, 2)]
        public int[]? Color { get; set; }

        [DbcColumn(17, Enums.DbcColumnDataType.ArrayOfFloat, 18)]
        public float[]? Float { get; set; }

        [DbcColumn(18, Enums.DbcColumnDataType.ArrayOfUint32, 4)]
        public int[]? Int { get; set; }

        public SoundEntries? GetSoundIdSoundEntries()
        {
               return DbcDirectory.Open<SoundEntries>()?.Where(c => c.Id == this.SoundId).FirstOrDefault();
        }

        public Spell? GetSpellIdSpell()
        {
               return DbcDirectory.Open<Spell>()?.Where(c => c.Id == this.SpellId).FirstOrDefault();
        }

        public Light? GetLightIdLight()
        {
               return DbcDirectory.Open<Light>()?.Where(c => c.Id == this.LightId).FirstOrDefault();
        }

        public LiquidMaterial? GetMaterialIdLiquidMaterial()
        {
               return DbcDirectory.Open<LiquidMaterial>()?.Where(c => c.Id == this.MaterialId).FirstOrDefault();
        }

     }
}
