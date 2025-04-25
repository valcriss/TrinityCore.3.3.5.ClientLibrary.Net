using Moq;
using TrinityCore._3._3._5.ClientLibrary.AuthNetwork.Enums;
using TrinityCore._3._3._5.ClientLibrary.AuthNetwork.Models.Messages;
using TrinityCore._3._3._5.ClientLibrary.AuthNetwork.Models.Network;
using TrinityCore._3._3._5.ClientLibrary.AuthNetwork.Models.Process;
using TrinityCore._3._3._5.ClientLibrary.AuthNetwork.Models.Security;
using TrinityCore._3._3._5.ClientLibrary.Network;
using TrinityCore._3._3._5.ClientLibrary.Network.Core.Readers;

namespace TrinityCore._3._3._5.ClientLibrary.AuthNetworkTest;

// Interface pour pouvoir mocker NetworkClient
public interface INetworkClient<T>
{
    Task SendAsync<TMessage>(TMessage message) where TMessage : class;
    // Ajoutez ici d'autres méthodes nécessaires pour vos tests
}

[TestClass]
public class AuthenticationProcessTests
{
    private Mock<NetworkClient<AuthCommands>> _mockNetworkClient;
    private AuthCredentials _authCredentials;
    private ManualResetEvent _authenticateDone;
    private AuthenticationProcess _authenticationProcess;
    
    [TestInitialize]
    public void Initialize()
    {
        AuthFrameHeaderReader headerReader = new();
        FrameReader<AuthCommands> frameReader = new(headerReader);
        _mockNetworkClient = new Mock<NetworkClient<AuthCommands>>(
            "localhost", 
            1234,
            frameReader, // frameReader
            null, // frameWriter
            null, // packetParser
            null  // eventBus
        );
        
        _authCredentials = new AuthCredentials("username", "password");
        _authenticateDone = new ManualResetEvent(false);
        _authenticationProcess = new AuthenticationProcess(_mockNetworkClient.Object, _authCredentials, _authenticateDone);
    }
    
    [TestMethod]
    public void Constructor_SetsIsAuthenticatedFalse()
    {
        // Assert
        Assert.IsFalse(_authenticationProcess.IsAuthenticated);
    }
    
    [TestMethod]
    public void OnLogonChallengeResponse_Error_NotSuccess_InvokesAuthenticationFailed()
    {
        // Arrange
        bool authFailedInvoked = false;
        _authenticationProcess.AuthenticationFailed += (result) => { 
            authFailedInvoked = true;
            Assert.AreEqual(ConnexionResult.LOGON_CHALLENGE_FAILED, result);
        };
        
        var logonChallengeResponse = new LogonChallengeResponse
        {
            Error = AuthResult.FAILURE
        };
        
        // Act
        _authenticationProcess.OnLogonChallengeResponse(logonChallengeResponse);
        
        // Assert
        Assert.IsTrue(authFailedInvoked);
        Assert.IsFalse(_authenticationProcess.IsAuthenticated);
    }
    
    [TestMethod]
    public void OnAuthProofResponse_Error_NotSuccess_InvokesAuthenticationFailed()
    {
        // Arrange
        bool authFailedInvoked = false;
        _authenticationProcess.AuthenticationFailed += (result) => { 
            authFailedInvoked = true;
            Assert.AreEqual(ConnexionResult.AUTH_PROOF_FAILED, result);
        };
        
        var authProofResponse = new AuthProofResponse
        {
            Error = AuthResult.FAILURE
        };
        
        // Act
        _authenticationProcess.OnAuthProofResponse(authProofResponse);
        
        // Assert
        Assert.IsTrue(authFailedInvoked);
        Assert.IsFalse(_authenticationProcess.IsAuthenticated);
    }
    
    [TestMethod]
    public void OnAuthProofResponse_ErrorSuccess_InvalidProof_InvokesAuthenticationFailed()
    {
        // Arrange
        var challenge = new LogonChallengeResponse
        {
            Error = AuthResult.SUCCESS,
            B = new byte[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32 },
            G = new byte[] { 7 },
            N = new byte[] { 
                223, 235, 159, 75, 63, 174, 218, 64, 15, 22, 141, 232, 139, 20, 195, 179,
                173, 2, 56, 62, 99, 96, 37, 64, 194, 190, 0, 132, 134, 147, 47, 5 
            },
            Salt = new byte[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32 },
            Unk3 = new byte[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 }
        };
        _authCredentials.ComputeAuthProof(challenge);
        
        bool authFailedInvoked = false;
        _authenticationProcess.AuthenticationFailed += (result) => { 
            authFailedInvoked = true;
            Assert.AreEqual(ConnexionResult.AUTH_INVALID_PROOF, result);
        };
        
        var authProofResponse = new AuthProofResponse
        {
            Error = AuthResult.SUCCESS,
            M2 = new byte[] { 99, 98, 97, 96, 95, 94, 93, 92, 91, 90, 89, 88, 87, 86, 85, 84, 83, 82, 81, 80 } // Invalid proof
        };
        
        // Act
        _authenticationProcess.OnAuthProofResponse(authProofResponse);
        
        // Assert
        Assert.IsTrue(authFailedInvoked);
        Assert.IsFalse(_authenticationProcess.IsAuthenticated);
    }
    
    [TestMethod]
    public void OnAuthProofResponse_ErrorSuccess_ValidProof_InvokesAuthenticationSucceeded()
    {
        // Arrange - Compute a valid proof first
        var challenge = new LogonChallengeResponse
        {
            Error = AuthResult.SUCCESS,
            B = new byte[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32 },
            G = new byte[] { 7 },
            N = new byte[] { 
                223, 235, 159, 75, 63, 174, 218, 64, 15, 22, 141, 232, 139, 20, 195, 179,
                173, 2, 56, 62, 99, 96, 37, 64, 194, 190, 0, 132, 134, 147, 47, 5 
            },
            Salt = new byte[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32 },
            Unk3 = new byte[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 }
        };
        _authCredentials.ComputeAuthProof(challenge);
        
        bool authSucceededInvoked = false;
        _authenticationProcess.AuthenticationSucceeded += (result) => { 
            authSucceededInvoked = true;
            Assert.AreEqual(ConnexionResult.SUCCESS, result);
        };
        
        var authProofResponse = new AuthProofResponse
        {
            Error = AuthResult.SUCCESS,
            M2 = _authCredentials.Proof // Valid proof
        };
        
        // Act
        _authenticationProcess.OnAuthProofResponse(authProofResponse);
        
        // Assert
        Assert.IsTrue(authSucceededInvoked);
        Assert.IsTrue(_authenticationProcess.IsAuthenticated);
    }
    
    [TestCleanup]
    public void Cleanup()
    {
        _authenticateDone.Dispose();
    }
}
