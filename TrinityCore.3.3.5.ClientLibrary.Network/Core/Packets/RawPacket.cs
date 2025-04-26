namespace TrinityCore._3._3._5.ClientLibrary.Network.Core.Packets;

/// <summary>
///     Représente une trame brute extraite du flux TCP :
///     - Opcode : identifiant du paquet
///     - Payload : données spécifiques au paquet
/// </summary>
public class RawPacket<TCommands> where TCommands : struct, Enum
{
    public RawPacket(TCommands opcode, byte[] payload)
    {
        Opcode = opcode;
        Payload = payload;
    }

    public TCommands Opcode { get; set; }
    public byte[] Payload { get; set; }
}