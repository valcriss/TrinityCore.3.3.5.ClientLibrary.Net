using TrinityCore._3._3._5.ClientLibrary.Network.Core.Packets;
using TrinityCore._3._3._5.ClientLibrary.Shared.Enums;
using TrinityCore._3._3._5.ClientLibrary.WorldNetwork.Models.Enums;

namespace TrinityCore._3._3._5.ClientLibrary.WorldNetwork.Models.Messages;

public class ServerAuthChallengeResult : ParsedPacket<WorldCommands>
{
    public ServerAuthChallengeResult(byte[]? data = null) : base(WorldCommands.SERVER_AUTH_RESPONSE, data)
    {
    }

    public bool Success { get; set; }

    public static ServerAuthChallengeResult? Parse(RawPacket<WorldCommands> rawPacket)
    {
        ServerAuthChallengeResult packet = new(rawPacket.Payload);
        CommandDetail detail = (CommandDetail)packet.ReadByte();

        packet.ReadUInt32();
        packet.ReadByte();
        packet.ReadUInt32();
        packet.ReadByte();

        packet.Success = detail == CommandDetail.AUTH_OK;
        return packet;
    }
}