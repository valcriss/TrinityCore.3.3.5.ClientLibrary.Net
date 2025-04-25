using System.Numerics;
using TrinityCore._3._3._5.ClientLibrary.AuthNetwork.Enums;
using TrinityCore._3._3._5.ClientLibrary.Network.Core.Packets;

namespace TrinityCore._3._3._5.ClientLibrary.AuthNetwork.Models.Messages;

public class LogonChallengeResponse : ParsedPacket<AuthCommands>
{
    public byte[]? B { get; set; }
    public AuthResult Error { get; set; }
    public byte[]? G { get; set; }
    public BigInteger Key { get; set; }
    public byte[]? N { get; set; }
    private byte[]? Proof { get; set; }
    public byte[]? Salt { get; set; }
    public byte[]? Unk3 { get; set; }
    public LogonChallengeResponse(byte[]? data = null) : base(AuthCommands.LOGON_CHALLENGE, data)
    {
    }
    
    public static LogonChallengeResponse? Parse(RawPacket<AuthCommands> rawPacket)
    {
        LogonChallengeResponse packet = new(rawPacket.Payload);
        packet.ReadByte();
        packet.Error = (AuthResult)packet.ReadByte();
        if (packet.Error != AuthResult.SUCCESS)
            return null;

        packet.B = packet.ReadBytes(32);
        packet.ReadByte();
        packet.G = packet.ReadBytes(1);
        packet.ReadByte();
        packet.N = packet.ReadBytes(32);
        packet.Salt = packet.ReadBytes(32);
        packet.Unk3 = packet.ReadBytes(16);
        packet.ReadByte();
        return packet;
    }
}