using TrinityCore._3._3._5.ClientLibrary.Network.Core.Packets;

namespace TrinityCore._3._3._5.ClientLibrary.Network.Core.Writers;

public class FrameWriter<TCommands> where TCommands : struct, Enum
{
    private readonly FrameHeaderWriter<TCommands> _headerWriter;
    public FrameWriter(FrameHeaderWriter<TCommands> headerWriter)
    {
        _headerWriter = headerWriter;
    }

    public byte[]? Create(OutgoingPacket<TCommands> packet)
    {
        // Create the packet data using the header writer
        byte[]? header = _headerWriter.Create(packet);
        if (header == null)
        {
            return null;
        }

        // Combine header and packet data
        byte[] packetData = packet.GetData();
        byte[] data = new byte[header.Length + packetData.Length];
        Buffer.BlockCopy(header, 0, data, 0, header.Length);
        Buffer.BlockCopy(packetData, 0, data, header.Length, packetData.Length);

        return data;
    }
}