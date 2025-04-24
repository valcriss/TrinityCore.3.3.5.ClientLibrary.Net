using System.Numerics;
using TrinityCore._3._3._5.ClientLibrary.AuthNetwork.Enums;
using TrinityCore._3._3._5.ClientLibrary.AuthNetwork.Models.Messages;
using TrinityCore._3._3._5.ClientLibrary.AuthNetwork.Models.Security;

namespace TrinityCore._3._3._5.ClientLibrary.AuthNetworkTest;

[TestClass]
public class AuthCredentialsTests
{
    private AuthCredentials _authCredentials = null!;
    private const string Username = "TESTUSER";
    private const string Password = "password";

    [TestInitialize]
    public void Initialize()
    {
        _authCredentials = new AuthCredentials(Username, Password);
    }

    [TestMethod]
    public void Constructor_InitializesCorrectly()
    {
        // Assert
        Assert.AreEqual(Username, _authCredentials.Username);
        Assert.AreEqual(Password, _authCredentials.Password);
        Assert.AreEqual(BigInteger.Zero, _authCredentials.SessionKey);
        Assert.AreEqual(20, _authCredentials.M1Hash.Length);
        Assert.AreEqual(20, _authCredentials.Proof.Length);
        Assert.AreEqual(32, _authCredentials.Y.Length);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void ComputeAuthProof_NullChallenge_ThrowsArgumentNullException()
    {
        // Act
        _authCredentials.ComputeAuthProof(null!);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void ComputeAuthProof_IncompleteChallenge_ThrowsArgumentNullException()
    {
        // Arrange
        var challenge = new LogonChallengeResponse
        {
            Error = AuthResult.SUCCESS,
            B = null,
            G = new byte[1],
            N = new byte[1],
            Salt = new byte[1],
            Unk3 = new byte[1]
        };

        // Act
        _authCredentials.ComputeAuthProof(challenge);
    }

    [TestMethod]
    public void ComputeAuthProof_ValidChallenge_ComputesProof()
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

        // Act
        _authCredentials.ComputeAuthProof(challenge);

        // Assert
        Assert.AreNotEqual(BigInteger.Zero, _authCredentials.SessionKey);
        Assert.IsFalse(_authCredentials.Y.All(b => b == 0));
        Assert.IsFalse(_authCredentials.M1Hash.All(b => b == 0));
        Assert.IsFalse(_authCredentials.Proof.All(b => b == 0));
    }

    [TestMethod]
    public void IsProofValid_NullProof_ReturnsFalse()
    {
        // Act
        bool result = _authCredentials.IsProofValid(null);

        // Assert
        Assert.IsFalse(result);
    }

    [TestMethod]
    public void IsProofValid_DifferentLengthProof_ReturnsFalse()
    {
        // Arrange
        byte[] receivedProof = new byte[19]; // Different length than the expected 20 bytes

        // Act
        bool result = _authCredentials.IsProofValid(receivedProof);

        // Assert
        Assert.IsFalse(result);
    }

    [TestMethod]
    public void IsProofValid_SameProof_ReturnsTrue()
    {
        // Arrange
        // First, compute a valid proof
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
        
        // Capture the computed proof
        byte[] computedProof = _authCredentials.Proof;
        
        // Act
        bool result = _authCredentials.IsProofValid(computedProof);
        
        // Assert
        Assert.IsTrue(result);
    }
    
    [TestMethod]
    public void IsProofValid_DifferentProof_ReturnsFalse()
    {
        // Arrange
        // First, compute a valid proof
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
        
        // Create a different proof
        byte[] differentProof = new byte[20];
        new Random().NextBytes(differentProof);
        
        // Act
        bool result = _authCredentials.IsProofValid(differentProof);
        
        // Assert
        Assert.IsFalse(result);
    }
}