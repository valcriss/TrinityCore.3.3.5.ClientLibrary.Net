using TrinityCore._3._3._5.ClientLibrary.Dbc.Attributes;
using TrinityCore._3._3._5.ClientLibrary.Dbc.Enums;

namespace TrinityCore._3._3._5.ClientLibrary.Dbc.Definitions;

[DbcFile("AnimationData.dbc")]
public class AnimationData : DbcFile
{
    [DbcColumn(0, DbcColumnDataType.Int32)]
    public int Id { get; set; }

    [DbcColumn(1, DbcColumnDataType.StringRef)]
    public string? Name { get; set; }

    [DbcColumn(2, DbcColumnDataType.Int32)]
    public int Weaponflags { get; set; }

    [DbcColumn(3, DbcColumnDataType.Int32)]
    public int Bodyflags { get; set; }

    [DbcColumn(4, DbcColumnDataType.Int32)]
    public int Flags { get; set; }

    [DbcColumn(5, DbcColumnDataType.Int32)]
    public int Fallback { get; set; }

    [DbcColumn(6, DbcColumnDataType.Int32)]
    public int BehaviorId { get; set; }

    [DbcColumn(7, DbcColumnDataType.Int32)]
    public int BehaviorTier { get; set; }

    public AnimationData? GetFallbackAnimationData()
    {
        return DbcDirectory.Open<AnimationData>()?.Where(c => c.Id == Fallback).FirstOrDefault();
    }

    public AnimationData? GetBehaviorIdAnimationData()
    {
        return DbcDirectory.Open<AnimationData>()?.Where(c => c.Id == BehaviorId).FirstOrDefault();
    }
}