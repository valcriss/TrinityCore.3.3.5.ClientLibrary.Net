using TrinityCore._3._3._5.ClientLibrary.Dbc.Attributes;
using TrinityCore._3._3._5.ClientLibrary.Dbc.Enums;

namespace TrinityCore._3._3._5.ClientLibrary.Dbc.Definitions;

[DbcFile("SpellVisualKit.dbc")]
public class SpellVisualKit : DbcFile
{
    [DbcColumn(0, DbcColumnDataType.Int32)]
    public int Id { get; set; }

    [DbcColumn(1, DbcColumnDataType.Int32)]
    public int StartAnimId { get; set; }

    [DbcColumn(2, DbcColumnDataType.Int32)]
    public int AnimId { get; set; }

    [DbcColumn(3, DbcColumnDataType.Int32)]
    public int HeadEffect { get; set; }

    [DbcColumn(4, DbcColumnDataType.Int32)]
    public int ChestEffect { get; set; }

    [DbcColumn(5, DbcColumnDataType.Int32)]
    public int BaseEffect { get; set; }

    [DbcColumn(6, DbcColumnDataType.Int32)]
    public int LeftHandEffect { get; set; }

    [DbcColumn(7, DbcColumnDataType.Int32)]
    public int RightHandEffect { get; set; }

    [DbcColumn(8, DbcColumnDataType.Int32)]
    public int BreathEffect { get; set; }

    [DbcColumn(9, DbcColumnDataType.Int32)]
    public int LeftWeaponEffect { get; set; }

    [DbcColumn(10, DbcColumnDataType.Int32)]
    public int RightWeaponEffect { get; set; }

    [DbcColumn(11, DbcColumnDataType.ArrayOfUint32, 3)]
    public int[]? SpecialEffect { get; set; }

    [DbcColumn(12, DbcColumnDataType.Int32)]
    public int WorldEffect { get; set; }

    [DbcColumn(13, DbcColumnDataType.Int32)]
    public int SoundId { get; set; }

    [DbcColumn(14, DbcColumnDataType.Int32)]
    public int ShakeId { get; set; }

    [DbcColumn(15, DbcColumnDataType.ArrayOfUint32, 4)]
    public int[]? CharProc { get; set; }

    [DbcColumn(16, DbcColumnDataType.ArrayOfFloat, 4)]
    public float[]? CharParamZero { get; set; }

    [DbcColumn(17, DbcColumnDataType.ArrayOfFloat, 4)]
    public float[]? CharParamOne { get; set; }

    [DbcColumn(18, DbcColumnDataType.ArrayOfFloat, 4)]
    public float[]? CharParamTwo { get; set; }

    [DbcColumn(19, DbcColumnDataType.ArrayOfFloat, 4)]
    public float[]? CharParamThree { get; set; }

    [DbcColumn(20, DbcColumnDataType.Int32)]
    public int Flags { get; set; }

    public AnimationData? GetStartAnimIdAnimationData()
    {
        return DbcDirectory.Open<AnimationData>()?.Where(c => c.Id == StartAnimId).FirstOrDefault();
    }

    public AnimationData? GetAnimIdAnimationData()
    {
        return DbcDirectory.Open<AnimationData>()?.Where(c => c.Id == AnimId).FirstOrDefault();
    }

    public SoundEntries? GetSoundIdSoundEntries()
    {
        return DbcDirectory.Open<SoundEntries>()?.Where(c => c.Id == SoundId).FirstOrDefault();
    }

    public SpellEffectCameraShakes? GetShakeIdSpellEffectCameraShakes()
    {
        return DbcDirectory.Open<SpellEffectCameraShakes>()?.Where(c => c.Id == ShakeId).FirstOrDefault();
    }
}