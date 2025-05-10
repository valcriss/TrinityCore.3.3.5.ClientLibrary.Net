namespace TrinityCore._3._3._5.ClientLibrary.Map.Exceptions;

public class FileBadFilenamePatternException : Exception
{
    #region Public Constructors

    public FileBadFilenamePatternException(string patternType, string pattern) : base("Provided filename does not match expected " + patternType + " filename pattern (" + pattern + ")")
    {
    }

    #endregion Public Constructors
}