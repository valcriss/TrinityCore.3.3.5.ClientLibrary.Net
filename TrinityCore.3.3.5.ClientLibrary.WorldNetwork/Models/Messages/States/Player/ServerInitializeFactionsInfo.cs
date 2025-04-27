using TrinityCore._3._3._5.ClientLibrary.Network.Core.Packets;
using TrinityCore._3._3._5.ClientLibrary.WorldNetwork.Models.Enums;
using TrinityCore._3._3._5.ClientLibrary.WorldState.Enums;
using TrinityCore._3._3._5.ClientLibrary.WorldState.Models.Player;

namespace TrinityCore._3._3._5.ClientLibrary.WorldNetwork.Models.Messages.States.Player;

public class ServerInitializeFactionsInfo : ParsedPacket<WorldCommands>
{
    public ServerInitializeFactionsInfo(byte[]? data = null) : base(WorldCommands.SMSG_INITIALIZE_FACTIONS, data)
    {
    }

    public Factions Factions { get; set; } = new();

    public static ServerInitializeFactionsInfo Parse(RawPacket<WorldCommands> rawPacket)
    {
        ServerInitializeFactionsInfo packet = new(rawPacket.Payload);
        uint count = packet.ReadUInt32();
        for (uint i = 0; i < count; i++)
        {
            FactionOptions flags = (FactionOptions)packet.ReadSByte();
            uint standing = packet.ReadUInt32();
            packet.Factions.Reputations.Add(new Reputation { Id = i, Flags = flags, Standing = standing });
        }

        return packet;
    }
}