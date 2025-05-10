using TrinityCore._3._3._5.ClientLibrary.Dbc.Attributes;
using TrinityCore._3._3._5.ClientLibrary.Dbc.Enums;

namespace TrinityCore._3._3._5.ClientLibrary.Dbc.Definitions;

[DbcFile("SpellVisual.dbc")]
public class SpellVisual : DbcFile
{
    [DbcColumn(0, DbcColumnDataType.Int32)]
    public int Id { get; set; }

    [DbcColumn(1, DbcColumnDataType.Int32)]
    public int PrecastKit { get; set; }

    [DbcColumn(2, DbcColumnDataType.Int32)]
    public int CastKit { get; set; }

    [DbcColumn(3, DbcColumnDataType.Int32)]
    public int ImpactKit { get; set; }

    [DbcColumn(4, DbcColumnDataType.Int32)]
    public int StateKit { get; set; }

    [DbcColumn(5, DbcColumnDataType.Int32)]
    public int StateDoneKit { get; set; }

    [DbcColumn(6, DbcColumnDataType.Int32)]
    public int ChannelKit { get; set; }

    [DbcColumn(7, DbcColumnDataType.Int32)]
    public int HasMissile { get; set; }

    [DbcColumn(8, DbcColumnDataType.Int32)]
    public int MissileModel { get; set; }

    [DbcColumn(9, DbcColumnDataType.Int32)]
    public int MissilePathType { get; set; }

    [DbcColumn(10, DbcColumnDataType.Int32)]
    public int MissileDestinationAttachment { get; set; }

    [DbcColumn(11, DbcColumnDataType.Int32)]
    public int MissileSound { get; set; }

    [DbcColumn(12, DbcColumnDataType.Int32)]
    public int AnimEventSoundId { get; set; }

    [DbcColumn(13, DbcColumnDataType.Int32)]
    public int Flags { get; set; }

    [DbcColumn(14, DbcColumnDataType.Int32)]
    public int CasterImpactKit { get; set; }

    [DbcColumn(15, DbcColumnDataType.Int32)]
    public int TargetImpactKit { get; set; }

    [DbcColumn(16, DbcColumnDataType.Int32)]
    public int MissileAttachment { get; set; }

    [DbcColumn(17, DbcColumnDataType.Int32)]
    public int MissileFollowGroundHeight { get; set; }

    [DbcColumn(18, DbcColumnDataType.Int32)]
    public int MissileFollowGroundDropSpeed { get; set; }

    [DbcColumn(19, DbcColumnDataType.Int32)]
    public int MissileFollowGroundApproach { get; set; }

    [DbcColumn(20, DbcColumnDataType.Int32)]
    public int MissileFollowGroundFlags { get; set; }

    [DbcColumn(21, DbcColumnDataType.Int32)]
    public int MissileMotion { get; set; }

    [DbcColumn(22, DbcColumnDataType.Int32)]
    public int MissileTargetingKit { get; set; }

    [DbcColumn(23, DbcColumnDataType.Int32)]
    public int InstantAreaKit { get; set; }

    [DbcColumn(24, DbcColumnDataType.Int32)]
    public int ImpactAreaKit { get; set; }

    [DbcColumn(25, DbcColumnDataType.Int32)]
    public int PersistentAreaKit { get; set; }

    [DbcColumn(26, DbcColumnDataType.ArrayOfFloat, 3)]
    public float[]? MissileCastOffset { get; set; }

    [DbcColumn(27, DbcColumnDataType.ArrayOfFloat, 3)]
    public float[]? MissileImpactOffset { get; set; }

    public SoundEntries? GetAnimEventSoundIdSoundEntries()
    {
        return DbcDirectory.Open<SoundEntries>()?.Where(c => c.Id == AnimEventSoundId).FirstOrDefault();
    }

    public SpellVisualKit? GetMissileTargetingKitSpellVisualKit()
    {
        return DbcDirectory.Open<SpellVisualKit>()?.Where(c => c.Id == MissileTargetingKit).FirstOrDefault();
    }
}