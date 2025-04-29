using TrinityCore._3._3._5.ClientLibrary.Dbc;

namespace TrinityCore._3._3._5.ClientLibrary.WorldState.Core;

public abstract class State : IDisposable
{
    public State(WorldStateEventBus worldStateEventBus, DbcCollection dbcCollection)
    {
        WorldStateEventBus = worldStateEventBus;
        DbcCollection = dbcCollection;
        RegisterWorldStateBusEvents();
    }

    protected WorldStateEventBus WorldStateEventBus { get; set; }
    protected DbcCollection DbcCollection { get; set; }

    public virtual void Dispose()
    {
        UnregisterWorldStateBusEvents();
    }

    protected abstract void RegisterWorldStateBusEvents();
    protected abstract void UnregisterWorldStateBusEvents();
}