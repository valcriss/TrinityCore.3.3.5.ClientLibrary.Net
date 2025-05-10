using TrinityCore._3._3._5.ClientLibrary.WorldState.Core;
using TrinityCore._3._3._5.ClientLibrary.WorldState.Enums;
using TrinityCore._3._3._5.ClientLibrary.WorldState.Models.Environment;

namespace TrinityCore._3._3._5.ClientLibrary.WorldState.States;

public class EnvironmentState : State
{
    public EnvironmentState(WorldStateEventBus worldStateEventBus) : base(worldStateEventBus)
    {
    }

    public EntitiesCollection EntitiesCollection { get; } = new();

    public Weather Weather { get; private set; } = new();

    protected override void RegisterWorldStateBusEvents()
    {
        WorldStateEventBus.Register<Weather>(weather => Weather = weather);
        WorldStateEventBus.Register<UpdatePackage>(updatePackage => EntitiesCollection.Update(updatePackage));
        WorldStateEventBus.Register<MonsterMoveData>(monsterMoveData => EntitiesCollection.UpdateMove(monsterMoveData));
        WorldStateEventBus.Register<QuestGiverInfoMultiple>(questGiverInfoMultiple => EntitiesCollection.UpdateQuestGiverMultiple(questGiverInfoMultiple));
        WorldStateEventBus.Register<DestroyObject>(destroyObject => EntitiesCollection.DestroyObject(destroyObject));
        WorldStateEventBus.Register<ThreatData>(threatData => EntitiesCollection.UpdateThreat(threatData));
        WorldStateEventBus.Register<AiReaction>(aiReaction => EntitiesCollection.UpdateReaction(aiReaction));
        WorldStateEventBus.Register<MovementUpdate>(movementUpdate => EntitiesCollection.UpdateMovement(movementUpdate));
        WorldStateEventBus.Register<AttackStartInfo>(attackStartInfo => EntitiesCollection.UpdateAttackStart(attackStartInfo));
        WorldStateEventBus.Register<AttackStopInfo>(attackStopInfo => EntitiesCollection.UpdateAttackStop(attackStopInfo));
        WorldStateEventBus.Register<ThreatClear>(threatClear => EntitiesCollection.ClearThreat(threatClear));
    }

    protected override void UnregisterWorldStateBusEvents()
    {
        WorldStateEventBus.Unregister<Weather>(weather => Weather = weather);
        WorldStateEventBus.Unregister<UpdatePackage>(updatePackage => EntitiesCollection.Update(updatePackage));
        WorldStateEventBus.Unregister<MonsterMoveData>(monsterMoveData => EntitiesCollection.UpdateMove(monsterMoveData));
        WorldStateEventBus.Unregister<QuestGiverInfoMultiple>(questGiverInfoMultiple => EntitiesCollection.UpdateQuestGiverMultiple(questGiverInfoMultiple));
        WorldStateEventBus.Unregister<DestroyObject>(destroyObject => EntitiesCollection.DestroyObject(destroyObject));
        WorldStateEventBus.Unregister<ThreatData>(threatData => EntitiesCollection.UpdateThreat(threatData));
        WorldStateEventBus.Unregister<AiReaction>(aiReaction => EntitiesCollection.UpdateReaction(aiReaction));
        WorldStateEventBus.Unregister<MovementUpdate>(movementUpdate => EntitiesCollection.UpdateMovement(movementUpdate));
        WorldStateEventBus.Unregister<AttackStartInfo>(attackStartInfo => EntitiesCollection.UpdateAttackStart(attackStartInfo));
        WorldStateEventBus.Unregister<AttackStopInfo>(attackStopInfo => EntitiesCollection.UpdateAttackStop(attackStopInfo));
        WorldStateEventBus.Unregister<ThreatClear>(threatClear => EntitiesCollection.ClearThreat(threatClear));
    }
}