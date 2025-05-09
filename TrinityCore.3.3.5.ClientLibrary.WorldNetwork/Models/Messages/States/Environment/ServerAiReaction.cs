using TrinityCore._3._3._5.ClientLibrary.Network.Core.Packets;
using TrinityCore._3._3._5.ClientLibrary.Shared.Enums;
using TrinityCore._3._3._5.ClientLibrary.WorldState.Enums;

namespace TrinityCore._3._3._5.ClientLibrary.WorldNetwork.Models.Messages.States.Environment;

public class ServerAiReaction : ParsedPacket<WorldCommands>
{
    private ServerAiReaction(byte[]? data = null) : base(WorldCommands.SMSG_AI_REACTION, data)
    {
    }

    public AiReaction AiReaction { get; set; } = new();

    public static ServerAiReaction Parse(RawPacket<WorldCommands> rawPacket)
    {
        ServerAiReaction packet = new(rawPacket.Payload);
        packet.AiReaction.Guid = packet.ReadUInt64();
        packet.AiReaction.Reaction = (AiReactionType)packet.ReadUInt32();
        return packet;
    }
}