using TrinityCore._3._3._5.ClientLibrary.Dbc.Attributes;

namespace TrinityCore._3._3._5.ClientLibrary.Dbc.Definitions
{
    [DbcFile("SpellVisualKit.dbc")]
    public class SpellVisualKit : DbcFile
    {
        [DbcColumn(0, Enums.DbcColumnDataType.Int32)]
        public int Id { get; set; }

        [DbcColumn(1, Enums.DbcColumnDataType.Int32)]
        public int StartAnimId { get; set; }

        [DbcColumn(2, Enums.DbcColumnDataType.Int32)]
        public int AnimId { get; set; }

        [DbcColumn(3, Enums.DbcColumnDataType.Int32)]
        public int HeadEffect { get; set; }

        [DbcColumn(4, Enums.DbcColumnDataType.Int32)]
        public int ChestEffect { get; set; }

        [DbcColumn(5, Enums.DbcColumnDataType.Int32)]
        public int BaseEffect { get; set; }

        [DbcColumn(6, Enums.DbcColumnDataType.Int32)]
        public int LeftHandEffect { get; set; }

        [DbcColumn(7, Enums.DbcColumnDataType.Int32)]
        public int RightHandEffect { get; set; }

        [DbcColumn(8, Enums.DbcColumnDataType.Int32)]
        public int BreathEffect { get; set; }

        [DbcColumn(9, Enums.DbcColumnDataType.Int32)]
        public int LeftWeaponEffect { get; set; }

        [DbcColumn(10, Enums.DbcColumnDataType.Int32)]
        public int RightWeaponEffect { get; set; }

        [DbcColumn(11, Enums.DbcColumnDataType.ArrayOfUint32, 3)]
        public int[]? SpecialEffect { get; set; }

        [DbcColumn(12, Enums.DbcColumnDataType.Int32)]
        public int WorldEffect { get; set; }

        [DbcColumn(13, Enums.DbcColumnDataType.Int32)]
        public int SoundId { get; set; }

        [DbcColumn(14, Enums.DbcColumnDataType.Int32)]
        public int ShakeId { get; set; }

        [DbcColumn(15, Enums.DbcColumnDataType.ArrayOfUint32, 4)]
        public int[]? CharProc { get; set; }

        [DbcColumn(16, Enums.DbcColumnDataType.ArrayOfFloat, 4)]
        public float[]? CharParamZero { get; set; }

        [DbcColumn(17, Enums.DbcColumnDataType.ArrayOfFloat, 4)]
        public float[]? CharParamOne { get; set; }

        [DbcColumn(18, Enums.DbcColumnDataType.ArrayOfFloat, 4)]
        public float[]? CharParamTwo { get; set; }

        [DbcColumn(19, Enums.DbcColumnDataType.ArrayOfFloat, 4)]
        public float[]? CharParamThree { get; set; }

        [DbcColumn(20, Enums.DbcColumnDataType.Int32)]
        public int Flags { get; set; }

        public AnimationData? GetStartAnimIdAnimationData()
        {
               return DbcDirectory.Open<AnimationData>()?.Where(c => c.Id == this.StartAnimId).FirstOrDefault();
        }

        public AnimationData? GetAnimIdAnimationData()
        {
               return DbcDirectory.Open<AnimationData>()?.Where(c => c.Id == this.AnimId).FirstOrDefault();
        }

        public SoundEntries? GetSoundIdSoundEntries()
        {
               return DbcDirectory.Open<SoundEntries>()?.Where(c => c.Id == this.SoundId).FirstOrDefault();
        }

        public SpellEffectCameraShakes? GetShakeIdSpellEffectCameraShakes()
        {
               return DbcDirectory.Open<SpellEffectCameraShakes>()?.Where(c => c.Id == this.ShakeId).FirstOrDefault();
        }

     }
}
