using System.Numerics;
using TrinityCore._3._3._5.ClientLibrary.AuthNetwork.Enums;

namespace TrinityCore._3._3._5.ClientLibrary.AuthNetwork.Models.Results;

public class AuthenticationResult
{
    public string Username { get; private set; }
    public bool IsAuthenticated { get; private set; }
    public BigInteger SessionKey { get; set; }
    public ConnexionResult ConnexionResult { get; set; }

    public AuthenticationResult(string username, BigInteger sessionKey)
    {
        Username = username;
        IsAuthenticated = false;
        SessionKey = sessionKey;
        ConnexionResult = ConnexionResult.NONE;
    }

    public void Reset()
    {
        ConnexionResult = ConnexionResult.NONE;
        IsAuthenticated = false;
    }

    public void Fail(ConnexionResult result)
    {
        ConnexionResult = result;
        IsAuthenticated = false;
    }

    public void Success()
    {
        ConnexionResult = ConnexionResult.SUCCESS;
        IsAuthenticated = true;
    }
}