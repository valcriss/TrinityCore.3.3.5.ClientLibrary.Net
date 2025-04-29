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
}