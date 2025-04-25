using System.Net;
using TrinityCore._3._3._5.ClientLibrary.AuthNetwork.Enums;
using TrinityCore._3._3._5.ClientLibrary.Network.Core.Packets;
using TrinityCore._3._3._5.ClientLibrary.Network.Core.Tools;

namespace TrinityCore._3._3._5.ClientLibrary.AuthNetwork.Models.Messages;

public class AuthLogonChallenge : OutgoingPacket<AuthCommands>
{
    public AuthLogonChallenge(string username, IPAddress ipAddress): base(AuthCommands.LOGON_CHALLENGE)
    {
        Append(6);
        Append((ushort)(username.Length + 30));
        Append("WoW".ToCString());
        Append([3, 3, 5]);
        Append(12340);
        Append("68x".ToCString());
        Append("toB".ToCString());
        Append("SUne".GetAsciiBytes());
        Append((uint)0x3c);
        Append(BitConverter.ToUInt32(ipAddress.GetAddressBytes(), 0));
        Append((byte)username.Length);
        Append(username.GetAsciiBytes());
    }
}