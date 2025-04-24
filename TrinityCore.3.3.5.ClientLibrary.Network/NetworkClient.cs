using System.Net;
using TrinityCore._3._3._5.ClientLibrary.Network.Core;
using TrinityCore._3._3._5.ClientLibrary.Network.Core.Packets;
using TrinityCore._3._3._5.ClientLibrary.Network.Core.Parsers;
using TrinityCore._3._3._5.ClientLibrary.Network.Core.Readers;
using TrinityCore._3._3._5.ClientLibrary.Network.Core.Writers;

namespace TrinityCore._3._3._5.ClientLibrary.Network;

public class NetworkClient<TCommands> : IDisposable where TCommands : struct, Enum
{
    public Action? Connected;
    public Action? Disconnected;

    private readonly ConnectionManager _connectionManager;
    private readonly FrameReader<TCommands> _frameReader;
    private readonly FrameWriter<TCommands> _frameWriter;
    private readonly PacketParser<TCommands> _packetParser;
    private readonly NetworkEventBus<TCommands> _eventBus;

    public NetworkClient(string host,
        int port,
        FrameReader<TCommands> frameReader,
        FrameWriter<TCommands> frameWriter,
        PacketParser<TCommands> packetParser,
        NetworkEventBus<TCommands> eventBus)
    {
        _connectionManager = new ConnectionManager(host, port);
        _connectionManager.Disconnected += OnDisconnected;
        _connectionManager.Connected += OnConnected;
        _connectionManager.DataReceived += OnDataReceived;
        _frameReader = frameReader;
        _frameReader.PacketExtracted += OnPacketExtracted;
        _frameWriter = frameWriter;
        _packetParser = packetParser;
        _eventBus = eventBus;
    }

    public async Task ConnectAsync()
    {
        await _connectionManager.ConnectAsync();
    }

    public async Task DisconnectAsync()
    {
        await _connectionManager.DisconnectAsync();
    }

    public async Task SendAsync(OutgoingPacket<TCommands> packet)
    {
        byte[]? data = _frameWriter.Create(packet);
        if (data == null)
        {
            throw new InvalidOperationException("Failed to create packet data.");
        }

        await _connectionManager.SendAsync(data);
    }

    public IPAddress GetIpAddress()
    {
        return _connectionManager.GetIpAddress();
    }

    private void OnPacketExtracted(RawPacket<TCommands> rawPacket)
    {
        ParsedPacket<TCommands>? packet = _packetParser.Parse(rawPacket);
        if (packet != null)
        {
            _eventBus.Dispatch(packet.Command, packet.GetType(), packet);
        }
    }

    private void OnDataReceived(byte[]? data)
    {
        _frameReader.Feed(data);
    }

    private void OnConnected()
    {
        Connected?.Invoke();
    }

    private void OnDisconnected()
    {
        Disconnected?.Invoke();
    }

    public void Dispose()
    {
        _frameReader.PacketExtracted -= OnPacketExtracted;
        _connectionManager.Disconnected -= OnDisconnected;
        _connectionManager.Connected -= OnConnected;
        _connectionManager.DataReceived -= OnDataReceived;
        _connectionManager.DisconnectAsync().Wait();
        _connectionManager.Dispose();
    }
}