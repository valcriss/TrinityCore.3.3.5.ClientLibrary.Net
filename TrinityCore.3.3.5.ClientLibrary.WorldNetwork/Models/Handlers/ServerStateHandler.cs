using TrinityCore._3._3._5.ClientLibrary.WorldNetwork.Models.Messages.States.Server;
using TrinityCore._3._3._5.ClientLibrary.WorldState;

namespace TrinityCore._3._3._5.ClientLibrary.WorldNetwork.Models.Handlers;

public class ServerStateHandler
{
    private readonly WorldStateEventBus _worldStateEventBus;

    public ServerStateHandler(WorldStateEventBus worldStateEventBus)
    {
        _worldStateEventBus = worldStateEventBus;
    }

    public void OnClientCacheVersionInfo(ClientCacheVersionInfo clientCacheVersionInfo)
    {
        _worldStateEventBus.Publish(clientCacheVersionInfo.CacheVersion);
    }

    public void OnServerMessageOfTheDayInfo(ServerMessageOfTheDayInfo serverMessageOfTheDayInfo)
    {
        _worldStateEventBus.Publish(serverMessageOfTheDayInfo.MessageOfTheDay);
    }

    public void OnServerLoginSetTimeSpeedInfo(ServerLoginSetTimeSpeedInfo serverLoginSetTimeSpeedInfo)
    {
        _worldStateEventBus.Publish(serverLoginSetTimeSpeedInfo.TimeSpeedInfo);
    }

    public void OnServerFeatureSystemStatusInfo(ServerFeatureSystemStatusInfo serverTutorialFlagsInfo)
    {
        _worldStateEventBus.Publish(serverTutorialFlagsInfo.FeatureSystemStatus);
    }
}