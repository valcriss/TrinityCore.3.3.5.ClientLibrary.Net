using TrinityCore._3._3._5.ClientLibrary.Network.Core.Packets;
using TrinityCore._3._3._5.ClientLibrary.Shared.Enums;
using TrinityCore._3._3._5.ClientLibrary.WorldNetwork.Models.Enums;
using TrinityCore._3._3._5.ClientLibrary.WorldState.Models.Server;

namespace TrinityCore._3._3._5.ClientLibrary.WorldNetwork.Models.Messages.States.Server;

public class ServerFeatureSystemStatusInfo : ParsedPacket<WorldCommands>
{
    private ServerFeatureSystemStatusInfo(byte[]? data = null) : base(WorldCommands.SMSG_FEATURE_SYSTEM_STATUS, data)
    {
    }

    public FeatureSystemStatus FeatureSystemStatus { get; set; } = new();

    public static ServerFeatureSystemStatusInfo Parse(RawPacket<WorldCommands> rawPacket)
    {
        ServerFeatureSystemStatusInfo packet = new(rawPacket.Payload);
        packet.ReadSByte();
        packet.FeatureSystemStatus.VoiceChatEnabled = packet.ReadSByte() != 0;
        return packet;
    }
}