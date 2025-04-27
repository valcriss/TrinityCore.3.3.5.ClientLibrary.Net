namespace TrinityCore._3._3._5.ClientLibrary.WorldState.Models.Player;

public class WorldState
{
    public int MapId { get; set; }
    public int ZoneId { get; set; }
    public int AreaId { get; set; }

    public Dictionary<int, int> Variables { get; } = new();

    public void UpdateWorldStateValue(WorldStateValue worldStateValue)
    {
        if (Variables.ContainsKey(worldStateValue.Id))
            Variables[worldStateValue.Id] = worldStateValue.Value;
        else
            Variables.Add(worldStateValue.Id, worldStateValue.Value);
    }
}