using TrinityCore._3._3._5.ClientLibrary.WorldState.Enums;

namespace TrinityCore._3._3._5.ClientLibrary.WorldState.Models.Player;

public class ActionButton
{
    public uint ActionId; // ID du sort, objet, macro, etc.
    public ActionButtonType Type; // Type de bouton (sort, objet, macro, etc.)
    public string TypeName = string.Empty;
}