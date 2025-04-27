using TrinityCore._3._3._5.ClientLibrary.Network.Core.Packets;
using TrinityCore._3._3._5.ClientLibrary.WorldNetwork.Models.Enums;
using TrinityCore._3._3._5.ClientLibrary.WorldState.Models.Player;

namespace TrinityCore._3._3._5.ClientLibrary.WorldNetwork.Models.Messages.States.Player;

public class ServerUpdateWorldState : ParsedPacket<WorldCommands>
{
    public ServerUpdateWorldState(byte[]? data = null) : base(WorldCommands.SMSG_UPDATE_WORLD_STATE, data)
    {
    }

    public WorldStateValue WorldStateValue { get; set; } = new();

    public static ServerUpdateWorldState Parse(RawPacket<WorldCommands> rawPacket)
    {
        ServerUpdateWorldState packet = new(rawPacket.Payload);
        int key = packet.ReadInt32();
        int value = packet.ReadInt32();
        packet.WorldStateValue.Id = key;
        packet.WorldStateValue.Value = value;
        return packet;
    }
}