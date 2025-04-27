using TrinityCore._3._3._5.ClientLibrary.Network.Core.Packets;
using TrinityCore._3._3._5.ClientLibrary.WorldNetwork.Models.Enums;
using TrinityCore._3._3._5.ClientLibrary.WorldState.Enums;
using TrinityCore._3._3._5.ClientLibrary.WorldState.Models.Player;

namespace TrinityCore._3._3._5.ClientLibrary.WorldNetwork.Models.Messages.States.Player;

public class ServerDungeonDifficultyInfo : ParsedPacket<WorldCommands>
{
    private ServerDungeonDifficultyInfo(byte[]? data = null) : base(WorldCommands.MSG_SET_DUNGEON_DIFFICULTY, data)
    {
    }

    public DungeonDifficulty DungeonDifficulty { get; set; } = new();

    public static ServerDungeonDifficultyInfo Parse(RawPacket<WorldCommands> rawPacket)
    {
        ServerDungeonDifficultyInfo packet = new(rawPacket.Payload);
        packet.DungeonDifficulty.Difficulty = (Difficulty)packet.ReadUInt32();
        packet.ReadUInt32();
        packet.DungeonDifficulty.IsInGroup = packet.ReadUInt32() != 0;
        return packet;
    }
}