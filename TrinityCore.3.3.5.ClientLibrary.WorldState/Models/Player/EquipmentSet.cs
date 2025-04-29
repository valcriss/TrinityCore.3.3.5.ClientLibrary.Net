namespace TrinityCore._3._3._5.ClientLibrary.WorldState.Models.Player;

public class EquipmentSet
{
    public ulong Guid { get; set; }
    public uint SetId { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Icon { get; set; } = string.Empty;
    public Dictionary<int, ulong> Items { get; } = new();
    public uint IgnoreMask { get; set; }
}