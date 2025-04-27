using TrinityCore._3._3._5.ClientLibrary.WorldState.Enums;

namespace TrinityCore._3._3._5.ClientLibrary.WorldState.Models.Player;

public class DungeonDifficulty
{
    public Difficulty Difficulty { get; set; }
    public bool IsInGroup { get; set; }
}