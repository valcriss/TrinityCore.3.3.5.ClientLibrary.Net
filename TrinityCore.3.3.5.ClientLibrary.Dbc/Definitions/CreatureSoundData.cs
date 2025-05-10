using TrinityCore._3._3._5.ClientLibrary.Dbc.Attributes;

namespace TrinityCore._3._3._5.ClientLibrary.Dbc.Definitions
{
    [DbcFile("CreatureSoundData.dbc")]
    public class CreatureSoundData : DbcFile
    {
        [DbcColumn(0, Enums.DbcColumnDataType.Int32)]
        public int Id { get; set; }

        [DbcColumn(1, Enums.DbcColumnDataType.Int32)]
        public int SoundExertionId { get; set; }

        [DbcColumn(2, Enums.DbcColumnDataType.Int32)]
        public int SoundExertionCriticalId { get; set; }

        [DbcColumn(3, Enums.DbcColumnDataType.Int32)]
        public int SoundInjuryId { get; set; }

        [DbcColumn(4, Enums.DbcColumnDataType.Int32)]
        public int SoundInjuryCriticalId { get; set; }

        [DbcColumn(5, Enums.DbcColumnDataType.Int32)]
        public int SoundInjuryCrushingBlowId { get; set; }

        [DbcColumn(6, Enums.DbcColumnDataType.Int32)]
        public int SoundDeathId { get; set; }

        [DbcColumn(7, Enums.DbcColumnDataType.Int32)]
        public int SoundStunId { get; set; }

        [DbcColumn(8, Enums.DbcColumnDataType.Int32)]
        public int SoundStandId { get; set; }

        [DbcColumn(9, Enums.DbcColumnDataType.Int32)]
        public int SoundFootstepId { get; set; }

        [DbcColumn(10, Enums.DbcColumnDataType.Int32)]
        public int SoundAggroId { get; set; }

        [DbcColumn(11, Enums.DbcColumnDataType.Int32)]
        public int SoundWingFlapId { get; set; }

        [DbcColumn(12, Enums.DbcColumnDataType.Int32)]
        public int SoundWingGlideId { get; set; }

        [DbcColumn(13, Enums.DbcColumnDataType.Int32)]
        public int SoundAlertId { get; set; }

        [DbcColumn(14, Enums.DbcColumnDataType.ArrayOfUint32, 5)]
        public int[]? SoundFidget { get; set; }

        [DbcColumn(15, Enums.DbcColumnDataType.ArrayOfUint32, 4)]
        public int[]? CustomAttack { get; set; }

        [DbcColumn(16, Enums.DbcColumnDataType.Int32)]
        public int NPCSoundId { get; set; }

        [DbcColumn(17, Enums.DbcColumnDataType.Int32)]
        public int LoopSoundId { get; set; }

        [DbcColumn(18, Enums.DbcColumnDataType.Int32)]
        public int CreatureImpactType { get; set; }

        [DbcColumn(19, Enums.DbcColumnDataType.Int32)]
        public int SoundJumpStartId { get; set; }

        [DbcColumn(20, Enums.DbcColumnDataType.Int32)]
        public int SoundJumpEndId { get; set; }

        [DbcColumn(21, Enums.DbcColumnDataType.Int32)]
        public int SoundPetAttackId { get; set; }

        [DbcColumn(22, Enums.DbcColumnDataType.Int32)]
        public int SoundPetOrderId { get; set; }

        [DbcColumn(23, Enums.DbcColumnDataType.Int32)]
        public int SoundPetDismissId { get; set; }

        [DbcColumn(24, Enums.DbcColumnDataType.Float)]
        public float FidgetDelaySecondsMin { get; set; }

        [DbcColumn(25, Enums.DbcColumnDataType.Float)]
        public float FidgetDelaySecondsMax { get; set; }

        [DbcColumn(26, Enums.DbcColumnDataType.Int32)]
        public int BirthSoundId { get; set; }

        [DbcColumn(27, Enums.DbcColumnDataType.Int32)]
        public int SpellCastDirectedSoundId { get; set; }

        [DbcColumn(28, Enums.DbcColumnDataType.Int32)]
        public int SubmergeSoundId { get; set; }

        [DbcColumn(29, Enums.DbcColumnDataType.Int32)]
        public int SubmergedSoundId { get; set; }

        [DbcColumn(30, Enums.DbcColumnDataType.Int32)]
        public int CreatureSoundDataIdPet { get; set; }

        public SoundEntries? GetSoundExertionIdSoundEntries()
        {
               return DbcDirectory.Open<SoundEntries>()?.Where(c => c.Id == this.SoundExertionId).FirstOrDefault();
        }

        public SoundEntries? GetSoundExertionCriticalIdSoundEntries()
        {
               return DbcDirectory.Open<SoundEntries>()?.Where(c => c.Id == this.SoundExertionCriticalId).FirstOrDefault();
        }

        public SoundEntries? GetSoundInjuryIdSoundEntries()
        {
               return DbcDirectory.Open<SoundEntries>()?.Where(c => c.Id == this.SoundInjuryId).FirstOrDefault();
        }

        public SoundEntries? GetSoundInjuryCriticalIdSoundEntries()
        {
               return DbcDirectory.Open<SoundEntries>()?.Where(c => c.Id == this.SoundInjuryCriticalId).FirstOrDefault();
        }

        public SoundEntries? GetSoundDeathIdSoundEntries()
        {
               return DbcDirectory.Open<SoundEntries>()?.Where(c => c.Id == this.SoundDeathId).FirstOrDefault();
        }

        public SoundEntries? GetSoundStunIdSoundEntries()
        {
               return DbcDirectory.Open<SoundEntries>()?.Where(c => c.Id == this.SoundStunId).FirstOrDefault();
        }

        public SoundEntries? GetSoundStandIdSoundEntries()
        {
               return DbcDirectory.Open<SoundEntries>()?.Where(c => c.Id == this.SoundStandId).FirstOrDefault();
        }

        public FootstepTerrainLookup? GetSoundFootstepIdFootstepTerrainLookup()
        {
               return DbcDirectory.Open<FootstepTerrainLookup>()?.Where(c => c.CreatureFootstepId == this.SoundFootstepId).FirstOrDefault();
        }

        public SoundEntries? GetSoundAggroIdSoundEntries()
        {
               return DbcDirectory.Open<SoundEntries>()?.Where(c => c.Id == this.SoundAggroId).FirstOrDefault();
        }

        public SoundEntries? GetSoundWingFlapIdSoundEntries()
        {
               return DbcDirectory.Open<SoundEntries>()?.Where(c => c.Id == this.SoundWingFlapId).FirstOrDefault();
        }

        public SoundEntries? GetSoundWingGlideIdSoundEntries()
        {
               return DbcDirectory.Open<SoundEntries>()?.Where(c => c.Id == this.SoundWingGlideId).FirstOrDefault();
        }

        public SoundEntries? GetSoundAlertIdSoundEntries()
        {
               return DbcDirectory.Open<SoundEntries>()?.Where(c => c.Id == this.SoundAlertId).FirstOrDefault();
        }

        public SoundEntries[]? GetSoundFidgetSoundEntriess()
        {
               return DbcDirectory.Open<SoundEntries>()?.Where(c => this.SoundFidget != null && this.SoundFidget.Contains(c.Id)).ToArray();
        }

        public SoundEntries[]? GetCustomAttackSoundEntriess()
        {
               return DbcDirectory.Open<SoundEntries>()?.Where(c => this.CustomAttack != null && this.CustomAttack.Contains(c.Id)).ToArray();
        }

        public SoundEntries? GetLoopSoundIdSoundEntries()
        {
               return DbcDirectory.Open<SoundEntries>()?.Where(c => c.Id == this.LoopSoundId).FirstOrDefault();
        }

        public SoundEntries? GetSoundJumpStartIdSoundEntries()
        {
               return DbcDirectory.Open<SoundEntries>()?.Where(c => c.Id == this.SoundJumpStartId).FirstOrDefault();
        }

        public SoundEntries? GetSoundJumpEndIdSoundEntries()
        {
               return DbcDirectory.Open<SoundEntries>()?.Where(c => c.Id == this.SoundJumpEndId).FirstOrDefault();
        }

        public SoundEntries? GetSoundPetAttackIdSoundEntries()
        {
               return DbcDirectory.Open<SoundEntries>()?.Where(c => c.Id == this.SoundPetAttackId).FirstOrDefault();
        }

        public SoundEntries? GetSoundPetOrderIdSoundEntries()
        {
               return DbcDirectory.Open<SoundEntries>()?.Where(c => c.Id == this.SoundPetOrderId).FirstOrDefault();
        }

        public SoundEntries? GetSoundPetDismissIdSoundEntries()
        {
               return DbcDirectory.Open<SoundEntries>()?.Where(c => c.Id == this.SoundPetDismissId).FirstOrDefault();
        }

        public SoundEntries? GetBirthSoundIdSoundEntries()
        {
               return DbcDirectory.Open<SoundEntries>()?.Where(c => c.Id == this.BirthSoundId).FirstOrDefault();
        }

        public SoundEntries? GetSpellCastDirectedSoundIdSoundEntries()
        {
               return DbcDirectory.Open<SoundEntries>()?.Where(c => c.Id == this.SpellCastDirectedSoundId).FirstOrDefault();
        }

        public SoundEntries? GetSubmergeSoundIdSoundEntries()
        {
               return DbcDirectory.Open<SoundEntries>()?.Where(c => c.Id == this.SubmergeSoundId).FirstOrDefault();
        }

        public SoundEntries? GetSubmergedSoundIdSoundEntries()
        {
               return DbcDirectory.Open<SoundEntries>()?.Where(c => c.Id == this.SubmergedSoundId).FirstOrDefault();
        }

        public CreatureSoundData? GetCreatureSoundDataIdPetCreatureSoundData()
        {
               return DbcDirectory.Open<CreatureSoundData>()?.Where(c => c.Id == this.CreatureSoundDataIdPet).FirstOrDefault();
        }

     }
}
