using TrinityCore._3._3._5.ClientLibrary.Network.Core.Packets;
using TrinityCore._3._3._5.ClientLibrary.Shared.Enums;
using TrinityCore._3._3._5.ClientLibrary.WorldState.Models.Environment;

namespace TrinityCore._3._3._5.ClientLibrary.WorldNetwork.Models.Messages.States.Environment;

public class ServerDestroyObject : ParsedPacket<WorldCommands>
{
    public ServerDestroyObject(byte[]? data = null) : base(WorldCommands.SMSG_DESTROY_OBJECT, data)
    {
    }

    public DestroyObject DestroyObject { get; set; } = new();

    public static ServerDestroyObject Parse(RawPacket<WorldCommands> rawPacket)
    {
        ServerDestroyObject packet = new(rawPacket.Payload);
        // Lire le GUID de l'entité à détruire
        packet.DestroyObject.Guid = packet.ReadUInt64();
        packet.DestroyObject.IsDead = packet.ReadBoolean();
        return packet;
    }
}