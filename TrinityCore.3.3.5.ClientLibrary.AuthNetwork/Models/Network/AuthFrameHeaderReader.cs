using TrinityCore._3._3._5.ClientLibrary.AuthNetwork.Enums;
using TrinityCore._3._3._5.ClientLibrary.Network.Core.Readers;

namespace TrinityCore._3._3._5.ClientLibrary.AuthNetwork.Models.Network;

public class AuthFrameHeaderReader : FrameHeaderReader<AuthCommands>
{
    public override bool ReadHeader(List<byte>? data)
    {
        if (data == null || data.Count == 0)
            return false;
        ExpectedPayloadLength = data.Count - 1;
        HeaderLength = 1;
        IsValid = Enum.IsDefined(typeof(AuthCommands), data[0]);
        Command = (AuthCommands)data[0];
        return true;
    }
}