using TrinityCore._3._3._5.ClientLibrary.Dbc;
using TrinityCore._3._3._5.ClientLibrary.Shared.Logger;
using TrinityCore._3._3._5.ClientLibrary.WorldState.Core;
using TrinityCore._3._3._5.ClientLibrary.WorldState.Enums;
using TrinityCore._3._3._5.ClientLibrary.WorldState.Models.Player;

namespace TrinityCore._3._3._5.ClientLibrary.WorldState.States;

public class EntitiesState : State
{
    public EntitiesState(WorldStateEventBus worldStateEventBus, DbcCollection dbcCollection) : base(worldStateEventBus, dbcCollection)
    {
    }

    protected override void RegisterWorldStateBusEvents()
    {
        WorldStateEventBus.Register<PowerUpdate>(powerUpdate => UpdateEntityPower(powerUpdate.Guid, powerUpdate.Power, powerUpdate.Value));
    }

    protected override void UnregisterWorldStateBusEvents()
    {
        WorldStateEventBus.Unregister<PowerUpdate>(powerUpdate => UpdateEntityPower(powerUpdate.Guid, powerUpdate.Power, powerUpdate.Value));
    }

    private void UpdateEntityPower(ulong guid, Powers power, uint value)
    {
        Log.Debug($"Entity Power Update: Guid: {guid}, Power: {power}, Value: {value}");
    }
}