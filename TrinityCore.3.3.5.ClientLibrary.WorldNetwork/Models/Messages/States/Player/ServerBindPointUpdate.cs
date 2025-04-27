using TrinityCore._3._3._5.ClientLibrary.Network.Core.Packets;
using TrinityCore._3._3._5.ClientLibrary.Network.Core.Tools;
using TrinityCore._3._3._5.ClientLibrary.Shared.Math;
using TrinityCore._3._3._5.ClientLibrary.WorldNetwork.Models.Enums;
using TrinityCore._3._3._5.ClientLibrary.WorldState.Models.Player;

namespace TrinityCore._3._3._5.ClientLibrary.WorldNetwork.Models.Messages.States.Player;

public class ServerBindPointUpdate: ParsedPacket<WorldCommands>
{
    public WorldPoint BindPoint { get; set; } = new();
    
    private ServerBindPointUpdate(byte[]? data = null) : base(WorldCommands.SMSG_BINDPOINTUPDATE, data)
    {
    }

    public static ServerBindPointUpdate Parse(RawPacket<WorldCommands> rawPacket)
    {
        ServerBindPointUpdate packet = new(rawPacket.Payload);
        Coord position = packet.ReadCoord();
        uint mapId = packet.ReadUInt32();
        uint areaId = packet.ReadUInt32();
        packet.BindPoint = new WorldPoint() { AreaId = areaId, MapId = mapId, Position = position };
        return packet;
    }
}