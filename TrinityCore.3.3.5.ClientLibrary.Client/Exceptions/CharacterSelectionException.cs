namespace TrinityCore._3._3._5.ClientLibrary.Client.Exceptions;

public class CharacterSelectionException : Exception
{
    public CharacterSelectionException(string message) : base(message)
    {
    }

    public CharacterSelectionException(string message, Exception innerException) : base(message, innerException)
    {
    }
}