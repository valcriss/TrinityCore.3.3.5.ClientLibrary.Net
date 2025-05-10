using TrinityCore._3._3._5.ClientLibrary.Dbc.Attributes;
using TrinityCore._3._3._5.ClientLibrary.Dbc.Enums;

namespace TrinityCore._3._3._5.ClientLibrary.Dbc.Definitions;

[DbcFile("CreatureSoundData.dbc")]
public class CreatureSoundData : DbcFile
{
    [DbcColumn(0, DbcColumnDataType.Int32)]
    public int Id { get; set; }

    [DbcColumn(1, DbcColumnDataType.Int32)]
    public int SoundExertionId { get; set; }

    [DbcColumn(2, DbcColumnDataType.Int32)]
    public int SoundExertionCriticalId { get; set; }

    [DbcColumn(3, DbcColumnDataType.Int32)]
    public int SoundInjuryId { get; set; }

    [DbcColumn(4, DbcColumnDataType.Int32)]
    public int SoundInjuryCriticalId { get; set; }

    [DbcColumn(5, DbcColumnDataType.Int32)]
    public int SoundInjuryCrushingBlowId { get; set; }

    [DbcColumn(6, DbcColumnDataType.Int32)]
    public int SoundDeathId { get; set; }

    [DbcColumn(7, DbcColumnDataType.Int32)]
    public int SoundStunId { get; set; }

    [DbcColumn(8, DbcColumnDataType.Int32)]
    public int SoundStandId { get; set; }

    [DbcColumn(9, DbcColumnDataType.Int32)]
    public int SoundFootstepId { get; set; }

    [DbcColumn(10, DbcColumnDataType.Int32)]
    public int SoundAggroId { get; set; }

    [DbcColumn(11, DbcColumnDataType.Int32)]
    public int SoundWingFlapId { get; set; }

    [DbcColumn(12, DbcColumnDataType.Int32)]
    public int SoundWingGlideId { get; set; }

    [DbcColumn(13, DbcColumnDataType.Int32)]
    public int SoundAlertId { get; set; }

    [DbcColumn(14, DbcColumnDataType.ArrayOfUint32, 5)]
    public int[]? SoundFidget { get; set; }

    [DbcColumn(15, DbcColumnDataType.ArrayOfUint32, 4)]
    public int[]? CustomAttack { get; set; }

    [DbcColumn(16, DbcColumnDataType.Int32)]
    public int NPCSoundId { get; set; }

    [DbcColumn(17, DbcColumnDataType.Int32)]
    public int LoopSoundId { get; set; }

    [DbcColumn(18, DbcColumnDataType.Int32)]
    public int CreatureImpactType { get; set; }

    [DbcColumn(19, DbcColumnDataType.Int32)]
    public int SoundJumpStartId { get; set; }

    [DbcColumn(20, DbcColumnDataType.Int32)]
    public int SoundJumpEndId { get; set; }

    [DbcColumn(21, DbcColumnDataType.Int32)]
    public int SoundPetAttackId { get; set; }

    [DbcColumn(22, DbcColumnDataType.Int32)]
    public int SoundPetOrderId { get; set; }

    [DbcColumn(23, DbcColumnDataType.Int32)]
    public int SoundPetDismissId { get; set; }

    [DbcColumn(24, DbcColumnDataType.Float)]
    public float FidgetDelaySecondsMin { get; set; }

    [DbcColumn(25, DbcColumnDataType.Float)]
    public float FidgetDelaySecondsMax { get; set; }

    [DbcColumn(26, DbcColumnDataType.Int32)]
    public int BirthSoundId { get; set; }

    [DbcColumn(27, DbcColumnDataType.Int32)]
    public int SpellCastDirectedSoundId { get; set; }

    [DbcColumn(28, DbcColumnDataType.Int32)]
    public int SubmergeSoundId { get; set; }

    [DbcColumn(29, DbcColumnDataType.Int32)]
    public int SubmergedSoundId { get; set; }

    [DbcColumn(30, DbcColumnDataType.Int32)]
    public int CreatureSoundDataIdPet { get; set; }

    public SoundEntries? GetSoundExertionIdSoundEntries()
    {
        return DbcDirectory.Open<SoundEntries>()?.Where(c => c.Id == SoundExertionId).FirstOrDefault();
    }

    public SoundEntries? GetSoundExertionCriticalIdSoundEntries()
    {
        return DbcDirectory.Open<SoundEntries>()?.Where(c => c.Id == SoundExertionCriticalId).FirstOrDefault();
    }

    public SoundEntries? GetSoundInjuryIdSoundEntries()
    {
        return DbcDirectory.Open<SoundEntries>()?.Where(c => c.Id == SoundInjuryId).FirstOrDefault();
    }

    public SoundEntries? GetSoundInjuryCriticalIdSoundEntries()
    {
        return DbcDirectory.Open<SoundEntries>()?.Where(c => c.Id == SoundInjuryCriticalId).FirstOrDefault();
    }

    public SoundEntries? GetSoundDeathIdSoundEntries()
    {
        return DbcDirectory.Open<SoundEntries>()?.Where(c => c.Id == SoundDeathId).FirstOrDefault();
    }

    public SoundEntries? GetSoundStunIdSoundEntries()
    {
        return DbcDirectory.Open<SoundEntries>()?.Where(c => c.Id == SoundStunId).FirstOrDefault();
    }

    public SoundEntries? GetSoundStandIdSoundEntries()
    {
        return DbcDirectory.Open<SoundEntries>()?.Where(c => c.Id == SoundStandId).FirstOrDefault();
    }

    public FootstepTerrainLookup? GetSoundFootstepIdFootstepTerrainLookup()
    {
        return DbcDirectory.Open<FootstepTerrainLookup>()?.Where(c => c.CreatureFootstepId == SoundFootstepId).FirstOrDefault();
    }

    public SoundEntries? GetSoundAggroIdSoundEntries()
    {
        return DbcDirectory.Open<SoundEntries>()?.Where(c => c.Id == SoundAggroId).FirstOrDefault();
    }

    public SoundEntries? GetSoundWingFlapIdSoundEntries()
    {
        return DbcDirectory.Open<SoundEntries>()?.Where(c => c.Id == SoundWingFlapId).FirstOrDefault();
    }

    public SoundEntries? GetSoundWingGlideIdSoundEntries()
    {
        return DbcDirectory.Open<SoundEntries>()?.Where(c => c.Id == SoundWingGlideId).FirstOrDefault();
    }

    public SoundEntries? GetSoundAlertIdSoundEntries()
    {
        return DbcDirectory.Open<SoundEntries>()?.Where(c => c.Id == SoundAlertId).FirstOrDefault();
    }

    public SoundEntries[]? GetSoundFidgetSoundEntriess()
    {
        return DbcDirectory.Open<SoundEntries>()?.Where(c => SoundFidget != null && SoundFidget.Contains(c.Id)).ToArray();
    }

    public SoundEntries[]? GetCustomAttackSoundEntriess()
    {
        return DbcDirectory.Open<SoundEntries>()?.Where(c => CustomAttack != null && CustomAttack.Contains(c.Id)).ToArray();
    }

    public SoundEntries? GetLoopSoundIdSoundEntries()
    {
        return DbcDirectory.Open<SoundEntries>()?.Where(c => c.Id == LoopSoundId).FirstOrDefault();
    }

    public SoundEntries? GetSoundJumpStartIdSoundEntries()
    {
        return DbcDirectory.Open<SoundEntries>()?.Where(c => c.Id == SoundJumpStartId).FirstOrDefault();
    }

    public SoundEntries? GetSoundJumpEndIdSoundEntries()
    {
        return DbcDirectory.Open<SoundEntries>()?.Where(c => c.Id == SoundJumpEndId).FirstOrDefault();
    }

    public SoundEntries? GetSoundPetAttackIdSoundEntries()
    {
        return DbcDirectory.Open<SoundEntries>()?.Where(c => c.Id == SoundPetAttackId).FirstOrDefault();
    }

    public SoundEntries? GetSoundPetOrderIdSoundEntries()
    {
        return DbcDirectory.Open<SoundEntries>()?.Where(c => c.Id == SoundPetOrderId).FirstOrDefault();
    }

    public SoundEntries? GetSoundPetDismissIdSoundEntries()
    {
        return DbcDirectory.Open<SoundEntries>()?.Where(c => c.Id == SoundPetDismissId).FirstOrDefault();
    }

    public SoundEntries? GetBirthSoundIdSoundEntries()
    {
        return DbcDirectory.Open<SoundEntries>()?.Where(c => c.Id == BirthSoundId).FirstOrDefault();
    }

    public SoundEntries? GetSpellCastDirectedSoundIdSoundEntries()
    {
        return DbcDirectory.Open<SoundEntries>()?.Where(c => c.Id == SpellCastDirectedSoundId).FirstOrDefault();
    }

    public SoundEntries? GetSubmergeSoundIdSoundEntries()
    {
        return DbcDirectory.Open<SoundEntries>()?.Where(c => c.Id == SubmergeSoundId).FirstOrDefault();
    }

    public SoundEntries? GetSubmergedSoundIdSoundEntries()
    {
        return DbcDirectory.Open<SoundEntries>()?.Where(c => c.Id == SubmergedSoundId).FirstOrDefault();
    }

    public CreatureSoundData? GetCreatureSoundDataIdPetCreatureSoundData()
    {
        return DbcDirectory.Open<CreatureSoundData>()?.Where(c => c.Id == CreatureSoundDataIdPet).FirstOrDefault();
    }
}