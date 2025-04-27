using TrinityCore._3._3._5.ClientLibrary.WorldNetwork.Models.Messages.States.Account;
using TrinityCore._3._3._5.ClientLibrary.WorldNetwork.Models.Messages.States.Player;
using TrinityCore._3._3._5.ClientLibrary.WorldState;

namespace TrinityCore._3._3._5.ClientLibrary.WorldNetwork.Models.Handlers;

public class PlayerStateHandler
{
    private readonly WorldStateEventBus _worldStateEventBus;

    public PlayerStateHandler(WorldStateEventBus worldStateEventBus)
    {
        _worldStateEventBus = worldStateEventBus;
    }
    
    public void OnServerAllAchievementDataInfo(ServerAllAchievementDataInfo serverAllAchievementDataInfo)
    {
        _worldStateEventBus.Publish(serverAllAchievementDataInfo.Achievements);
    }

    public void OnServerBindPointUpdate(ServerBindPointUpdate serverBindPointUpdate)
    {
        _worldStateEventBus.Publish(serverBindPointUpdate.BindPoint);
    }
}