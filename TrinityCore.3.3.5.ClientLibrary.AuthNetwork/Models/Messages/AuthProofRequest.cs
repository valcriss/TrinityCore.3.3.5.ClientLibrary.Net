using TrinityCore._3._3._5.ClientLibrary.AuthNetwork.Enums;
using TrinityCore._3._3._5.ClientLibrary.Network.Core.Packets;

namespace TrinityCore._3._3._5.ClientLibrary.AuthNetwork.Models.Messages;

public class AuthProofRequest : OutgoingPacket<AuthCommands>
{
    public AuthProofRequest(byte[] a, byte[] m1, byte[] crc) : base(AuthCommands.LOGON_PROOF)
    {
        Append(a);
        Append(m1);
        Append(crc);
        Append(0);
        Append(0);
    }
}