using TrinityCore._3._3._5.ClientLibrary.WorldState.Enums;

namespace TrinityCore._3._3._5.ClientLibrary.WorldState.Models.Social;

public class Friend : Contact
{
    public uint? AreaId { get; set; }
    public Class? Class { get; set; }
    public uint? Level { get; set; }
    public FriendStatus Status { get; set; }
}