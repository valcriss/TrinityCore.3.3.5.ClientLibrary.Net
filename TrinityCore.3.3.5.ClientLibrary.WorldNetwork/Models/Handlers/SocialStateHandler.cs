using TrinityCore._3._3._5.ClientLibrary.WorldNetwork.Models.Messages.States.Social;
using TrinityCore._3._3._5.ClientLibrary.WorldState;

namespace TrinityCore._3._3._5.ClientLibrary.WorldNetwork.Models.Handlers;

public class SocialStateHandler
{
    private readonly WorldStateEventBus _worldStateEventBus;

    public SocialStateHandler(WorldStateEventBus worldStateEventBus)
    {
        _worldStateEventBus = worldStateEventBus;
    }

    public void OnServerContactListInfo(ServerContactListInfo serverContactListInfo)
    {
        _worldStateEventBus.Publish(serverContactListInfo.Contacts);
    }
}