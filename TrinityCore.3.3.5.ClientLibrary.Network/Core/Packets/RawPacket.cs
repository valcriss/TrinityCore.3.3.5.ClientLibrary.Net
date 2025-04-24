namespace TrinityCore._3._3._5.ClientLibrary.Network.Core.Packets
{
    /// <summary>
    /// Représente une trame brute extraite du flux TCP :
    /// - Opcode : identifiant du paquet
    /// - Payload : données spécifiques au paquet
    /// </summary>
    public class RawPacket<TCommands> where TCommands : struct, Enum
    {
        public TCommands Opcode { get; }
        public byte[] Payload { get; }

        public RawPacket(TCommands opcode, byte[] payload)
        {
            Opcode = opcode;
            Payload = payload;
        }
    }
}
