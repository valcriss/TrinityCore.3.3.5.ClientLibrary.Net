﻿using TrinityCore._3._3._5.ClientLibrary.Network.Core.Packets;
using TrinityCore._3._3._5.ClientLibrary.Shared.Enums;
using TrinityCore._3._3._5.ClientLibrary.WorldNetwork.Models.Results;

namespace TrinityCore._3._3._5.ClientLibrary.WorldNetwork.Models.Messages;

public class ServerCharactersListResponse : ParsedPacket<WorldCommands>
{
    public ServerCharactersListResponse(byte[]? data = null) : base(WorldCommands.SMSG_CHAR_ENUM, data)
    {
    }

    public Character[] Characters { get; set; } = [];

    public static ServerCharactersListResponse? Parse(RawPacket<WorldCommands> rawPacket)
    {
        ServerCharactersListResponse packet = new(rawPacket.Payload);
        byte count = packet.ReadByte();
        if (count == 0)
        {
            packet.Characters = [];
        }
        else
        {
            packet.Characters = new Character[count];
            for (byte i = 0; i < count; ++i) packet.Characters[i] = new Character(packet);
        }

        return packet;
    }
}