using TrinityCore._3._3._5.ClientLibrary.Network.Core.Packets;
using TrinityCore._3._3._5.ClientLibrary.Shared.Enums;
using TrinityCore._3._3._5.ClientLibrary.WorldState.Enums;

namespace TrinityCore._3._3._5.ClientLibrary.WorldState.Models.Environment;

public class MovementUpdate
{
    public ulong Guid { get; set; }
    public MovementLiving MovementLiving { get; set; } = new();

    public static MovementUpdate Parse(ParsedPacket<WorldCommands> parsedPacket)
    {
        MovementUpdate movementUpdate = new();
        movementUpdate.Guid = parsedPacket.ReadPackedGuid();
        movementUpdate.MovementLiving.MovementFlags = (MovementTypes)parsedPacket.ReadUInt32();
        movementUpdate.MovementLiving.ExtraMovementFlags = (MovementOptions)parsedPacket.ReadUInt16();
        movementUpdate.MovementLiving.Time = parsedPacket.ReadUInt32();
        movementUpdate.MovementLiving.Position = new Position(parsedPacket.ReadCoord(), parsedPacket.ReadSingle());

        if (movementUpdate.MovementLiving.MovementFlags.HasFlag(MovementTypes.ONTRANSPORT))
        {
            movementUpdate.MovementLiving.TransportGuid = parsedPacket.ReadPackedGuid();
            movementUpdate.MovementLiving.TransportPosition = new Position(parsedPacket.ReadCoord(), parsedPacket.ReadSingle());

            movementUpdate.MovementLiving.TransportTime = parsedPacket.ReadUInt32();
            movementUpdate.MovementLiving.TransportSeat = parsedPacket.ReadByte();
            if (movementUpdate.MovementLiving.ExtraMovementFlags.HasFlag(MovementOptions.INTERPOLATED_MOVEMENT))
                movementUpdate.MovementLiving.TransportTime2 = parsedPacket.ReadUInt32();
        }

        if (movementUpdate.MovementLiving.MovementFlags.HasFlag(MovementTypes.SWIMMING) || movementUpdate.MovementLiving.MovementFlags.HasFlag(MovementTypes.FLYING)
                                                                                        || movementUpdate.MovementLiving.ExtraMovementFlags.HasFlag(MovementOptions
                                                                                            .ALWAYS_ALLOW_PITCHING))
            movementUpdate.MovementLiving.Pitch = parsedPacket.ReadSingle();

        movementUpdate.MovementLiving.FallTime = parsedPacket.ReadUInt32();

        if (movementUpdate.MovementLiving.MovementFlags.HasFlag(MovementTypes.FALLING))
        {
            movementUpdate.MovementLiving.JumpZSpeed = parsedPacket.ReadSingle();
            movementUpdate.MovementLiving.JumpSinAngle = parsedPacket.ReadSingle();
            movementUpdate.MovementLiving.JumpCosAngle = parsedPacket.ReadSingle();
            movementUpdate.MovementLiving.JumpXySpeed = parsedPacket.ReadSingle();
        }

        if (movementUpdate.MovementLiving.MovementFlags.HasFlag(MovementTypes.SPLINE_ELEVATION)) movementUpdate.MovementLiving.SplineElevation = parsedPacket.ReadSingle();

        return movementUpdate;
    }
}