using TrinityCore._3._3._5.ClientLibrary.Network.Core.Packets;
using TrinityCore._3._3._5.ClientLibrary.Network.Core.Writers;
using TrinityCore._3._3._5.ClientLibrary.Shared.Enums;

namespace TrinityCore._3._3._5.ClientLibrary.AuthNetwork.Models.Network;

public class AuthFrameHeaderWriter : FrameHeaderWriter<AuthCommands>
{
    public override byte[]? Create(OutgoingPacket<AuthCommands> packet)
    {
        return [(byte)packet.Command];
    }
}