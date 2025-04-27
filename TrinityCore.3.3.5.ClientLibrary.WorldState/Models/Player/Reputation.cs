using TrinityCore._3._3._5.ClientLibrary.WorldState.Enums;

namespace TrinityCore._3._3._5.ClientLibrary.WorldState.Models.Player;

public class Reputation
{
    public FactionOptions Flags { get; set; }
    public uint Id { get; set; }
    public uint Standing { get; set; }
}