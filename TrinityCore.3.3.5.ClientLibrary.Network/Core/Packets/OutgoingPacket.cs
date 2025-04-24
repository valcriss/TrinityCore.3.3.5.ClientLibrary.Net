namespace TrinityCore._3._3._5.ClientLibrary.Network.Core.Packets
{
    public class OutgoingPacket<TCommands> : Packet where TCommands : struct, Enum
    {
        public TCommands Command { get; }

        public OutgoingPacket(TCommands command)
        {
            Command = command;
        }
    }
}
