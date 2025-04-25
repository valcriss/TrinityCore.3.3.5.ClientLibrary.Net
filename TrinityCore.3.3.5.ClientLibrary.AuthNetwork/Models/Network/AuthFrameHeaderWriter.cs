using TrinityCore._3._3._5.ClientLibrary.AuthNetwork.Enums;
using TrinityCore._3._3._5.ClientLibrary.Network.Core.Packets;
using TrinityCore._3._3._5.ClientLibrary.Network.Core.Writers;

namespace TrinityCore._3._3._5.ClientLibrary.AuthNetwork.Models.Network;

public class AuthFrameHeaderWriter : FrameHeaderWriter<AuthCommands>
{
    public override byte[]? Create(OutgoingPacket<AuthCommands> packet)
    {
        return [(byte)packet.Command];
    }
}