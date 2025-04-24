namespace TrinityCore._3._3._5.ClientLibrary.Network.Core.Readers;

public abstract class FrameHeaderReader<TCommands> where TCommands : struct, Enum
{
    public TCommands Command { get; set; }
    public int ExpectedTotalLength { get;set; }
    public int HeaderLength { get;set; }
    
    public bool IsValid { get; set; }
    public int ContentLength => ExpectedTotalLength - HeaderLength;
    
    public abstract bool ReadHeader(List<byte>? data);
}