using TrinityCore._3._3._5.ClientLibrary.WorldNetwork.Models.Messages.States.Environment;
using TrinityCore._3._3._5.ClientLibrary.WorldState;

namespace TrinityCore._3._3._5.ClientLibrary.WorldNetwork.Models.Handlers;

public class EnvironmentStateHandler
{
    private readonly WorldStateEventBus _worldStateEventBus;

    public EnvironmentStateHandler(WorldStateEventBus worldStateEventBus)
    {
        _worldStateEventBus = worldStateEventBus;
    }

    public void OnServerWeather(ServerWeather serverWeather)
    {
        _worldStateEventBus.Publish(serverWeather.Weather);
    }

    public void OnServerUpdateObjectInfo(ServerUpdateObjectInfo serverUpdateObjectInfo)
    {
        _worldStateEventBus.Publish(serverUpdateObjectInfo.UpdatePackage);
    }

    public void OnServerMonsterMove(ServerMonsterMove serverMonsterMove)
    {
        _worldStateEventBus.Publish(serverMonsterMove.MonsterMoveData);
    }

    public void OnServerSpellGo(ServerSpellGo serverSpellGo)
    {
        _worldStateEventBus.Publish(serverSpellGo.SpellGoInfo);
    }

    public void OnServerQuestGiverStatusMultiple(ServerQuestGiverStatusMultiple questGiverStatusMultiple)
    {
        _worldStateEventBus.Publish(questGiverStatusMultiple.QuestGiverInfoMultiple);
    }

    public void OnServerDestroyObject(ServerDestroyObject serverDestroyObject)
    {
        _worldStateEventBus.Publish(serverDestroyObject.DestroyObject);
    }

    public void OnServerHighestThreatUpdate(ServerHighestThreatUpdate serverHighestThreatUpdate)
    {
        _worldStateEventBus.Publish(serverHighestThreatUpdate.ThreatData);
    }

    public void OnServerAiReaction(ServerAiReaction serverAiReaction)
    {
        _worldStateEventBus.Publish(serverAiReaction.AiReaction);
    }

    public void OnServerMoveSetFacing(ServerMoveSetFacing serverMoveSetFacing)
    {
        _worldStateEventBus.Publish(serverMoveSetFacing.MovementUpdate);
    }

    public void OnServerAttackStartInfo(ServerAttackStartInfo serverAttackStartInfo)
    {
        _worldStateEventBus.Publish(serverAttackStartInfo.AttackStartInfo);
    }

    public void OnServerAttackStopInfo(ServerAttackStopInfo serverAttackStopInfo)
    {
        _worldStateEventBus.Publish(serverAttackStopInfo.AttackStopInfo);
    }

    public void OnServerThreatClear(ServerThreatClear serverThreatClear)
    {
        _worldStateEventBus.Publish(serverThreatClear.ThreatClear);
    }
}