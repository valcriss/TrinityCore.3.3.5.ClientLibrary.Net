namespace TrinityCore._3._3._5.ClientLibrary.WorldState.Enums;

public enum AiReactionType
{
    AI_REACTION_ALERT = 0, // pre-aggro (used in client packet handler)
    AI_REACTION_FRIENDLY = 1, // (NOT used in client packet handler)
    AI_REACTION_HOSTILE = 2, // sent on every attack, triggers aggro sound (used in client packet handler)
    AI_REACTION_AFRAID = 3, // seen for polymorph (when AI not in control of self?) (NOT used in client packet handler)
    AI_REACTION_DESTROY = 4 // used on object destroy (NOT used in client packet handler)
}