namespace TrinityCore._3._3._5.ClientLibrary.WorldState.Models.Account;

public class TutorialFlags
{
    public const int MAX_ACCOUNT_TUTORIAL_VALUES = 8;
    public uint[] Values { get; set; } = new uint[MAX_ACCOUNT_TUTORIAL_VALUES];
}