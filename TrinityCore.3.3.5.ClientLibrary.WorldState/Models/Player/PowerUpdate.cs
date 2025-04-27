using TrinityCore._3._3._5.ClientLibrary.WorldState.Enums;

namespace TrinityCore._3._3._5.ClientLibrary.WorldState.Models.Player;

public class PowerUpdate
{
    public ulong Guid { get; set; }
    public Powers Power { get; set; }
    public uint Value { get; set; }
}