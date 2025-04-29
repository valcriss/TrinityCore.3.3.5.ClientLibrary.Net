using TrinityCore._3._3._5.ClientLibrary.Dbc;
using TrinityCore._3._3._5.ClientLibrary.WorldState.Core;
using TrinityCore._3._3._5.ClientLibrary.WorldState.Models.Account;
using TrinityCore._3._3._5.ClientLibrary.WorldState.Models.Player;

namespace TrinityCore._3._3._5.ClientLibrary.WorldState.States;

public class PlayerState : State
{
    public PlayerState(WorldStateEventBus worldStateEventBus, DbcCollection dbcCollection) : base(worldStateEventBus, dbcCollection)
    {
    }

    public Achievements Achievements { get; private set; } = new();
    public WorldPoint BindPoint { get; private set; } = new();
    public DungeonDifficulty DungeonDifficulty { get; private set; } = new();
    public InstanceDifficulty InstanceDifficulty { get; private set; } = new();
    public PlayerTalentsInformations PlayerTalents { get; private set; } = new();
    public PetTalentsInformations PetTalents { get; private set; } = new();
    public List<Spell> Spells { get; private set; } = new();
    public List<Spell> UnlearnedSpells { get; private set; } = new();
    public List<Reputation> Factions { get; private set; } = new();
    public ActionButtons Buttons { get; private set; } = new();
    public EquipmentSets EquipmentSets { get; private set; } = new();
    public FactionsOverrides FactionsOverrides { get; private set; } = new();
    public Proficiencies Proficiencies { get; } = new();
    public Models.Player.WorldState WorldState { get; private set; } = new();

    protected override void RegisterWorldStateBusEvents()
    {
        WorldStateEventBus.Register<Achievements>(achievements => Achievements = achievements);
        WorldStateEventBus.Register<WorldPoint>(bindPoint => BindPoint = bindPoint);
        WorldStateEventBus.Register<DungeonDifficulty>(difficultyInfo => DungeonDifficulty = difficultyInfo);
        WorldStateEventBus.Register<InstanceDifficulty>(instanceDifficulty => InstanceDifficulty = instanceDifficulty);
        WorldStateEventBus.Register<PlayerTalentsInformations>(talents => PlayerTalents = talents);
        WorldStateEventBus.Register<PetTalentsInformations>(talents => PetTalents = talents);
        WorldStateEventBus.Register<SpellsList>(spellsInformations => Spells = spellsInformations.Spells);
        WorldStateEventBus.Register<UnlearnedSpellsList>(unlearnedSpellsList => UnlearnedSpells = unlearnedSpellsList.Spells);
        WorldStateEventBus.Register<Factions>(factions => Factions = factions.Reputations);
        WorldStateEventBus.Register<ActionButtons>(buttons => Buttons = buttons);
        WorldStateEventBus.Register<EquipmentSets>(equipmentSets => EquipmentSets = equipmentSets);
        WorldStateEventBus.Register<FactionsOverrides>(factionsOverrides => FactionsOverrides = factionsOverrides);
        WorldStateEventBus.Register<Models.Player.WorldState>(worldState => WorldState = worldState);
        WorldStateEventBus.Register<WorldStateValue>(worldStateValue => WorldState.UpdateWorldStateValue(worldStateValue));
        WorldStateEventBus.Register<Proficiency>(proficiency => Proficiencies.UpdateProficiency(proficiency));
    }

    protected override void UnregisterWorldStateBusEvents()
    {
        WorldStateEventBus.Unregister<Achievements>(achievements => Achievements = achievements);
        WorldStateEventBus.Unregister<WorldPoint>(bindPoint => BindPoint = bindPoint);
        WorldStateEventBus.Unregister<DungeonDifficulty>(difficultyInfo => DungeonDifficulty = difficultyInfo);
        WorldStateEventBus.Unregister<InstanceDifficulty>(instanceDifficulty => InstanceDifficulty = instanceDifficulty);
        WorldStateEventBus.Unregister<PlayerTalentsInformations>(talents => PlayerTalents = talents);
        WorldStateEventBus.Unregister<PetTalentsInformations>(talents => PetTalents = talents);
        WorldStateEventBus.Unregister<SpellsList>(spellsInformations => Spells = spellsInformations.Spells);
        WorldStateEventBus.Unregister<UnlearnedSpellsList>(unlearnedSpellsList => UnlearnedSpells = unlearnedSpellsList.Spells);
        WorldStateEventBus.Unregister<Factions>(factions => Factions = factions.Reputations);
        WorldStateEventBus.Unregister<ActionButtons>(buttons => Buttons = buttons);
        WorldStateEventBus.Unregister<EquipmentSets>(equipmentSets => EquipmentSets = equipmentSets);
        WorldStateEventBus.Unregister<FactionsOverrides>(factionsOverrides => FactionsOverrides = factionsOverrides);
        WorldStateEventBus.Unregister<Models.Player.WorldState>(worldState => WorldState = worldState);
        WorldStateEventBus.Unregister<WorldStateValue>(worldStateValue => WorldState.UpdateWorldStateValue(worldStateValue));
        WorldStateEventBus.Unregister<Proficiency>(proficiency => Proficiencies.UpdateProficiency(proficiency));
    }
}