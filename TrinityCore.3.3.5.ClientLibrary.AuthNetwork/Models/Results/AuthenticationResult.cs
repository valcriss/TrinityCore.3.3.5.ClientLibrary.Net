using System.Numerics;

namespace TrinityCore._3._3._5.ClientLibrary.AuthNetwork.Models.Results;

public class AuthenticationResult
{
    public string AccountName { get; private set; }
    public bool IsAuthenticated { get; private set; }

    public BigInteger SessionKey { get; set; }

    public AuthenticationResult(string accountName, BigInteger sessionKey, bool isAuthenticated)
    {
        AccountName = accountName;
        IsAuthenticated = isAuthenticated;
        SessionKey = sessionKey;
    }
}