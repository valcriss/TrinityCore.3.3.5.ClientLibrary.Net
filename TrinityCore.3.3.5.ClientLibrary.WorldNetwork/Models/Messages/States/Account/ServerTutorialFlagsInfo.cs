using TrinityCore._3._3._5.ClientLibrary.Network.Core.Packets;
using TrinityCore._3._3._5.ClientLibrary.Shared.Enums;
using TrinityCore._3._3._5.ClientLibrary.WorldNetwork.Models.Enums;
using TrinityCore._3._3._5.ClientLibrary.WorldState.Models.Account;

namespace TrinityCore._3._3._5.ClientLibrary.WorldNetwork.Models.Messages.States.Account;

public class ServerTutorialFlagsInfo : ParsedPacket<WorldCommands>
{
    private ServerTutorialFlagsInfo(byte[]? data = null) : base(WorldCommands.SMSG_TUTORIAL_FLAGS, data)
    {
    }

    public TutorialFlags TutorialFlags { get; set; } = new();

    public static ServerTutorialFlagsInfo Parse(RawPacket<WorldCommands> rawPacket)
    {
        ServerTutorialFlagsInfo packet = new(rawPacket.Payload);
        for (int i = 0; i < TutorialFlags.MAX_ACCOUNT_TUTORIAL_VALUES; i++) packet.TutorialFlags.Values[i] = packet.ReadUInt32();
        return packet;
    }
}