using TrinityCore._3._3._5.ClientLibrary.Network.Core.Packets;
using TrinityCore._3._3._5.ClientLibrary.Shared.Enums;
using TrinityCore._3._3._5.ClientLibrary.WorldNetwork.Models.Enums;

namespace TrinityCore._3._3._5.ClientLibrary.WorldNetwork.Models.Messages.States.Player;

public class ServerInitWorldStates : ParsedPacket<WorldCommands>
{
    public ServerInitWorldStates(byte[]? data = null) : base(WorldCommands.SMSG_INIT_WORLD_STATES, data)
    {
    }

    public WorldState.Models.Player.WorldState WorldState { get; set; } = new();

    public static ServerInitWorldStates Parse(RawPacket<WorldCommands> rawPacket)
    {
        ServerInitWorldStates packet = new(rawPacket.Payload);
        packet.WorldState.MapId = packet.ReadInt32();
        packet.WorldState.ZoneId = packet.ReadInt32();
        packet.WorldState.AreaId = packet.ReadInt32();
        ushort count = packet.ReadUInt16();
        for (int i = 0; i < count; i++)
        {
            int key = packet.ReadInt32();
            int value = packet.ReadInt32();
            packet.WorldState.Variables.Add(key, value);
        }

        return packet;
    }
}