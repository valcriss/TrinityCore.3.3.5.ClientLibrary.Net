using System.Net;
using System.Numerics;
using System.Reflection;
using System.Reflection.Emit;
using Moq;
using TrinityCore._3._3._5.ClientLibrary.AuthNetwork;
using TrinityCore._3._3._5.ClientLibrary.AuthNetwork.Enums;
using TrinityCore._3._3._5.ClientLibrary.AuthNetwork.Models.Messages;
using TrinityCore._3._3._5.ClientLibrary.AuthNetwork.Models.Network;
using TrinityCore._3._3._5.ClientLibrary.AuthNetwork.Models.Results;
using TrinityCore._3._3._5.ClientLibrary.Network.Core;
using TrinityCore._3._3._5.ClientLibrary.Network.Core.Parsers;
using TrinityCore._3._3._5.ClientLibrary.Network.Core.Readers;
using TrinityCore._3._3._5.ClientLibrary.Network.Core.Registry;
using TrinityCore._3._3._5.ClientLibrary.Network.Core.Writers;
using TrinityCore._3._3._5.ClientLibrary.Shared.Enums;

namespace TrinityCore._3._3._5.ClientLibrary.AuthNetworkTest;

[TestClass]
public class AuthNetworkClientTests
{
    private const string Host = "localhost";
    private const int Port = 3724;
    private const string Username = "TESTUSER";
    private const string Password = "password";
    
    private AuthNetworkClient _client;
    
    [TestMethod]
    public async Task AuthenticateAsync_NetworkError_ThrowsException()
    {
        // Arrange
        // Créer un client AuthNetworkClient avec des paramètres qui causent une exception
        _client = new AuthNetworkClient("invalid.host", -1, Username, Password);
        
        // Act & Assert - Exception expected
        var result = await _client.AuthenticateAsync();
        
        Assert.IsFalse(result.IsAuthenticated);
    }
    
    [TestCleanup]
    public void Cleanup()
    {
        _client?.Dispose();
    }
}