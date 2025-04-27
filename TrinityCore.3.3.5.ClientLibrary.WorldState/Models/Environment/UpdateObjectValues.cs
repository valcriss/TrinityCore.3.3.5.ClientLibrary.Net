using TrinityCore._3._3._5.ClientLibrary.WorldState.Enums;

namespace TrinityCore._3._3._5.ClientLibrary.WorldState.Models.Environment;

public class UpdateObjectValues
{
    public ulong Guid { get; set; }
    public Dictionary<UpdateFields, uint> Values { get; set; } = new();
}