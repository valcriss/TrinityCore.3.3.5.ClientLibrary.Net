using TrinityCore._3._3._5.ClientLibrary.WorldState.Core;
using TrinityCore._3._3._5.ClientLibrary.WorldState.Models.Environment;

namespace TrinityCore._3._3._5.ClientLibrary.WorldState.States;

public class EnvironmentState : State
{
    public EnvironmentState(WorldStateEventBus worldStateEventBus) : base(worldStateEventBus)
    {
    }

    public Weather Weather { get; private set; } = new();

    protected override void RegisterWorldStateBusEvents()
    {
        WorldStateEventBus.Register<Weather>(weather => Weather = weather);
        //WorldStateEventBus.Register<UpdatePackage>(updatePackage => Weather = weather);
    }

    protected override void UnregisterWorldStateBusEvents()
    {
        WorldStateEventBus.Unregister<Weather>(weather => Weather = weather);
        //WorldStateEventBus.Unregister<UpdatePackage>(updatePackage => Weather = weather);
    }
}