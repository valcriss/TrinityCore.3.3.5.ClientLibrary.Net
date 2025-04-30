using TrinityCore._3._3._5.ClientLibrary.Network.Core.Packets;
using TrinityCore._3._3._5.ClientLibrary.Shared.Enums;
using TrinityCore._3._3._5.ClientLibrary.WorldNetwork.Models.Enums;
using TrinityCore._3._3._5.ClientLibrary.WorldState.Models.Player;

namespace TrinityCore._3._3._5.ClientLibrary.WorldNetwork.Models.Messages.States.Player;

public class ServerEquipmentSetList : ParsedPacket<WorldCommands>
{
    public ServerEquipmentSetList(byte[]? data = null) : base(WorldCommands.SMSG_EQUIPMENT_SET_LIST, data)
    {
    }

    public EquipmentSets EquipmentSets { get; set; } = new();

    public static ServerEquipmentSetList Parse(RawPacket<WorldCommands> rawPacket)
    {
        ServerEquipmentSetList packet = new(rawPacket.Payload);
        uint count = packet.ReadUInt32();
        for (int i = 0; i < count; i++)
        {
            EquipmentSet set = new();

            // Lire le GUID de l'ensemble (packed)
            set.Guid = packet.ReadPackedGuid();

            // Lire l'identifiant du set
            set.SetId = packet.ReadUInt32();

            // Lire le nom de l'ensemble (chaîne C terminée par \0)
            set.Name = packet.ReadCString();

            // Lire l'icône de l'ensemble (chaîne C terminée par \0)
            set.Icon = packet.ReadCString();

            // Lire les emplacements d'équipement (19 emplacements au total)
            for (int slot = 0; slot < 19; slot++)
            {
                ulong itemGuid = packet.ReadPackedGuid();

                // Si le guid est 1, c'est un emplacement ignoré
                if (itemGuid == 1)
                    set.IgnoreMask |= (uint)(1 << slot);
                else
                    set.Items[slot] = itemGuid;
            }

            packet.EquipmentSets.Sets.Add(set);
        }

        return packet;
    }
}