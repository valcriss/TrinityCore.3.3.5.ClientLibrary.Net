using TrinityCore._3._3._5.ClientLibrary.Network.Core.Packets;
using TrinityCore._3._3._5.ClientLibrary.Shared.Enums;

namespace TrinityCore._3._3._5.ClientLibrary.AuthNetwork.Models.Messages;

public class RealmListRequest: OutgoingPacket<AuthCommands>
{
    public RealmListRequest() : base(AuthCommands.REALM_LIST)
    {
        Append(0);
        Append(0);
        Append(0);
        Append(0);
    }
}