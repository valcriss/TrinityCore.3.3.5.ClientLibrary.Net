namespace TrinityCore._3._3._5.ClientLibrary.Network.Core.Readers;

public abstract class FrameHeaderReader<TCommands> where TCommands : struct, Enum
{
    public TCommands Command { get; protected set; }
    public int ExpectedTotalLength { get; protected set; }
    public int HeaderLength { get; protected set; }

    public bool IsValid { get; protected set; }
    public int ContentLength => ExpectedTotalLength - HeaderLength;

    public abstract bool ReadHeader(List<byte>? data);
}