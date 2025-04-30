using TrinityCore._3._3._5.ClientLibrary.Network.Core.Packets;
using TrinityCore._3._3._5.ClientLibrary.Shared.Enums;
using TrinityCore._3._3._5.ClientLibrary.WorldNetwork.Models.Enums;

namespace TrinityCore._3._3._5.ClientLibrary.WorldNetwork.Models.Messages;

public class ServerCharacterLoginResponse : ParsedPacket<WorldCommands>
{
    public ServerCharacterLoginResponse(byte[]? data = null) : base(WorldCommands.SMSG_LOGIN_VERIFY_WORLD, data)
    {
    }

    public uint MapId { get; set; }
    public float O { get; set; }
    public float X { get; set; }
    public float Y { get; set; }
    public float Z { get; set; }

    public static ServerCharacterLoginResponse Parse(RawPacket<WorldCommands> rawPacket)
    {
        ServerCharacterLoginResponse packet = new(rawPacket.Payload);
        packet.MapId = packet.ReadUInt32();
        packet.X = packet.ReadSingle();
        packet.Y = packet.ReadSingle();
        packet.Z = packet.ReadSingle();
        packet.O = packet.ReadSingle();
        return packet;
    }
}