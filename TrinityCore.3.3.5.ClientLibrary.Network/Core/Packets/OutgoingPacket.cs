namespace TrinityCore._3._3._5.ClientLibrary.Network.Core.Packets;

public class OutgoingPacket<TCommands> : Packet where TCommands : struct, Enum
{
    public OutgoingPacket(TCommands command)
    {
        Command = command;
    }

    public TCommands Command { get; }
}