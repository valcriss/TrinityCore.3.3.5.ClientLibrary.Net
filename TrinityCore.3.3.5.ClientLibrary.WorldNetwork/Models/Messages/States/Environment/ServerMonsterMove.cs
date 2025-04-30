using TrinityCore._3._3._5.ClientLibrary.Network.Core.Packets;
using TrinityCore._3._3._5.ClientLibrary.Shared.Enums;
using TrinityCore._3._3._5.ClientLibrary.WorldNetwork.Models.Enums;
using TrinityCore._3._3._5.ClientLibrary.WorldState.Enums;
using TrinityCore._3._3._5.ClientLibrary.WorldState.Models.Environment;

namespace TrinityCore._3._3._5.ClientLibrary.WorldNetwork.Models.Messages.States.Environment;

public class ServerMonsterMove : ParsedPacket<WorldCommands>
{
    private ServerMonsterMove(byte[]? data = null) : base(WorldCommands.SMSG_MONSTER_MOVE, data)
    {
    }

    public MonsterMoveData MonsterMoveData { get; set; } = new();

    public static ServerMonsterMove Parse(RawPacket<WorldCommands> rawPacket)
    {
        ServerMonsterMove packet = new(rawPacket.Payload);
        // Lire le GUID de l'entité qui se déplace
        packet.MonsterMoveData.MoverGuid = packet.ReadPackedGuid();
        sbyte b = packet.ReadSByte(); // = 0
        packet.MonsterMoveData.CurrentPosition = packet.ReadCoord();
        packet.ReadUInt32();
        MonsterMoveType monsterMove = (MonsterMoveType)packet.ReadSByte();
        switch (monsterMove)
        {
            case MonsterMoveType.FacingSpot:
                packet.MonsterMoveData.FacingSpot = packet.ReadCoord();
                break;

            case MonsterMoveType.FacingTarget:
                packet.MonsterMoveData.FacingTarget = packet.ReadPackedGuid();
                break;

            case MonsterMoveType.FacingAngle:
                packet.MonsterMoveData.Orientation = packet.ReadSingle();
                break;

            case MonsterMoveType.Stop:
                return packet;
        }

        uint splineFlags = packet.ReadUInt32();

        if ((splineFlags & (uint)SplineTypes.ANIMATION) != 0)
        {
            packet.ReadSByte();
            packet.ReadInt32();
        }

        packet.ReadInt32();

        if ((splineFlags & (uint)SplineTypes.PARABOLIC) != 0)
        {
            packet.ReadSingle();
            packet.ReadInt32();
        }

        if ((splineFlags & (uint)SplineTypes.CATMULLROM) != 0)
        {
            uint count = packet.ReadUInt32();
            for (int i = 0; i < count; i++) packet.MonsterMoveData.WayPoints.Add(packet.ReadCoord());
        }
        else
        {
            uint lastIndex = packet.ReadUInt32();
            packet.ReadCoord();
            if (lastIndex > 1)
                for (int i = 1; i < lastIndex; ++i)
                    packet.MonsterMoveData.WayPoints.Add(packet.ReadCoord());
        }

        // TODO: Fix paquet data read 1 byte left
        packet.ReadBytes(packet.DataLeftLength());
        
        return packet;
    }
}