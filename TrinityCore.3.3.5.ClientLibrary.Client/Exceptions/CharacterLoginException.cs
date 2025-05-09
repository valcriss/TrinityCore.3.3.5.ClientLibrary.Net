namespace TrinityCore._3._3._5.ClientLibrary.Client.Exceptions;

public class CharacterLoginException : Exception
{
    public CharacterLoginException(string message) : base(message)
    {
    }

    public CharacterLoginException(string message, Exception innerException) : base(message, innerException)
    {
    }
}