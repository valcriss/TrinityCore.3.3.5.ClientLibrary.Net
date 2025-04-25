using System.Numerics;

namespace TrinityCore._3._3._5.ClientLibrary.AuthNetwork.Models.Results;

public class AuthenticationResult
{
    public string Username { get; private set; }
    public bool IsAuthenticated { get; private set; }
    public BigInteger SessionKey { get; set; }

    public AuthenticationResult(string username, BigInteger sessionKey, bool isAuthenticated)
    {
        Username = username;
        IsAuthenticated = isAuthenticated;
        SessionKey = sessionKey;
    }
}