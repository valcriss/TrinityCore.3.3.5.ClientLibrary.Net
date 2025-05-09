using TrinityCore._3._3._5.ClientLibrary.Network.Core.Packets;
using TrinityCore._3._3._5.ClientLibrary.Shared.Enums;
using TrinityCore._3._3._5.ClientLibrary.WorldState.Models.Environment;

namespace TrinityCore._3._3._5.ClientLibrary.WorldNetwork.Models.Messages.States.Environment;

public class ServerSpellGo : ParsedPacket<WorldCommands>
{
    public ServerSpellGo(byte[]? data = null) : base(WorldCommands.SMSG_SPELL_GO, data)
    {
    }

    public SpellGoInfo SpellGoInfo { get; set; } = new();

    public static ServerSpellGo Parse(RawPacket<WorldCommands> rawPacket)
    {
        ServerSpellGo packet = new(rawPacket.Payload);

        // Lire les informations du lanceur
        packet.SpellGoInfo.CasterGUID = packet.ReadPackedGuid();
        packet.SpellGoInfo.CasterUnitGUID = packet.ReadPackedGuid();

        // Lire l'ID du sort
        packet.SpellGoInfo.SpellID = packet.ReadUInt32();

        // Lire les flags de cast
        packet.SpellGoInfo.CastFlags = packet.ReadUInt32();
        packet.SpellGoInfo.CastTime = packet.ReadUInt32();

        // Vérifier les flags supplémentaires (CastFlags 0x200 = CastFlagsEx présent)
        if ((packet.SpellGoInfo.CastFlags & 0x200) != 0)
            packet.SpellGoInfo.CastFlagsEx = packet.ReadUInt32();

        // Lire le nombre de cibles touchées
        byte hitTargetsCount = packet.ReadByte();
        for (int i = 0; i < hitTargetsCount; i++) packet.SpellGoInfo.HitTargets.Add(packet.ReadPackedGuid());

        // Lire le nombre de cibles manquées
        byte missTargetsCount = packet.ReadByte();
        for (int i = 0; i < missTargetsCount; i++)
        {
            ulong targetGuid = packet.ReadPackedGuid();
            packet.SpellGoInfo.MissTargets.Add(targetGuid);
            packet.SpellGoInfo.MissStatus.Add((SpellMissInfo)packet.ReadByte());
        }

        // Lire le masque de cible
        packet.SpellGoInfo.TargetMask = packet.ReadUInt32();
        packet.SpellGoInfo.HasTargetMask = packet.SpellGoInfo.TargetMask != 0;

        // Vérifier si une cible est spécifiée (TARGET_FLAG_UNIT 0x0002)
        if ((packet.SpellGoInfo.TargetMask & 0x0002) != 0) packet.SpellGoInfo.TargetGUID = packet.ReadPackedGuid();

        // Vérifier si une position de destination est spécifiée (TARGET_FLAG_DEST_LOCATION 0x0040)
        if ((packet.SpellGoInfo.TargetMask & 0x0040) != 0)
        {
            packet.SpellGoInfo.HasDestLocation = true;
            ulong transportGuid = packet.ReadPackedGuid(); // Transport GUID si présent
            packet.SpellGoInfo.TargetPosition = packet.ReadCoord();
        }

        // Vérifier si un item est ciblé (TARGET_FLAG_ITEM 0x0010)
        if ((packet.SpellGoInfo.TargetMask & 0x0010) != 0)
        {
            ulong itemTargetGuid = packet.ReadPackedGuid();
            packet.SpellGoInfo.ItemTargetEntry = packet.ReadUInt32();
        }

        // Si CastFlags contient le bit 0x100 (CAST_FLAG_POWER_LEFT_SELF), lire les informations de puissance
        if ((packet.SpellGoInfo.CastFlags & 0x100) != 0)
            packet.SpellGoInfo.PowerData = new SpellPowerData
            {
                PowerType = packet.ReadUInt32(),
                CurrentPower = packet.ReadInt32()
            };

        // Cibles prédites (CAST_FLAG_PREDICTED_POWER 0x0800)
        if ((packet.SpellGoInfo.CastFlags & 0x0800) != 0)
        {
            // Lecture du nombre de cibles prédites
            byte predictedTargetsCount = packet.ReadByte();
            for (int i = 0; i < predictedTargetsCount; i++) packet.SpellGoInfo.PredictedTargets.Add(packet.ReadPackedGuid());
        }

/*
        // Vérifier les cibles supplémentaires (CAST_FLAG_EXTRA_TARGETS 0x80000)
        if ((packet.SpellGoInfo.CastFlags & 0x80000) != 0)
        {
            packet.SpellGoInfo.HasExtraTargets = true;
            uint extraTargetsCount = packet.ReadUInt32();

            for (int i = 0; i < extraTargetsCount; i++)
            {
                packet.SpellGoInfo.ExtraTargets.Add(new SpellExtraTarget()
                {
                    Position = packet.ReadCoord(),
                    TargetGUID = packet.ReadPackedGuid()
                });
            }
        }
*/
        return packet;
    }
}