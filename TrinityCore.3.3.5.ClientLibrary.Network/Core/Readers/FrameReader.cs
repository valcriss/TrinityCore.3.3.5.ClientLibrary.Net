using TrinityCore._3._3._5.ClientLibrary.Network.Core.Packets;

namespace TrinityCore._3._3._5.ClientLibrary.Network.Core.Readers
{
    public class FrameReader<TCommands> where TCommands : struct, Enum
    {
        public event Action<RawPacket<TCommands>>? PacketExtracted;

        private readonly List<byte> _buffer = new();
        private readonly object _lock = new();
        private readonly FrameHeaderReader<TCommands> _headerReader;
        public FrameReader(FrameHeaderReader<TCommands> headerReader)
        {
            _headerReader = headerReader;
        }
        
        /// <summary>
        /// Ajoute de nouvelles données reçues et tente immédiatement
        /// d'extraire tous les paquets complets.
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

        /// <summary>
        /// Lit le buffer tant qu'il contient des paquets complets,
        /// les déclenche via PacketExtracted puis les enlève.
        /// </summary>
        private void ProcessBuffer()
        {
            // tant qu'on a au moins 4 octets pour length+opcode
            while (_headerReader.ReadHeader(_buffer))
            {
                if (_buffer.Count < _headerReader.ExpectedTotalLength)
                    break;

                byte[] payload = _buffer.Skip(_headerReader.HeaderLength).Take(_headerReader.ContentLength).ToArray();

                if (_headerReader.IsValid)
                {
                    var packet = new RawPacket<TCommands>(_headerReader.Command, payload);

                    PacketExtracted?.Invoke(packet);
                }

                _buffer.RemoveRange(0, _headerReader.ExpectedTotalLength);
            }
        }
    }
}
