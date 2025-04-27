namespace TrinityCore._3._3._5.ClientLibrary.WorldState.Models.Player;

public class EquipmentSet
{
    public ulong Guid { get; set; }
    public uint SetId { get; set; }
    public string Name { get; set; }
    public string Icon { get; set; }
    public Dictionary<int, ulong> Items { get; set; } = new();
    public uint IgnoreMask { get; set; }
}