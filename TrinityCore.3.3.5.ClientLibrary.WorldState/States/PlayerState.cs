using TrinityCore._3._3._5.ClientLibrary.Shared.Math;
using TrinityCore._3._3._5.ClientLibrary.WorldState.Core;
using TrinityCore._3._3._5.ClientLibrary.WorldState.Models.Account;
using TrinityCore._3._3._5.ClientLibrary.WorldState.Models.Player;

namespace TrinityCore._3._3._5.ClientLibrary.WorldState.States;

public class PlayerState : State
{
    public Achievements Achievements { get; private set; } = new();
    public WorldPoint BindPoint { get; private set; } = new();
    
    public PlayerState(WorldStateEventBus worldStateEventBus) : base(worldStateEventBus)
    {
    }

    protected override void RegisterWorldStateBusEvents()
    {
        WorldStateEventBus.Register<Achievements>(achievements => Achievements = achievements);
        WorldStateEventBus.Register<WorldPoint>(bindPoint => BindPoint = bindPoint);
    }

    protected override void UnregisterWorldStateBusEvents()
    {
        WorldStateEventBus.Unregister<Achievements>(achievements => Achievements = achievements);
        WorldStateEventBus.Unregister<WorldPoint>(bindPoint => BindPoint = bindPoint);
    }
}