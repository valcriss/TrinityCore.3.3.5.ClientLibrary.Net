using TrinityCore._3._3._5.ClientLibrary.WorldNetwork.Models.Messages.States.Account;
using TrinityCore._3._3._5.ClientLibrary.WorldNetwork.Models.Messages.States.Player;
using TrinityCore._3._3._5.ClientLibrary.WorldState;

namespace TrinityCore._3._3._5.ClientLibrary.WorldNetwork.Models.Handlers;

public class AccountStateHandler
{
    private readonly WorldStateEventBus _worldStateEventBus;

    public AccountStateHandler(WorldStateEventBus worldStateEventBus)
    {
        _worldStateEventBus = worldStateEventBus;
    }

    public void OnTutorialFlags(ServerTutorialFlagsInfo serverTutorialFlagsInfo)
    {
        _worldStateEventBus.Publish(serverTutorialFlagsInfo.TutorialFlags);
    }

    public void OnAccountDataTimesInfo(ServerAccountDataTimesInfo serverAccountDataTimesInfo)
    {
        _worldStateEventBus.Publish(serverAccountDataTimesInfo.AccountDataTimes);
    }


}