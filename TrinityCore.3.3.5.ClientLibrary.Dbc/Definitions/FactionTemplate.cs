using TrinityCore._3._3._5.ClientLibrary.Dbc.Attributes;
using TrinityCore._3._3._5.ClientLibrary.Dbc.Enums;

namespace TrinityCore._3._3._5.ClientLibrary.Dbc.Definitions;

[DbcFile("FactionTemplate.dbc")]
public class FactionTemplate : DbcFile
{
    [DbcColumn(0, DbcColumnDataType.Int32)]
    public int Id { get; set; }

    [DbcColumn(1, DbcColumnDataType.Int32)]
    public int Faction { get; set; }

    [DbcColumn(2, DbcColumnDataType.Int32)]
    public int Flags { get; set; }

    [DbcColumn(3, DbcColumnDataType.Int32)]
    public int FactionGroup { get; set; }

    [DbcColumn(4, DbcColumnDataType.Int32)]
    public int FriendGroup { get; set; }

    [DbcColumn(5, DbcColumnDataType.Int32)]
    public int EnemyGroup { get; set; }

    [DbcColumn(6, DbcColumnDataType.ArrayOfUint32, 4)]
    public int[]? Enemies { get; set; }

    [DbcColumn(7, DbcColumnDataType.ArrayOfUint32, 4)]
    public int[]? Friend { get; set; }

    public Faction? GetFactionFaction()
    {
        return DbcDirectory.Open<Faction>()?.Where(c => c.Id == Faction).FirstOrDefault();
    }

    public FactionGroup? GetFactionGroupFactionGroup()
    {
        return DbcDirectory.Open<FactionGroup>()?.Where(c => c.Id == FactionGroup).FirstOrDefault();
    }

    public Faction[]? GetEnemiesFactions()
    {
        return DbcDirectory.Open<Faction>()?.Where(c => Enemies != null && Enemies.Contains(c.Id)).ToArray();
    }

    public Faction[]? GetFriendFactions()
    {
        return DbcDirectory.Open<Faction>()?.Where(c => Friend != null && Friend.Contains(c.Id)).ToArray();
    }
}