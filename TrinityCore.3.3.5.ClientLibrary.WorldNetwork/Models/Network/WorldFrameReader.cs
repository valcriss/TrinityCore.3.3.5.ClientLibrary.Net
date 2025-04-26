using TrinityCore._3._3._5.ClientLibrary.Network.Core.Readers;
using TrinityCore._3._3._5.ClientLibrary.WorldNetwork.Models.Enums;

namespace TrinityCore._3._3._5.ClientLibrary.WorldNetwork.Models.Network;

public class WorldFrameReader : FrameReader<WorldCommands>
{
    public WorldFrameReader(FrameHeaderReader<WorldCommands> headerReader) : base(headerReader)
    {
        AddCompressedCommand(WorldCommands.SMSG_COMPRESSED_UPDATE_OBJECT, WorldCommands.SMSG_UPDATE_OBJECT);
    }
}