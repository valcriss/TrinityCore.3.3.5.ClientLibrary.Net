using TrinityCore._3._3._5.ClientLibrary.Network.Core.Readers;
using TrinityCore._3._3._5.ClientLibrary.Shared.Enums;

namespace TrinityCore._3._3._5.ClientLibrary.AuthNetwork.Models.Network;

public class AuthFrameHeaderReader : FrameHeaderReader<AuthCommands>
{
    public override bool ReadHeader(List<byte>? data)
    {
        if (data == null || data.Count == 0)
            return false;
        ExpectedTotalLength = data.Count;
        HeaderLength = 1;
        IsValid = true;
        byte commandData = data[0];
        if (!Enum.IsDefined(typeof(AuthCommands), commandData))
        {
            IsValid = false;
            return true;
        }

        Command = (AuthCommands)data[0];
        return true;
    }
}