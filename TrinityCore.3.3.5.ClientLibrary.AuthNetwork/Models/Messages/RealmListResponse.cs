using TrinityCore._3._3._5.ClientLibrary.AuthNetwork.Enums;
using TrinityCore._3._3._5.ClientLibrary.AuthNetwork.Models.Results;
using TrinityCore._3._3._5.ClientLibrary.Network.Core.Packets;

namespace TrinityCore._3._3._5.ClientLibrary.AuthNetwork.Models.Messages;

public class RealmListResponse : ParsedPacket<AuthCommands>
{
    public List<Realm> Realms { get; } = new();

    private RealmListResponse(byte[]? data = null) : base(AuthCommands.REALM_LIST, data)
    {
    }

    public static RealmListResponse? Parse(RawPacket<AuthCommands> rawPacket)
    {
        RealmListResponse packet = new(rawPacket.Payload);
        packet.ReadUInt16();
        packet.ReadUInt32();
        ushort count = packet.ReadUInt16();
        for (int i = 0; i < count; ++i)
        {
            byte type = packet.ReadByte();
            byte locked = packet.ReadByte();
            byte flags = packet.ReadByte();
            string name = packet.ReadCString();
            string fullAddress = packet.ReadCString();
            string[] tokens = fullAddress.Split(':');
            string address = tokens[0];
            int port = tokens.Length > 1 ? int.Parse(tokens[1]) : 8085;
            float population = packet.ReadSingle();
            byte load = packet.ReadByte();
            byte timezone = packet.ReadByte();
            byte id = packet.ReadByte();

            byte versionMajor = 0;
            byte versionMinor = 0;
            byte versionBugFix = 0;
            ushort build = 0;

            if ((flags & 4) != 0)
            {
                versionMajor = packet.ReadByte();
                versionMinor = packet.ReadByte();
                versionBugFix = packet.ReadByte();
                build = packet.ReadUInt16();
            }

            packet.Realms.Add(new Realm
            {
                Id = id,
                Type = type,
                Locked = locked,
                Flags = flags,
                Name = name,
                Address = address,
                Port = port,
                Population = population,
                Load = load,
                Timezone = timezone,
                VersionMajor = versionMajor,
                VersionMinor = versionMinor,
                VersionBugFix = versionBugFix,
                Build = build
            });
        }

        return packet;
    }
}