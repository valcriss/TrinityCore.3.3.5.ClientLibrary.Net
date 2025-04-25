using TrinityCore._3._3._5.ClientLibrary.Network.Core.Packets;
using TrinityCore._3._3._5.ClientLibrary.WorldNetwork.Models.Enums;

namespace TrinityCore._3._3._5.ClientLibrary.WorldNetwork.Models.Messages;

public class ServerAuthChallengeRequest: ParsedPacket<WorldCommands>
{
    public uint ServerSeed { get; set; }
    
    public ServerAuthChallengeRequest(byte[]? data = null) : base(WorldCommands.SERVER_AUTH_CHALLENGE, data)
    {
    }
    
    public static ServerAuthChallengeRequest? Parse(RawPacket<WorldCommands> rawPacket)
    {
        ServerAuthChallengeRequest packet = new(rawPacket.Payload);
        packet.ReadUInt32();
        packet.ServerSeed = packet.ReadUInt32();
        packet.ReadBytes(16);
        packet.ReadBytes(16);
        return packet;
    }
}