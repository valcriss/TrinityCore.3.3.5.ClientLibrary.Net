using TrinityCore._3._3._5.ClientLibrary.WorldState.Core;
using TrinityCore._3._3._5.ClientLibrary.WorldState.Models.Account;
using TrinityCore._3._3._5.ClientLibrary.WorldState.Models.Server;

namespace TrinityCore._3._3._5.ClientLibrary.WorldState.States;

public class ServerState : State
{
    public ServerState(WorldStateEventBus worldStateEventBus) : base(worldStateEventBus)
    {
    }

    public uint Version { get; private set; }
    public string MessageOfTheDay { get; private set; } = string.Empty;
    public TimeSpeedInfo TimeSpeedInfo { get; private set; } = new();
    public FeatureSystemStatus FeatureSystemStatus { get; private set; } = new();

    protected override void RegisterWorldStateBusEvents()
    {
        WorldStateEventBus.Register<CacheVersion>(cacheVersion => Version = cacheVersion.Version);
        WorldStateEventBus.Register<MessageOfTheDay>(messageOfTheDay => MessageOfTheDay = messageOfTheDay.Message);
        WorldStateEventBus.Register<TimeSpeedInfo>(timeSpeedInfo => TimeSpeedInfo = timeSpeedInfo);
        WorldStateEventBus.Register<FeatureSystemStatus>(featureSystemStatus => FeatureSystemStatus = featureSystemStatus);
    }

    protected override void UnregisterWorldStateBusEvents()
    {
        WorldStateEventBus.Unregister<CacheVersion>(cacheVersion => Version = cacheVersion.Version);
        WorldStateEventBus.Unregister<MessageOfTheDay>(messageOfTheDay => MessageOfTheDay = messageOfTheDay.Message);
        WorldStateEventBus.Unregister<TimeSpeedInfo>(timeSpeedInfo => TimeSpeedInfo = timeSpeedInfo);
        WorldStateEventBus.Unregister<FeatureSystemStatus>(featureSystemStatus => FeatureSystemStatus = featureSystemStatus);
    }
}