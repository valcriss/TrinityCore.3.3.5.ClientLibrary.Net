using TrinityCore._3._3._5.ClientLibrary.Dbc.Attributes;
using TrinityCore._3._3._5.ClientLibrary.Dbc.Enums;

namespace TrinityCore._3._3._5.ClientLibrary.Dbc.Definitions;

[DbcFile("Spell.dbc")]
public class Spell : DbcFile
{
    [DbcColumn(0, DbcColumnDataType.Int32)]
    public int Id { get; set; }

    [DbcColumn(1, DbcColumnDataType.Int32)]
    public int Category { get; set; }

    [DbcColumn(2, DbcColumnDataType.Int32)]
    public int DispelType { get; set; }

    [DbcColumn(3, DbcColumnDataType.Int32)]
    public int Mechanic { get; set; }

    [DbcColumn(4, DbcColumnDataType.Int32)]
    public int Attributes { get; set; }

    [DbcColumn(5, DbcColumnDataType.Int32)]
    public int AttributesEx { get; set; }

    [DbcColumn(6, DbcColumnDataType.Int32)]
    public int AttributesExB { get; set; }

    [DbcColumn(7, DbcColumnDataType.Int32)]
    public int AttributesExC { get; set; }

    [DbcColumn(8, DbcColumnDataType.Int32)]
    public int AttributesExD { get; set; }

    [DbcColumn(9, DbcColumnDataType.Int32)]
    public int AttributesExE { get; set; }

    [DbcColumn(10, DbcColumnDataType.Int32)]
    public int AttributesExF { get; set; }

    [DbcColumn(11, DbcColumnDataType.Int32)]
    public int AttributesExG { get; set; }

    [DbcColumn(12, DbcColumnDataType.ArrayOfUint32, 2)]
    public int[]? ShapeshiftMask { get; set; }

    [DbcColumn(13, DbcColumnDataType.ArrayOfUint32, 2)]
    public int[]? ShapeshiftExclude { get; set; }

    [DbcColumn(14, DbcColumnDataType.Int32)]
    public int Targets { get; set; }

    [DbcColumn(15, DbcColumnDataType.Int32)]
    public int TargetCreatureType { get; set; }

    [DbcColumn(16, DbcColumnDataType.Int32)]
    public int RequiresSpellFocus { get; set; }

    [DbcColumn(17, DbcColumnDataType.Int32)]
    public int FacingCasterFlags { get; set; }

    [DbcColumn(18, DbcColumnDataType.Int32)]
    public int CasterAuraState { get; set; }

    [DbcColumn(19, DbcColumnDataType.Int32)]
    public int TargetAuraState { get; set; }

    [DbcColumn(20, DbcColumnDataType.Int32)]
    public int ExcludeCasterAuraState { get; set; }

    [DbcColumn(21, DbcColumnDataType.Int32)]
    public int ExcludeTargetAuraState { get; set; }

    [DbcColumn(22, DbcColumnDataType.Int32)]
    public int CasterAuraSpell { get; set; }

    [DbcColumn(23, DbcColumnDataType.Int32)]
    public int TargetAuraSpell { get; set; }

    [DbcColumn(24, DbcColumnDataType.Int32)]
    public int ExcludeCasterAuraSpell { get; set; }

    [DbcColumn(25, DbcColumnDataType.Int32)]
    public int ExcludeTargetAuraSpell { get; set; }

    [DbcColumn(26, DbcColumnDataType.Int32)]
    public int CastingTimeIndex { get; set; }

    [DbcColumn(27, DbcColumnDataType.Int32)]
    public int RecoveryTime { get; set; }

    [DbcColumn(28, DbcColumnDataType.Int32)]
    public int CategoryRecoveryTime { get; set; }

    [DbcColumn(29, DbcColumnDataType.Int32)]
    public int InterruptFlags { get; set; }

    [DbcColumn(30, DbcColumnDataType.Int32)]
    public int AuraInterruptFlags { get; set; }

    [DbcColumn(31, DbcColumnDataType.Int32)]
    public int ChannelInterruptFlags { get; set; }

    [DbcColumn(32, DbcColumnDataType.Int32)]
    public int ProcTypeMask { get; set; }

    [DbcColumn(33, DbcColumnDataType.Int32)]
    public int ProcChance { get; set; }

    [DbcColumn(34, DbcColumnDataType.Int32)]
    public int ProcCharges { get; set; }

    [DbcColumn(35, DbcColumnDataType.Int32)]
    public int MaxLevel { get; set; }

    [DbcColumn(36, DbcColumnDataType.Int32)]
    public int BaseLevel { get; set; }

    [DbcColumn(37, DbcColumnDataType.Int32)]
    public int SpellLevel { get; set; }

    [DbcColumn(38, DbcColumnDataType.Int32)]
    public int DurationIndex { get; set; }

    [DbcColumn(39, DbcColumnDataType.Int32)]
    public int PowerType { get; set; }

    [DbcColumn(40, DbcColumnDataType.Int32)]
    public int ManaCost { get; set; }

    [DbcColumn(41, DbcColumnDataType.Int32)]
    public int ManaCostPerLevel { get; set; }

    [DbcColumn(42, DbcColumnDataType.Int32)]
    public int ManaPerSecond { get; set; }

    [DbcColumn(43, DbcColumnDataType.Int32)]
    public int ManaPerSecondPerLevel { get; set; }

    [DbcColumn(44, DbcColumnDataType.Int32)]
    public int RangeIndex { get; set; }

    [DbcColumn(45, DbcColumnDataType.Float)]
    public float Speed { get; set; }

    [DbcColumn(46, DbcColumnDataType.Int32)]
    public int ModalNextSpell { get; set; }

    [DbcColumn(47, DbcColumnDataType.Int32)]
    public int CumulativeAura { get; set; }

    [DbcColumn(48, DbcColumnDataType.ArrayOfUint32, 2)]
    public int[]? Totem { get; set; }

    [DbcColumn(49, DbcColumnDataType.ArrayOfUint32, 8)]
    public int[]? Reagent { get; set; }

    [DbcColumn(50, DbcColumnDataType.ArrayOfUint32, 8)]
    public int[]? ReagentCount { get; set; }

    [DbcColumn(51, DbcColumnDataType.Int32)]
    public int EquippedItemClass { get; set; }

    [DbcColumn(52, DbcColumnDataType.Int32)]
    public int EquippedItemSubclass { get; set; }

    [DbcColumn(53, DbcColumnDataType.Int32)]
    public int EquippedItemInvTypes { get; set; }

    [DbcColumn(54, DbcColumnDataType.ArrayOfUint32, 3)]
    public int[]? Effect { get; set; }

    [DbcColumn(55, DbcColumnDataType.ArrayOfUint32, 3)]
    public int[]? EffectDieSides { get; set; }

    [DbcColumn(56, DbcColumnDataType.ArrayOfFloat, 3)]
    public float[]? EffectRealPointsPerLevel { get; set; }

    [DbcColumn(57, DbcColumnDataType.ArrayOfUint32, 3)]
    public int[]? EffectBasePoints { get; set; }

    [DbcColumn(58, DbcColumnDataType.ArrayOfUint32, 3)]
    public int[]? EffectMechanic { get; set; }

    [DbcColumn(59, DbcColumnDataType.ArrayOfUint32, 3)]
    public int[]? ImplicitTargetA { get; set; }

    [DbcColumn(60, DbcColumnDataType.ArrayOfUint32, 3)]
    public int[]? ImplicitTargetB { get; set; }

    [DbcColumn(61, DbcColumnDataType.ArrayOfUint32, 3)]
    public int[]? EffectRadiusIndex { get; set; }

    [DbcColumn(62, DbcColumnDataType.ArrayOfUint32, 3)]
    public int[]? EffectAura { get; set; }

    [DbcColumn(63, DbcColumnDataType.ArrayOfUint32, 3)]
    public int[]? EffectAuraPeriod { get; set; }

    [DbcColumn(64, DbcColumnDataType.ArrayOfFloat, 3)]
    public float[]? EffectAmplitude { get; set; }

    [DbcColumn(65, DbcColumnDataType.ArrayOfUint32, 3)]
    public int[]? EffectChainTargets { get; set; }

    [DbcColumn(66, DbcColumnDataType.ArrayOfUint32, 3)]
    public int[]? EffectItemType { get; set; }

    [DbcColumn(67, DbcColumnDataType.ArrayOfUint32, 3)]
    public int[]? EffectMiscValue { get; set; }

    [DbcColumn(68, DbcColumnDataType.ArrayOfUint32, 3)]
    public int[]? EffectMiscValueB { get; set; }

    [DbcColumn(69, DbcColumnDataType.ArrayOfUint32, 3)]
    public int[]? EffectTriggerSpell { get; set; }

    [DbcColumn(70, DbcColumnDataType.ArrayOfFloat, 3)]
    public float[]? EffectPointsPerCombo { get; set; }

    [DbcColumn(71, DbcColumnDataType.ArrayOfUint32, 3)]
    public int[]? EffectSpellClassMaskA { get; set; }

    [DbcColumn(72, DbcColumnDataType.ArrayOfUint32, 3)]
    public int[]? EffectSpellClassMaskB { get; set; }

    [DbcColumn(73, DbcColumnDataType.ArrayOfUint32, 3)]
    public int[]? EffectSpellClassMaskC { get; set; }

    [DbcColumn(74, DbcColumnDataType.ArrayOfUint32, 2)]
    public int[]? SpellVisualId { get; set; }

    [DbcColumn(75, DbcColumnDataType.Int32)]
    public int SpellIconId { get; set; }

    [DbcColumn(76, DbcColumnDataType.Int32)]
    public int ActiveIconId { get; set; }

    [DbcColumn(77, DbcColumnDataType.Int32)]
    public int SpellPriority { get; set; }

    [DbcColumn(78, DbcColumnDataType.Loc)]
    public string? NameLang { get; set; }

    [DbcColumn(79, DbcColumnDataType.Loc)]
    public string? NameSubtext { get; set; }

    [DbcColumn(80, DbcColumnDataType.Loc)]
    public string? Description { get; set; }

    [DbcColumn(81, DbcColumnDataType.Loc)]
    public string? AuraDescription { get; set; }

    [DbcColumn(82, DbcColumnDataType.Int32)]
    public int ManaCostPct { get; set; }

    [DbcColumn(83, DbcColumnDataType.Int32)]
    public int StartRecoveryCategory { get; set; }

    [DbcColumn(84, DbcColumnDataType.Int32)]
    public int StartRecoveryTime { get; set; }

    [DbcColumn(85, DbcColumnDataType.Int32)]
    public int MaxTargetLevel { get; set; }

    [DbcColumn(86, DbcColumnDataType.Int32)]
    public int SpellClassSet { get; set; }

    [DbcColumn(87, DbcColumnDataType.ArrayOfUint32, 3)]
    public int[]? SpellClassMask { get; set; }

    [DbcColumn(88, DbcColumnDataType.Int32)]
    public int MaxTargets { get; set; }

    [DbcColumn(89, DbcColumnDataType.Int32)]
    public int DefenseType { get; set; }

    [DbcColumn(90, DbcColumnDataType.Int32)]
    public int PreventionType { get; set; }

    [DbcColumn(91, DbcColumnDataType.Int32)]
    public int StanceBarOrder { get; set; }

    [DbcColumn(92, DbcColumnDataType.ArrayOfFloat, 3)]
    public float[]? EffectChainAmplitude { get; set; }

    [DbcColumn(93, DbcColumnDataType.Int32)]
    public int MinFactionId { get; set; }

    [DbcColumn(94, DbcColumnDataType.Int32)]
    public int MinReputation { get; set; }

    [DbcColumn(95, DbcColumnDataType.Int32)]
    public int RequiredAuraVision { get; set; }

    [DbcColumn(96, DbcColumnDataType.ArrayOfUint32, 2)]
    public int[]? RequiredTotemCategoryId { get; set; }

    [DbcColumn(97, DbcColumnDataType.Int32)]
    public int RequiredAreasId { get; set; }

    [DbcColumn(98, DbcColumnDataType.Int32)]
    public int SchoolMask { get; set; }

    [DbcColumn(99, DbcColumnDataType.Int32)]
    public int RuneCostId { get; set; }

    [DbcColumn(100, DbcColumnDataType.Int32)]
    public int SpellMissileId { get; set; }

    [DbcColumn(101, DbcColumnDataType.Int32)]
    public int PowerDisplayId { get; set; }

    [DbcColumn(102, DbcColumnDataType.ArrayOfFloat, 3)]
    public float[]? EffectBonusCoefficient { get; set; }

    [DbcColumn(103, DbcColumnDataType.Int32)]
    public int DescriptionVariablesId { get; set; }

    [DbcColumn(104, DbcColumnDataType.Int32)]
    public int Difficulty { get; set; }

    public SpellCategory? GetCategorySpellCategory()
    {
        return DbcDirectory.Open<SpellCategory>()?.Where(c => c.Id == Category).FirstOrDefault();
    }

    public SpellDispelType? GetDispelTypeSpellDispelType()
    {
        return DbcDirectory.Open<SpellDispelType>()?.Where(c => c.Id == DispelType).FirstOrDefault();
    }

    public SpellMechanic? GetMechanicSpellMechanic()
    {
        return DbcDirectory.Open<SpellMechanic>()?.Where(c => c.Id == Mechanic).FirstOrDefault();
    }

    public SpellFocusObject? GetRequiresSpellFocusSpellFocusObject()
    {
        return DbcDirectory.Open<SpellFocusObject>()?.Where(c => c.Id == RequiresSpellFocus).FirstOrDefault();
    }

    public SpellCastTimes? GetCastingTimeIndexSpellCastTimes()
    {
        return DbcDirectory.Open<SpellCastTimes>()?.Where(c => c.Id == CastingTimeIndex).FirstOrDefault();
    }

    public SpellDuration? GetDurationIndexSpellDuration()
    {
        return DbcDirectory.Open<SpellDuration>()?.Where(c => c.Id == DurationIndex).FirstOrDefault();
    }

    public Item[]? GetReagentItems()
    {
        return DbcDirectory.Open<Item>()?.Where(c => Reagent != null && Reagent.Contains(c.Id)).ToArray();
    }

    public SpellMechanic[]? GetEffectMechanicSpellMechanics()
    {
        return DbcDirectory.Open<SpellMechanic>()?.Where(c => EffectMechanic != null && EffectMechanic.Contains(c.Id)).ToArray();
    }

    public SpellRadius[]? GetEffectRadiusIndexSpellRadiuss()
    {
        return DbcDirectory.Open<SpellRadius>()?.Where(c => EffectRadiusIndex != null && EffectRadiusIndex.Contains(c.Id)).ToArray();
    }

    public Spell[]? GetEffectTriggerSpellSpells()
    {
        return DbcDirectory.Open<Spell>()?.Where(c => EffectTriggerSpell != null && EffectTriggerSpell.Contains(c.Id)).ToArray();
    }

    public SpellVisual[]? GetSpellVisualIdSpellVisuals()
    {
        return DbcDirectory.Open<SpellVisual>()?.Where(c => SpellVisualId != null && SpellVisualId.Contains(c.Id)).ToArray();
    }

    public SpellIcon? GetSpellIconIdSpellIcon()
    {
        return DbcDirectory.Open<SpellIcon>()?.Where(c => c.Id == SpellIconId).FirstOrDefault();
    }

    public SpellIcon? GetActiveIconIdSpellIcon()
    {
        return DbcDirectory.Open<SpellIcon>()?.Where(c => c.Id == ActiveIconId).FirstOrDefault();
    }

    public Faction? GetMinFactionIdFaction()
    {
        return DbcDirectory.Open<Faction>()?.Where(c => c.Id == MinFactionId).FirstOrDefault();
    }

    public TotemCategory[]? GetRequiredTotemCategoryIdTotemCategorys()
    {
        return DbcDirectory.Open<TotemCategory>()?.Where(c => RequiredTotemCategoryId != null && RequiredTotemCategoryId.Contains(c.Id)).ToArray();
    }

    public AreaGroup? GetRequiredAreasIdAreaGroup()
    {
        return DbcDirectory.Open<AreaGroup>()?.Where(c => c.Id == RequiredAreasId).FirstOrDefault();
    }

    public SpellRuneCost? GetRuneCostIdSpellRuneCost()
    {
        return DbcDirectory.Open<SpellRuneCost>()?.Where(c => c.Id == RuneCostId).FirstOrDefault();
    }

    public SpellMissile? GetSpellMissileIdSpellMissile()
    {
        return DbcDirectory.Open<SpellMissile>()?.Where(c => c.Id == SpellMissileId).FirstOrDefault();
    }

    public PowerDisplay? GetPowerDisplayIdPowerDisplay()
    {
        return DbcDirectory.Open<PowerDisplay>()?.Where(c => c.Id == PowerDisplayId).FirstOrDefault();
    }

    public SpellDescriptionVariables? GetDescriptionVariablesIdSpellDescriptionVariables()
    {
        return DbcDirectory.Open<SpellDescriptionVariables>()?.Where(c => c.Id == DescriptionVariablesId).FirstOrDefault();
    }
}