using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrinityCore._3._3._5.ClientLibrary.Network.Core.Packets;
using TrinityCore._3._3._5.ClientLibrary.Shared.Enums;
using TrinityCore._3._3._5.ClientLibrary.WorldNetwork.Models.Enums;
using TrinityCore._3._3._5.ClientLibrary.WorldNetwork.Models.Results;
using TrinityCore._3._3._5.ClientLibrary.WorldState.Models.Environment;

namespace TrinityCore._3._3._5.ClientLibrary.WorldNetwork.Models.Messages.States.Environment
{
    public class ServerMoveSetFacing : ParsedPacket<WorldCommands>
    {
        public MovementUpdate MovementUpdate { get; set; } = new();
        public ServerMoveSetFacing(byte[]? data = null) : base(WorldCommands.MSG_MOVE_SET_FACING, data)
        {
        }

        public static ServerMoveSetFacing Parse(RawPacket<WorldCommands> rawPacket)
        {
            ServerMoveSetFacing packet = new(rawPacket.Payload);
            packet.MovementUpdate = MovementUpdate.Parse(packet);
            return packet;
        }
    }
}
