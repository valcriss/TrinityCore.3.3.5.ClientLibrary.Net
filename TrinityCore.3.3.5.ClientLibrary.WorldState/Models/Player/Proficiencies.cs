using TrinityCore._3._3._5.ClientLibrary.Shared.Logger;
using TrinityCore._3._3._5.ClientLibrary.WorldState.Enums;

namespace TrinityCore._3._3._5.ClientLibrary.WorldState.Models.Player;

public class Proficiencies
{
    public Dictionary<ItemClass, uint> Values { get; set; } = new();

    public void UpdateProficiency(Proficiency proficiency)
    {
        Log.Debug($"Updating proficiency for {proficiency.ItemClass} with mask {proficiency.ProficiencyMask}");
        if (Values.ContainsKey(proficiency.ItemClass))
            Values[proficiency.ItemClass] = proficiency.ProficiencyMask;
        else
            Values.Add(proficiency.ItemClass, proficiency.ProficiencyMask);
    }

    public bool CanUse(ItemClass itemClass, int subClass)
    {
        if (!Values.TryGetValue(itemClass, out uint subclassMask))
            return false;
        return (subclassMask & (1 << subClass)) != 0;
    }
}