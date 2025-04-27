namespace TrinityCore._3._3._5.ClientLibrary.WorldState.Enums;

[Flags]
public enum FriendStatus
{
    FRIEND_STATUS_OFFLINE = 0x00,
    FRIEND_STATUS_ONLINE = 0x01,
    FRIEND_STATUS_AFK = 0x02,
    FRIEND_STATUS_DND = 0x04,
    FRIEND_STATUS_RAF = 0x08
}