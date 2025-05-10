using TrinityCore._3._3._5.ClientLibrary.Dbc.Attributes;
using TrinityCore._3._3._5.ClientLibrary.Dbc.Enums;

namespace TrinityCore._3._3._5.ClientLibrary.Dbc.Definitions;

[DbcFile("SpellShapeshiftForm.dbc")]
public class SpellShapeshiftForm : DbcFile
{
    [DbcColumn(0, DbcColumnDataType.Int32)]
    public int Id { get; set; }

    [DbcColumn(1, DbcColumnDataType.Int32)]
    public int BonusActionBar { get; set; }

    [DbcColumn(2, DbcColumnDataType.Loc)]
    public string? NameLang { get; set; }

    [DbcColumn(3, DbcColumnDataType.Int32)]
    public int Flags { get; set; }

    [DbcColumn(4, DbcColumnDataType.Int32)]
    public int CreatureType { get; set; }

    [DbcColumn(5, DbcColumnDataType.Int32)]
    public int AttackIconId { get; set; }

    [DbcColumn(6, DbcColumnDataType.Int32)]
    public int CombatRoundTime { get; set; }

    [DbcColumn(7, DbcColumnDataType.ArrayOfUint32, 4)]
    public int[]? CreatureDisplayId { get; set; }

    [DbcColumn(8, DbcColumnDataType.ArrayOfUint32, 8)]
    public int[]? PresetSpellId { get; set; }

    public CreatureType? GetCreatureTypeCreatureType()
    {
        return DbcDirectory.Open<CreatureType>()?.Where(c => c.Id == CreatureType).FirstOrDefault();
    }

    public SpellIcon? GetAttackIconIdSpellIcon()
    {
        return DbcDirectory.Open<SpellIcon>()?.Where(c => c.Id == AttackIconId).FirstOrDefault();
    }

    public CreatureDisplayInfo[]? GetCreatureDisplayIdCreatureDisplayInfos()
    {
        return DbcDirectory.Open<CreatureDisplayInfo>()?.Where(c => CreatureDisplayId != null && CreatureDisplayId.Contains(c.Id)).ToArray();
    }

    public Spell[]? GetPresetSpellIdSpells()
    {
        return DbcDirectory.Open<Spell>()?.Where(c => PresetSpellId != null && PresetSpellId.Contains(c.Id)).ToArray();
    }
}