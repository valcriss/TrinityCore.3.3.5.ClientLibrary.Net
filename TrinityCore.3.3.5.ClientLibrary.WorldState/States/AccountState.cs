using TrinityCore._3._3._5.ClientLibrary.Dbc;
using TrinityCore._3._3._5.ClientLibrary.WorldState.Core;
using TrinityCore._3._3._5.ClientLibrary.WorldState.Models.Account;

namespace TrinityCore._3._3._5.ClientLibrary.WorldState.States;

public class AccountState : State
{
    public AccountState(WorldStateEventBus worldStateEventBus) : base(worldStateEventBus)
    {
    }

    public uint[] TutorialFlags { get; private set; } = [];
    public AccountDataTimes AccountDataTimes { get; private set; } = new();


    protected override void RegisterWorldStateBusEvents()
    {
        WorldStateEventBus.Register<TutorialFlags>(tutorialFlags => TutorialFlags = tutorialFlags.Values);
        WorldStateEventBus.Register<AccountDataTimes>(accountDataTimes => AccountDataTimes = accountDataTimes);
    }

    protected override void UnregisterWorldStateBusEvents()
    {
        WorldStateEventBus.Unregister<TutorialFlags>(tutorialFlags => TutorialFlags = tutorialFlags.Values);
        WorldStateEventBus.Unregister<AccountDataTimes>(accountDataTimes => AccountDataTimes = accountDataTimes);
    }
}