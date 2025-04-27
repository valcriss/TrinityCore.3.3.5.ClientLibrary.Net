using TrinityCore._3._3._5.ClientLibrary.Network.Core.Packets;
using TrinityCore._3._3._5.ClientLibrary.WorldNetwork.Models.Enums;
using TrinityCore._3._3._5.ClientLibrary.WorldState.Enums;
using TrinityCore._3._3._5.ClientLibrary.WorldState.Models.Player;

namespace TrinityCore._3._3._5.ClientLibrary.WorldNetwork.Models.Messages.States.Player;

public class ServerInstanceDifficultyInfo : ParsedPacket<WorldCommands>
{
    public ServerInstanceDifficultyInfo(byte[]? data = null) : base(WorldCommands.SMSG_INSTANCE_DIFFICULTY, data)
    {
    }

    public InstanceDifficulty InstanceDifficulty { get; set; } = new();

    public static ServerInstanceDifficultyInfo Parse(RawPacket<WorldCommands> rawPacket)
    {
        ServerInstanceDifficultyInfo packet = new(rawPacket.Payload);
        packet.InstanceDifficulty.Difficulty = (Difficulty)packet.ReadUInt32();
        packet.InstanceDifficulty.RaidDynamicDifficulty = (Difficulty)packet.ReadUInt32();
        return packet;
    }
}