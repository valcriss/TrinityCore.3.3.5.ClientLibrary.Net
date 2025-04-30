using System.Numerics;
using System.Security.Cryptography;
using System.Text;
using TrinityCore._3._3._5.ClientLibrary.Network.Core.Packets;
using TrinityCore._3._3._5.ClientLibrary.Network.Core.Tools;
using TrinityCore._3._3._5.ClientLibrary.Shared.Enums;
using TrinityCore._3._3._5.ClientLibrary.Shared.Security;
using TrinityCore._3._3._5.ClientLibrary.WorldNetwork.Models.Enums;
using HashAlgorithm = TrinityCore._3._3._5.ClientLibrary.Shared.Security.HashAlgorithm;

namespace TrinityCore._3._3._5.ClientLibrary.WorldNetwork.Models.Messages;

public class ServerAuthChallengeResponse : OutgoingPacket<WorldCommands>
{
    public ServerAuthChallengeResponse(uint realmId, string username, byte[] sessionKey, uint serverSeed) : base(WorldCommands.CLIENT_AUTH_SESSION)
    {
        RandomNumberGenerator rand = RandomNumberGenerator.Create();
        byte[] bytes = new byte[4];
        rand.GetBytes(bytes);
        BigInteger ourSeed = bytes.ToBigInteger();

        uint zero = 0;

        byte[] authResponse = HashAlgorithm.SHA1.Hash
        (
            Encoding.ASCII.GetBytes(username),
            BitConverter.GetBytes(zero),
            BitConverter.GetBytes((uint)ourSeed),
            BitConverter.GetBytes(serverSeed),
            sessionKey
        );

        Append((uint)12340); // client build
        Append(zero);
        Append(username.ToCString());
        Append(zero);
        Append((uint)ourSeed);
        Append(zero);
        Append(zero);
        Append(realmId);
        Append((ulong)zero);
        Append(authResponse);
        Append(zero);
    }
}