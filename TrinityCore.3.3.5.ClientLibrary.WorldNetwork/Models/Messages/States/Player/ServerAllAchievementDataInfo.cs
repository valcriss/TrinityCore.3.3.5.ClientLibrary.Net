using TrinityCore._3._3._5.ClientLibrary.Network.Core.Packets;
using TrinityCore._3._3._5.ClientLibrary.WorldNetwork.Models.Enums;
using TrinityCore._3._3._5.ClientLibrary.WorldState.Models.Account;

namespace TrinityCore._3._3._5.ClientLibrary.WorldNetwork.Models.Messages.States.Player;

public class ServerAllAchievementDataInfo : ParsedPacket<WorldCommands>
{
    public ServerAllAchievementDataInfo(byte[]? data = null) : base(WorldCommands.SMSG_ALL_ACHIEVEMENT_DATA, data)
    {
    }

    public Achievements Achievements { get; set; } = new();

    public static ServerAllAchievementDataInfo Parse(RawPacket<WorldCommands> rawPacket)
    {
        ServerAllAchievementDataInfo packet = new(rawPacket.Payload);

        uint achievementId = packet.ReadUInt32();
        while (achievementId != 0xFFFFFFFF)
        {
            DateTime time = packet.ReadPackedTime();

            packet.Achievements.CompletedAchievements.Add(new CompletedAchievement
            {
                AchievementId = achievementId,
                Date = time
            });
            achievementId = packet.ReadUInt32();
        }

        uint criteriaId = packet.ReadUInt32();
        while (criteriaId != 0xFFFFFFFF)
        {
            ulong criteriaCounter = packet.ReadPackedGuid();
            packet.ReadPackedGuid(); // PlayerGuid
            packet.ReadInt32(); // 0
            DateTime time = packet.ReadPackedTime();
            packet.ReadInt32(); // 0
            packet.ReadInt32(); // 0

            packet.Achievements.AchievementCriteria.Add(new AchievementCriteria
            {
                CriteriaId = criteriaId,
                Counter = criteriaCounter,
                Date = time
            });
            criteriaId = packet.ReadUInt32();
        }

        return packet;
    }
}