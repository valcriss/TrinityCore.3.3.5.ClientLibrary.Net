using TrinityCore._3._3._5.ClientLibrary.WorldNetwork.Models.Messages.States.Player;
using TrinityCore._3._3._5.ClientLibrary.WorldState;
using TrinityCore._3._3._5.ClientLibrary.WorldState.Models.Player;

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

    public void OnServerDungeonDifficultyInfo(ServerDungeonDifficultyInfo serverDungeonDifficultyInfo)
    {
        _worldStateEventBus.Publish(serverDungeonDifficultyInfo.DungeonDifficulty);
    }


    public void OnServerInstanceDifficultyInfo(ServerInstanceDifficultyInfo serverInstanceDifficultyInfo)
    {
        _worldStateEventBus.Publish(serverInstanceDifficultyInfo.InstanceDifficulty);
    }

    public void OnServerTalentsInfo(ServerTalentsInfo serverTalentsInfo)
    {
        if (serverTalentsInfo.TalentsInfo.IsPet)
            _worldStateEventBus.Publish(new PetTalentsInformations(serverTalentsInfo.TalentsInfo));
        else
            _worldStateEventBus.Publish(new PlayerTalentsInformations(serverTalentsInfo.TalentsInfo));
    }

    public void OnServerInitialSpellsInfo(ServerInitialSpellsInfo serverInitialSpellsInfo)
    {
        _worldStateEventBus.Publish(serverInitialSpellsInfo.SpellsList);
    }

    public void OnServerUnlearnedSpellsInfo(ServerUnlearnedSpellsInfo serverUnlearnedSpellsInfo)
    {
        _worldStateEventBus.Publish(serverUnlearnedSpellsInfo.UnlearnedSpells);
    }

    public void OnServerPowerUpdateInfo(ServerPowerUpdateInfo serverPowerUpdateInfo)
    {
        _worldStateEventBus.Publish(serverPowerUpdateInfo.PowerUpdate);
    }

    public void OnServerInitializeFactionsInfo(ServerInitializeFactionsInfo serverInitializeFactionsInfo)
    {
        _worldStateEventBus.Publish(serverInitializeFactionsInfo.Factions);
    }

    public void OnServerActionButtons(ServerActionButtons serverActionButtons)
    {
        _worldStateEventBus.Publish(serverActionButtons.Buttons);
    }

    public void OnServerEquipmentSetList(ServerEquipmentSetList serverEquipmentSetList)
    {
        _worldStateEventBus.Publish(serverEquipmentSetList.EquipmentSets);
    }

    public void OnServerForcedReactions(ServerForcedReactions serverForcedReactions)
    {
        _worldStateEventBus.Publish(serverForcedReactions.Overrides);
    }

    public void OnServerInitWorldStates(ServerInitWorldStates serverInitWorldStates)
    {
        _worldStateEventBus.Publish(serverInitWorldStates.WorldState);
    }

    public void OnServerUpdateWorldState(ServerUpdateWorldState serverUpdateWorldState)
    {
        _worldStateEventBus.Publish(serverUpdateWorldState.WorldStateValue);
    }

    public void OnServerProficiency(ServerProficiency serverProficiency)
    {
        _worldStateEventBus.Publish(serverProficiency.Proficiency);
    }
}