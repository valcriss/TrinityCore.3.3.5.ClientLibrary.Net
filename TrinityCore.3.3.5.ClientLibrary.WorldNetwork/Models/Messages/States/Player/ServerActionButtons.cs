using TrinityCore._3._3._5.ClientLibrary.Network.Core.Packets;
using TrinityCore._3._3._5.ClientLibrary.WorldNetwork.Models.Enums;
using TrinityCore._3._3._5.ClientLibrary.WorldState.Enums;
using TrinityCore._3._3._5.ClientLibrary.WorldState.Models.Player;

namespace TrinityCore._3._3._5.ClientLibrary.WorldNetwork.Models.Messages.States.Player;

public class ServerActionButtons : ParsedPacket<WorldCommands>
{
    private const int MAX_ACTION_BUTTONS = 144;

    public ServerActionButtons(byte[]? data = null) : base(WorldCommands.SMSG_ACTION_BUTTONS, data)
    {
    }

    public ActionButtons Buttons { get; set; } = new();

    public static ServerActionButtons Parse(RawPacket<WorldCommands> rawPacket)
    {
        ServerActionButtons packet = new(rawPacket.Payload);
        byte state = packet.ReadByte();
        if (state == 2)
            return packet;
        for (int button = 0; button < MAX_ACTION_BUTTONS; button++)
        {
            // Chaque bouton est stocké dans un uint32
            uint packedData = packet.ReadUInt32();

            // Si packedData est 0, ce bouton est vide
            if (packedData == 0)
                continue;

            // Extraire l'ID de l'action (24 bits inférieurs) et le type (8 bits supérieurs)
            uint actionId = packedData & 0x00FFFFFF;
            ActionButtonType type = (ActionButtonType)((packedData & 0xFF000000) >> 24);

            // Déterminer le nom du type pour l'affichage
            string typeName = GetTypeName(type);

            // Ajouter au dictionnaire
            packet.Buttons.Buttons[button] = new ActionButton
            {
                ActionId = actionId,
                Type = type,
                TypeName = typeName
            };
        }

        return packet;
    }

    private static string GetTypeName(ActionButtonType type)
    {
        switch (type)
        {
            case ActionButtonType.ACTION_BUTTON_SPELL:
                return "Sort";
            case ActionButtonType.ACTION_BUTTON_C:
                return "Commande";
            case ActionButtonType.ACTION_BUTTON_EQSET:
                return "Ensemble d'équipement";
            case ActionButtonType.ACTION_BUTTON_MACRO:
                return "Macro";
            case ActionButtonType.ACTION_BUTTON_CMACRO:
                return "Macro système";
            case ActionButtonType.ACTION_BUTTON_ITEM:
                return "Objet";
            default:
                return "Inconnu";
        }
    }
}