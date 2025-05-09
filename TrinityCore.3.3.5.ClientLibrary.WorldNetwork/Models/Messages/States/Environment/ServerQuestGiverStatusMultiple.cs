using TrinityCore._3._3._5.ClientLibrary.Network.Core.Packets;
using TrinityCore._3._3._5.ClientLibrary.Shared.Enums;
using TrinityCore._3._3._5.ClientLibrary.WorldState.Enums;
using TrinityCore._3._3._5.ClientLibrary.WorldState.Models.Environment;

namespace TrinityCore._3._3._5.ClientLibrary.WorldNetwork.Models.Messages.States.Environment;

public class ServerQuestGiverStatusMultiple : ParsedPacket<WorldCommands>
{
    public ServerQuestGiverStatusMultiple(byte[]? data = null) : base(WorldCommands.SMSG_QUESTGIVER_STATUS_MULTIPLE, data)
    {
    }

    public QuestGiverInfoMultiple QuestGiverInfoMultiple { get; set; } = new();

    public static ServerQuestGiverStatusMultiple Parse(RawPacket<WorldCommands> rawPacket)
    {
        ServerQuestGiverStatusMultiple packet = new(rawPacket.Payload);
        uint count = packet.ReadUInt32();

        for (uint i = 0; i < count; i++)
        {
            ulong guid = packet.ReadUInt64();
            QuestGiverStatus status = (QuestGiverStatus)packet.ReadSByte();
            packet.QuestGiverInfoMultiple.Infos.Add(new QuestGiverInfo { QuestGiverGuid = guid, Status = status });
        }

        return packet;
    }
}