namespace TrinityCore._3._3._5.ClientLibrary.Network.Core.Packets
{
    /// <summary>
    /// Représente un paquet désérialisé : opcode + champs nommés.
    /// </summary>
    public abstract class ParsedPacket<TCommands> : Packet
    {
        public TCommands Command { get; }
        protected byte[]? Data { get; }

        protected ParsedPacket(TCommands command, byte[]? data = null) : base(data)
        {
            Command = command;
            Data = data;
        }
        
    }
}
