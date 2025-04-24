using TrinityCore._3._3._5.ClientLibrary.AuthNetwork.Enums;
using TrinityCore._3._3._5.ClientLibrary.Network.Core.Packets;
using TrinityCore._3._3._5.ClientLibrary.Shared.Enums;

namespace TrinityCore._3._3._5.ClientLibrary.AuthNetwork.Models.Messages;

public class AuthProofResponse : ParsedPacket<AuthCommands>
{
    public AuthResult Error { get; set; }
    public byte[]? M2 { get; set; }

    public AuthProofResponse(byte[]? data = null) : base(AuthCommands.LOGON_PROOF, data)
    {
    }

    public static AuthProofResponse? Parse(RawPacket<AuthCommands> rawPacket)
    {
        AuthProofResponse packet = new(rawPacket.Payload);
        packet.Error = (AuthResult)packet.ReadByte();
        if (packet.Error != AuthResult.SUCCESS)
            return null;

        packet.M2 = packet.ReadBytes(20);
        packet.ReadUInt32();
        packet.ReadUInt32();
        packet.ReadUInt16();
        return packet;
    }
}