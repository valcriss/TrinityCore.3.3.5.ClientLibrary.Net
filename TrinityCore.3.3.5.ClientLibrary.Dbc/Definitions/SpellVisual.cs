using TrinityCore._3._3._5.ClientLibrary.Dbc.Attributes;

namespace TrinityCore._3._3._5.ClientLibrary.Dbc.Definitions
{
    [DbcFile("SpellVisual.dbc")]
    public class SpellVisual : DbcFile
    {
        [DbcColumn(0, Enums.DbcColumnDataType.Int32)]
        public int Id { get; set; }

        [DbcColumn(1, Enums.DbcColumnDataType.Int32)]
        public int PrecastKit { get; set; }

        [DbcColumn(2, Enums.DbcColumnDataType.Int32)]
        public int CastKit { get; set; }

        [DbcColumn(3, Enums.DbcColumnDataType.Int32)]
        public int ImpactKit { get; set; }

        [DbcColumn(4, Enums.DbcColumnDataType.Int32)]
        public int StateKit { get; set; }

        [DbcColumn(5, Enums.DbcColumnDataType.Int32)]
        public int StateDoneKit { get; set; }

        [DbcColumn(6, Enums.DbcColumnDataType.Int32)]
        public int ChannelKit { get; set; }

        [DbcColumn(7, Enums.DbcColumnDataType.Int32)]
        public int HasMissile { get; set; }

        [DbcColumn(8, Enums.DbcColumnDataType.Int32)]
        public int MissileModel { get; set; }

        [DbcColumn(9, Enums.DbcColumnDataType.Int32)]
        public int MissilePathType { get; set; }

        [DbcColumn(10, Enums.DbcColumnDataType.Int32)]
        public int MissileDestinationAttachment { get; set; }

        [DbcColumn(11, Enums.DbcColumnDataType.Int32)]
        public int MissileSound { get; set; }

        [DbcColumn(12, Enums.DbcColumnDataType.Int32)]
        public int AnimEventSoundId { get; set; }

        [DbcColumn(13, Enums.DbcColumnDataType.Int32)]
        public int Flags { get; set; }

        [DbcColumn(14, Enums.DbcColumnDataType.Int32)]
        public int CasterImpactKit { get; set; }

        [DbcColumn(15, Enums.DbcColumnDataType.Int32)]
        public int TargetImpactKit { get; set; }

        [DbcColumn(16, Enums.DbcColumnDataType.Int32)]
        public int MissileAttachment { get; set; }

        [DbcColumn(17, Enums.DbcColumnDataType.Int32)]
        public int MissileFollowGroundHeight { get; set; }

        [DbcColumn(18, Enums.DbcColumnDataType.Int32)]
        public int MissileFollowGroundDropSpeed { get; set; }

        [DbcColumn(19, Enums.DbcColumnDataType.Int32)]
        public int MissileFollowGroundApproach { get; set; }

        [DbcColumn(20, Enums.DbcColumnDataType.Int32)]
        public int MissileFollowGroundFlags { get; set; }

        [DbcColumn(21, Enums.DbcColumnDataType.Int32)]
        public int MissileMotion { get; set; }

        [DbcColumn(22, Enums.DbcColumnDataType.Int32)]
        public int MissileTargetingKit { get; set; }

        [DbcColumn(23, Enums.DbcColumnDataType.Int32)]
        public int InstantAreaKit { get; set; }

        [DbcColumn(24, Enums.DbcColumnDataType.Int32)]
        public int ImpactAreaKit { get; set; }

        [DbcColumn(25, Enums.DbcColumnDataType.Int32)]
        public int PersistentAreaKit { get; set; }

        [DbcColumn(26, Enums.DbcColumnDataType.ArrayOfFloat, 3)]
        public float[]? MissileCastOffset { get; set; }

        [DbcColumn(27, Enums.DbcColumnDataType.ArrayOfFloat, 3)]
        public float[]? MissileImpactOffset { get; set; }

        public SoundEntries? GetAnimEventSoundIdSoundEntries()
        {
               return DbcDirectory.Open<SoundEntries>()?.Where(c => c.Id == this.AnimEventSoundId).FirstOrDefault();
        }

        public SpellVisualKit? GetMissileTargetingKitSpellVisualKit()
        {
               return DbcDirectory.Open<SpellVisualKit>()?.Where(c => c.Id == this.MissileTargetingKit).FirstOrDefault();
        }

     }
}
