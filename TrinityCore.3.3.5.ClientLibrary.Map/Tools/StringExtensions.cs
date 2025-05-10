using System.Text.RegularExpressions;

namespace TrinityCore._3._3._5.ClientLibrary.Map.Tools;

public static class StringExtensions
{
    #region Public Methods

    public static bool CheckExtension(this string file, string expectedExtention)
    {
        try
        {
            string ext = Path.GetExtension(file).ToLower();
            return (expectedExtention.StartsWith(".") ? expectedExtention.ToLower() : "." + expectedExtention.ToLower()) == ext;
        }
        catch (ArgumentException)
        {
            return false;
        }
    }

    public static bool CheckRegExp(this string file, string regexp)
    {
        try
        {
            string filename = Path.GetFileNameWithoutExtension(file);
            return Regex.Match(filename, regexp).Success;
        }
        catch (ArgumentException)
        {
            return false;
        }
    }

    public static bool Exists(this string file)
    {
        return File.Exists(file);
    }

    #endregion Public Methods
}