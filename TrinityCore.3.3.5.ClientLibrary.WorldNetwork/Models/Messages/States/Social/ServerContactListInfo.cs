using TrinityCore._3._3._5.ClientLibrary.Network.Core.Packets;
using TrinityCore._3._3._5.ClientLibrary.WorldNetwork.Models.Enums;
using TrinityCore._3._3._5.ClientLibrary.WorldState.Enums;
using TrinityCore._3._3._5.ClientLibrary.WorldState.Models.Social;

namespace TrinityCore._3._3._5.ClientLibrary.WorldNetwork.Models.Messages.States.Social;

public class ServerContactListInfo : ParsedPacket<WorldCommands>
{
    private ServerContactListInfo(byte[]? data = null) : base(WorldCommands.SMSG_CONTACT_LIST, data)
    {
    }

    public Contacts Contacts { get; set; } = new();

    public static ServerContactListInfo Parse(RawPacket<WorldCommands> rawPacket)
    {
        ServerContactListInfo packet = new(rawPacket.Payload);
        packet.ReadUInt32();
        uint count = packet.ReadUInt32();
        for (int i = 0; i < count; i++)
        {
            ulong guid = packet.ReadUInt64();
            ContactType type = (ContactType)packet.ReadUInt32();
            string note = packet.ReadCString();

            if (type == ContactType.FRIEND)
            {
                uint? areaId = null;
                uint? level = null;
                Class? @class = null;
                FriendStatus status = (FriendStatus)packet.ReadByte();
                if ((status & FriendStatus.FRIEND_STATUS_ONLINE) == FriendStatus.FRIEND_STATUS_ONLINE)
                {
                    areaId = packet.ReadUInt32();
                    level = packet.ReadUInt32();
                    @class = (Class)packet.ReadUInt32();
                }

                packet.Contacts.Friends.Add(new Friend { Guid = guid, Note = note, Status = status, AreaId = areaId, Level = level, Class = @class });
            }
            else if (type == ContactType.IGNORED)
            {
                packet.Contacts.Ignored.Add(new Contact { Guid = guid, Note = note });
            }
            else if (type == ContactType.MUTED)
            {
                packet.Contacts.Muted.Add(new Contact { Guid = guid, Note = note });
            }
        }

        return packet;
    }
}