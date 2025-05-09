namespace TrinityCore._3._3._5.ClientLibrary.Client.Exceptions;

public class WorldConnexionFailedException : Exception
{
    public WorldConnexionFailedException(string message) : base(message)
    {
    }

    public WorldConnexionFailedException(string message, Exception innerException) : base(message, innerException)
    {
    }
}