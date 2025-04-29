using TrinityCore._3._3._5.ClientLibrary.Dbc;
using TrinityCore._3._3._5.ClientLibrary.Shared.Logger;
using TrinityCore._3._3._5.ClientLibrary.WorldState.Core;
using TrinityCore._3._3._5.ClientLibrary.WorldState.Models.Social;

namespace TrinityCore._3._3._5.ClientLibrary.WorldState.States;

public class SocialState : State
{
    public SocialState(WorldStateEventBus worldStateEventBus, DbcCollection dbcCollection) : base(worldStateEventBus, dbcCollection)
    {
    }

    public Contacts Contacts { get; private set; } = new();

    protected override void RegisterWorldStateBusEvents()
    {
        WorldStateEventBus.Register<Contacts>(contacts =>
        {
            Log.Debug(contacts.ToString());
            Contacts = contacts;
        });
    }

    protected override void UnregisterWorldStateBusEvents()
    {
    }
}