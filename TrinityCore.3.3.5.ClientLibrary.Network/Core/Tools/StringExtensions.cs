using System.Text;

namespace TrinityCore._3._3._5.ClientLibrary.Network.Core.Tools;

public static class StringExtensions
{
    public static byte[] GetAsciiBytes(this string value)
    {
        return Encoding.ASCII.GetBytes(value);
    }
}