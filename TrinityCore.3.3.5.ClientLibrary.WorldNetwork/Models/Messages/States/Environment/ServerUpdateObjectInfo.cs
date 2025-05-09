using System.Collections;
using TrinityCore._3._3._5.ClientLibrary.Network.Core.Packets;
using TrinityCore._3._3._5.ClientLibrary.Shared.Enums;
using TrinityCore._3._3._5.ClientLibrary.WorldState.Enums;
using TrinityCore._3._3._5.ClientLibrary.WorldState.Models.Environment;

namespace TrinityCore._3._3._5.ClientLibrary.WorldNetwork.Models.Messages.States.Environment;

public class ServerUpdateObjectInfo : ParsedPacket<WorldCommands>
{
    public ServerUpdateObjectInfo(byte[]? data = null) : base(WorldCommands.SMSG_UPDATE_OBJECT, data)
    {
    }

    public UpdatePackage UpdatePackage { get; set; } = new();

    public static ServerUpdateObjectInfo Parse(RawPacket<WorldCommands> rawPacket)
    {
        ServerUpdateObjectInfo packet = new(rawPacket.Payload);
        uint count = packet.ReadUInt32();
        for (int i = 0; i < count; i++)
        {
            ObjectUpdateTypes type = (ObjectUpdateTypes)packet.ReadSByte();
            switch (type)
            {
                case ObjectUpdateTypes.UPDATETYPE_VALUES:
                    packet.UpdatePackage.UpdateValues.Add(new UpdateObjectValues
                    {
                        Guid = packet.ReadPackedGuid(),
                        Values = GetUpdateValues(packet)
                    });
                    break;
                case ObjectUpdateTypes.UPDATETYPE_MOVEMENT:
                    packet.UpdatePackage.UpdateMovements.Add(new UpdateMovement
                    {
                        Guid = packet.ReadPackedGuid(),
                        Movement = GetMovementInfo(packet)
                    });
                    break;
                case ObjectUpdateTypes.UPDATETYPE_CREATE_OBJECT:
                case ObjectUpdateTypes.UPDATETYPE_CREATE_OBJECT2:
                    packet.UpdatePackage.UpdateOrCreateObjects.Add(new UpdateCreateObject
                    {
                        Guid = packet.ReadPackedGuid(),
                        ObjectType = (TypeId)packet.ReadSByte(),
                        Movement = GetMovementInfo(packet),
                        Values = GetUpdateValues(packet)
                    });
                    break;
                case ObjectUpdateTypes.UPDATETYPE_OUT_OF_RANGE_OBJECTS:
                    uint guidCount = packet.ReadUInt32();
                    List<ulong> outOfRangeGuids = new();
                    for (int guidIndex = 0; guidIndex < guidCount; guidIndex++) outOfRangeGuids.Add(packet.ReadPackedGuid());

                    packet.UpdatePackage.UpdateOutOfRange.Add(new UpdateOutOfRange
                    {
                        OutOfRangeGuids = outOfRangeGuids
                    });
                    break;
            }
        }

        return packet;
    }

    private static MovementInfo GetMovementInfo(ServerUpdateObjectInfo packet)
    {
        MovementInfo movementInfo = new();
        ushort flags = packet.ReadUInt16();
        if ((flags & (ushort)ObjectUpdateOptions.UPDATEFLAG_LIVING) != 0)
            UpdateLiving(movementInfo, packet);
        else if ((flags & (ushort)ObjectUpdateOptions.UPDATEFLAG_POSITION) != 0)
            UpdatePosition(movementInfo, packet);
        else if ((flags & (ushort)ObjectUpdateOptions.UPDATEFLAG_STATIONARY_POSITION) != 0)
            movementInfo.MovementStationary = new MovementStationary
            {
                Stationary = new Position(packet.ReadSingle(), packet.ReadSingle(), packet.ReadSingle(), packet.ReadSingle())
            };

        if ((flags & (ushort)ObjectUpdateOptions.UPDATEFLAG_UNKNOWN) != 0) packet.ReadUInt32();

        if ((flags & (ushort)ObjectUpdateOptions.UPDATEFLAG_LOWGUID) != 0) packet.ReadUInt32();

        if ((flags & (ushort)ObjectUpdateOptions.UPDATEFLAG_HAS_TARGET) != 0)
        {
            if (packet.PeekByte() != 0)
                movementInfo.MovementHasTarget = new MovementHasTarget
                {
                    Target = packet.ReadPackedGuid()
                };
            else
                packet.ReadSByte();
        }

        if ((flags & (ushort)ObjectUpdateOptions.UPDATEFLAG_TRANSPORT) != 0) packet.ReadUInt32();

        if ((flags & (ushort)ObjectUpdateOptions.UPDATEFLAG_VEHICLE) != 0)
        {
            packet.ReadUInt32();
            packet.ReadSingle();
        }

        if ((flags & (ushort)ObjectUpdateOptions.UPDATEFLAG_ROTATION) != 0)
            movementInfo.MovementRotation = new MovementRotation
            {
                Rotation = packet.ReadInt64()
            };
        return movementInfo;
    }

    private static void UpdatePosition(MovementInfo movementInfo, ServerUpdateObjectInfo packet)
    {
        movementInfo.MovementPosition = new MovementPosition();
        movementInfo.MovementPosition.Transport = packet.PeekByte() != 0;

        if (movementInfo.MovementPosition.Transport)
            movementInfo.MovementPosition.TransportGuid = packet.ReadPackedGuid();
        else
            packet.ReadSByte();

        movementInfo.MovementPosition.Position = new Position(packet.ReadCoord(), 0);

        if (movementInfo.MovementPosition.Transport)
            movementInfo.MovementPosition.TransportPosition = new Position(packet.ReadCoord(), 0);
        else
            packet.ReadCoord();

        float o = packet.ReadSingle();

        movementInfo.MovementPosition.Position.O = o;
        if (movementInfo.MovementPosition.Transport)
            movementInfo.MovementPosition.TransportPosition = new Position
            {
                O = o
            };

        packet.ReadSingle();
    }

    private static void UpdateLiving(MovementInfo movementInfo, ServerUpdateObjectInfo packet)
    {
        movementInfo.MovementLiving = new MovementLiving();
        movementInfo.MovementLiving.MovementFlags = (MovementTypes)packet.ReadUInt32();
        movementInfo.MovementLiving.ExtraMovementFlags = (MovementOptions)packet.ReadUInt16();
        movementInfo.MovementLiving.Time = packet.ReadUInt32();
        movementInfo.MovementLiving.Position = new Position(packet.ReadCoord(), packet.ReadSingle());

        if (movementInfo.MovementLiving.MovementFlags.HasFlag(MovementTypes.ONTRANSPORT))
        {
            movementInfo.MovementLiving.TransportGuid = packet.ReadPackedGuid();
            movementInfo.MovementLiving.TransportPosition = new Position(packet.ReadCoord(), packet.ReadSingle());

            movementInfo.MovementLiving.TransportTime = packet.ReadUInt32();
            movementInfo.MovementLiving.TransportSeat = packet.ReadByte();
            if (movementInfo.MovementLiving.ExtraMovementFlags.HasFlag(MovementOptions.INTERPOLATED_MOVEMENT))
                movementInfo.MovementLiving.TransportTime2 = packet.ReadUInt32();
        }

        if (movementInfo.MovementLiving.MovementFlags.HasFlag(MovementTypes.SWIMMING) ||
            movementInfo.MovementLiving.MovementFlags.HasFlag(MovementTypes.FLYING) ||
            movementInfo.MovementLiving.ExtraMovementFlags.HasFlag(MovementOptions.ALWAYS_ALLOW_PITCHING))
            movementInfo.MovementLiving.Pitch = packet.ReadSingle();

        movementInfo.MovementLiving.FallTime = packet.ReadUInt32();

        if (movementInfo.MovementLiving.MovementFlags.HasFlag(MovementTypes.FALLING))
        {
            movementInfo.MovementLiving.JumpZSpeed = packet.ReadSingle();
            movementInfo.MovementLiving.JumpSinAngle = packet.ReadSingle();
            movementInfo.MovementLiving.JumpCosAngle = packet.ReadSingle();
            movementInfo.MovementLiving.JumpXySpeed = packet.ReadSingle();
        }

        if (movementInfo.MovementLiving.MovementFlags.HasFlag(MovementTypes.SPLINE_ELEVATION)) movementInfo.MovementLiving.SplineElevation = packet.ReadSingle();

        for (int i = 0; i < 9; i++) movementInfo.MovementLiving.Speeds.Add((UnitMoveType)i, packet.ReadSingle());

        if (movementInfo.MovementLiving.MovementFlags.HasFlag(MovementTypes.SPLINE_ENABLED))
        {
            movementInfo.MovementLiving.MovementSpline = new MovementSpline();
            movementInfo.MovementLiving.MovementSpline.SplineFlags = (SplineTypes)packet.ReadUInt32();
            if (movementInfo.MovementLiving.MovementSpline.SplineFlags == SplineTypes.FINAL_ANGLE)
                movementInfo.MovementLiving.MovementSpline.FacingAngle = packet.ReadSingle();
            else if (movementInfo.MovementLiving.MovementSpline.SplineFlags == SplineTypes.FINAL_TARGET)
                movementInfo.MovementLiving.MovementSpline.FacingTarget = packet.ReadSingle();
            else if (movementInfo.MovementLiving.MovementSpline.SplineFlags == SplineTypes.FINAL_POINT) movementInfo.MovementLiving.MovementSpline.FinalPosition = new Position(packet.ReadCoord(), 0);

            movementInfo.MovementLiving.MovementSpline.TimePassed = packet.ReadInt32();
            movementInfo.MovementLiving.MovementSpline.Duration = packet.ReadInt32();
            movementInfo.MovementLiving.MovementSpline.SplineId = packet.ReadUInt32();

            packet.ReadSingle(); // = 1.0
            packet.ReadSingle(); // = 1.0

            movementInfo.MovementLiving.MovementSpline.VerticalAcceleration = packet.ReadSingle();
            movementInfo.MovementLiving.MovementSpline.EffectStartTime = packet.ReadInt32();

            uint nodesCount = packet.ReadUInt32();
            movementInfo.MovementLiving.MovementSpline.SplineNodes = new Position[nodesCount];
            for (int i = 0; i < nodesCount; i++) movementInfo.MovementLiving.MovementSpline.SplineNodes[i] = new Position(packet.ReadCoord(), 0);

            movementInfo.MovementLiving.MovementSpline.SplineEvaluationMode = (SplineEvaluationMode)packet.ReadSByte();
            movementInfo.MovementLiving.MovementSpline.FinalDestination = new Position(packet.ReadCoord(), 0);
        }
    }

    private static Dictionary<UpdateFields, uint> GetUpdateValues(ServerUpdateObjectInfo packet)
    {
        Dictionary<UpdateFields, uint> values = new();
        byte blockCount = packet.ReadByte();
        int[] updateMask = new int[blockCount];
        for (int i = 0; i < blockCount; i++)
            updateMask[i] = packet.ReadInt32();
        BitArray mask = new(updateMask);

        for (uint i = 0; i < mask.Count; ++i)
        {
            if (!mask[(int)i])
                continue;

            values.Add((UpdateFields)i, packet.ReadUInt32());
        }

        return values;
    }
}