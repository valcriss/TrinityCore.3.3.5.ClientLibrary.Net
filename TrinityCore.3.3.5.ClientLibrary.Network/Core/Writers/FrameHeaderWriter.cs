using TrinityCore._3._3._5.ClientLibrary.Network.Core.Packets;

namespace TrinityCore._3._3._5.ClientLibrary.Network.Core.Writers;

public abstract class FrameHeaderWriter<TCommands> where TCommands : struct, Enum
{
    public abstract byte[]? Create(OutgoingPacket<TCommands> packet);
}