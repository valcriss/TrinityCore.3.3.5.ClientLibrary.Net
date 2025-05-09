using TrinityCore._3._3._5.ClientLibrary.Network.Core.Packets;
using TrinityCore._3._3._5.ClientLibrary.Shared.Enums;
using TrinityCore._3._3._5.ClientLibrary.WorldState.Models.Player;

namespace TrinityCore._3._3._5.ClientLibrary.WorldNetwork.Models.Messages.States.Player;

public class ServerForcedReactions : ParsedPacket<WorldCommands>
{
    private ServerForcedReactions(byte[]? data = null) : base(WorldCommands.SMSG_SET_FORCED_REACTIONS, data)
    {
    }

    public FactionsOverrides Overrides { get; set; } = new();

    public static ServerForcedReactions Parse(RawPacket<WorldCommands> rawPacket)
    {
        ServerForcedReactions packet = new(rawPacket.Payload);
        uint count = packet.ReadUInt32();
        for (int i = 0; i < count; i++)
        {
            uint factionId = packet.ReadUInt32();
            uint reputation = packet.ReadUInt32();
            packet.Overrides.Reputations.Add(new Faction { FactionId = factionId, Reputation = reputation });
        }

        return packet;
    }
}