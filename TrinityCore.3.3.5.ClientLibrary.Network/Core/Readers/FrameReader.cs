using TrinityCore._3._3._5.ClientLibrary.Network.Core.Packets;
using TrinityCore._3._3._5.ClientLibrary.Network.Core.Tools;
using TrinityCore._3._3._5.ClientLibrary.Shared.Logger;

namespace TrinityCore._3._3._5.ClientLibrary.Network.Core.Readers;

public class FrameReader<TCommands> where TCommands : struct, Enum
{
    private readonly List<byte> _buffer = new();
    private readonly Dictionary<TCommands, TCommands> _compressedCommandsMap = new();
    private readonly FrameHeaderReader<TCommands> _headerReader;
    private readonly object _lock = new();

    public FrameReader(FrameHeaderReader<TCommands> headerReader)
    {
        _headerReader = headerReader;
    }

    public event Action<RawPacket<TCommands>>? PacketExtracted;

    /// <summary>
    ///     Ajoute de nouvelles données reçues et tente immédiatement
    ///     d'extraire tous les paquets complets.
    /// </summary>
    public void Feed(byte[]? data)
    {
        if (data == null || data.Length == 0) return;

        lock (_lock)
        {
            _buffer.AddRange(data);
            ProcessBuffer();
        }
    }

    protected void AddCompressedCommand(TCommands command, TCommands compressedCommand)
    {
        if (!_compressedCommandsMap.TryAdd(command, compressedCommand))
            throw new ArgumentException($"Opcode {command} already registered in compressed commands.");
    }

    /// <summary>
    ///     Lit le buffer tant qu'il contient des paquets complets,
    ///     les déclenche via PacketExtracted puis les enlève.
    /// </summary>
    private void ProcessBuffer()
    {
        // tant qu'on a au moins 4 octets pour length+opcode
        while (_headerReader.ReadHeader(_buffer))
        {
            try
            {
                if (_buffer.Count < _headerReader.ExpectedPayloadLength + _headerReader.HeaderLength)
                    break;

                byte[] payload = _buffer.Skip(_headerReader.HeaderLength).Take(_headerReader.ExpectedPayloadLength).ToArray();

                if (_headerReader.IsValid)
                {
                    RawPacket<TCommands> packet = new(_headerReader.Command, payload);

                    if (_compressedCommandsMap.TryGetValue(packet.Opcode, out TCommands uncompressedCommand))
                    {
                        packet.Opcode = uncompressedCommand;
                        packet.Payload = packet.Payload.Decompress();
                    }

                    PacketExtracted?.Invoke(packet);
                }
                else
                {
                    Log.Verbose($"Invalid packet received: {BitConverter.ToString(_buffer.ToArray())}");
                }
            }
            catch (Exception e)
            {
                Log.Error($"Error processing buffer: {_headerReader.Command} {e.Message}");
            }
            finally
            {
                lock (_lock)
                {
                    _buffer.RemoveRange(0, _headerReader.ExpectedPayloadLength + _headerReader.HeaderLength);
                } 
            }
        }
    }
}