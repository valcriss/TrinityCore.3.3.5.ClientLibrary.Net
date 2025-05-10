namespace TrinityCore._3._3._5.ClientLibrary.Map.Exceptions;

public class DirectoryInvalidException : Exception
{
    #region Public Constructors

    public DirectoryInvalidException()
        : base("Provided directory is not valid (not exists or no map data found)")
    {
    }

    #endregion Public Constructors
}