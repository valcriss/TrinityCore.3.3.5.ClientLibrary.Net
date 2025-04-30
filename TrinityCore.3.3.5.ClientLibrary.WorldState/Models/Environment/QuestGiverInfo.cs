using TrinityCore._3._3._5.ClientLibrary.WorldState.Enums;

namespace TrinityCore._3._3._5.ClientLibrary.WorldState.Models.Environment;

public class QuestGiverInfo
{
    public ulong QuestGiverGuid { get; set; }
    public QuestGiverStatus Status { get; set; }
}