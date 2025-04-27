using TrinityCore._3._3._5.ClientLibrary.Network.Core.Packets;
using TrinityCore._3._3._5.ClientLibrary.WorldNetwork.Models.Enums;
using TrinityCore._3._3._5.ClientLibrary.WorldState.Models.Server;

namespace TrinityCore._3._3._5.ClientLibrary.WorldNetwork.Models.Messages.States.Server;

public class ClientCacheVersionInfo : ParsedPacket<WorldCommands>
{
    private ClientCacheVersionInfo(byte[]? data = null) : base(WorldCommands.SMSG_CLIENTCACHE_VERSION, data)
    {
    }

    public CacheVersion CacheVersion { get; set; } = new();

    public static ClientCacheVersionInfo Parse(RawPacket<WorldCommands> rawPacket)
    {
        ClientCacheVersionInfo packet = new(rawPacket.Payload);
        packet.CacheVersion.Version = packet.ReadUInt32();
        return packet;
    }
}