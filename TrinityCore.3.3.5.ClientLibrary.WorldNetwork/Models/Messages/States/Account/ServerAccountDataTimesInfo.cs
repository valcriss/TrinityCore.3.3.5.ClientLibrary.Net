using TrinityCore._3._3._5.ClientLibrary.Network.Core.Packets;
using TrinityCore._3._3._5.ClientLibrary.Shared.Enums;
using TrinityCore._3._3._5.ClientLibrary.WorldNetwork.Models.Enums;
using TrinityCore._3._3._5.ClientLibrary.WorldState.Enums;
using TrinityCore._3._3._5.ClientLibrary.WorldState.Models.Account;

namespace TrinityCore._3._3._5.ClientLibrary.WorldNetwork.Models.Messages.States.Account;

public class ServerAccountDataTimesInfo : ParsedPacket<WorldCommands>
{
    public ServerAccountDataTimesInfo(byte[]? data = null) : base(WorldCommands.SMSG_ACCOUNT_DATA_TIMES, data)
    {
    }

    public AccountDataTimes AccountDataTimes { get; set; } = new();

    public static ServerAccountDataTimesInfo Parse(RawPacket<WorldCommands> rawPacket)
    {
        ServerAccountDataTimesInfo packet = new(rawPacket.Payload);
        packet.AccountDataTimes.ServerTime = packet.ReadUInt32();
        packet.ReadSByte();
        packet.ReadUInt32();
        int index = 0;
        while (packet.Data?.Length - packet.ReadIndex >= 4)
        {
            packet.AccountDataTimes.Values.Add((AccountDataTimesTypes)index, packet.ReadUInt32());
            index++;
        }

        return packet;
    }
}