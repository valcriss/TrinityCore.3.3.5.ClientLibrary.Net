namespace TrinityCore._3._3._5.ClientLibrary.WorldState.Core;

public abstract class State : IDisposable
{
    public State(WorldStateEventBus worldStateEventBus)
    {
        WorldStateEventBus = worldStateEventBus;
        RegisterWorldStateBusEvents();
    }

    protected WorldStateEventBus WorldStateEventBus { get; set; }

    public virtual void Dispose()
    {
        UnregisterWorldStateBusEvents();
    }

    protected abstract void RegisterWorldStateBusEvents();
    protected abstract void UnregisterWorldStateBusEvents();
}