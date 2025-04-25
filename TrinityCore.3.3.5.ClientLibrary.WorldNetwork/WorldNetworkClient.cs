using TrinityCore._3._3._5.ClientLibrary.Network;
using TrinityCore._3._3._5.ClientLibrary.Network.Core;
using TrinityCore._3._3._5.ClientLibrary.Network.Core.Parsers;
using TrinityCore._3._3._5.ClientLibrary.Network.Core.Readers;
using TrinityCore._3._3._5.ClientLibrary.Network.Core.Registry;
using TrinityCore._3._3._5.ClientLibrary.Network.Core.Writers;
using TrinityCore._3._3._5.ClientLibrary.WorldNetwork.Models.Enums;
using TrinityCore._3._3._5.ClientLibrary.WorldNetwork.Models.Messages;
using TrinityCore._3._3._5.ClientLibrary.WorldNetwork.Models.Network;
using TrinityCore._3._3._5.ClientLibrary.WorldNetwork.Models.Security;

namespace TrinityCore._3._3._5.ClientLibrary.WorldNetwork
{
    public class WorldNetworkClient : IDisposable
    {
        private const int AUTHENTIFICATION_TIMEOUT = 5000;

        public Action? Connected;
        public Action? Disconnected;

        private readonly NetworkClient<WorldCommands> _networkClient;
        private readonly NetworkEventBus<WorldCommands> _eventBus;
        private readonly ManualResetEvent _authenticateDone;
        private readonly uint _realmId;
        private readonly string _username;
        private readonly byte[] _sessionKey;
        private readonly AuthenticationCrypto _crypto;
        
        private bool _authenticated;

        public WorldNetworkClient(string host, int port, uint reamlId, string username, byte[] sessionKey, NetworkEventBus<WorldCommands> eventBus)
        {
            _realmId = reamlId;
            _username = username;
            _sessionKey = sessionKey;
            _authenticateDone = new ManualResetEvent(false);
            _eventBus = eventBus;
            _authenticated = false;
            _crypto = new(_sessionKey);
            FrameReader<WorldCommands> frameReader = new(new WorldFrameHeaderReader(_crypto));
            FrameWriter<WorldCommands> frameWriter = new(new WorldFrameHeaderWriter(_crypto));
            PacketParser<WorldCommands> authPacketParser = new(CreateOpcodeRegistry());

            _networkClient = new NetworkClient<WorldCommands>(host, port, frameReader, frameWriter, authPacketParser, _eventBus);
            _networkClient.Connected += OnConnected;
            _networkClient.Disconnected += OnDisconnected;

            InitializeEventBus();
        }

        public async Task<bool> AuthenticateAsync()
        {
            try
            {
                await _networkClient.ConnectAsync();
                _authenticated = false;
                _authenticateDone.Reset();
                _authenticateDone.WaitOne(AUTHENTIFICATION_TIMEOUT);
                return _authenticated;
            }
            catch
            {
                _authenticateDone.Set();
                return false;
            }
        }

        private void OnConnected() => Connected?.Invoke();
        private void OnDisconnected()
        {
            _authenticated = false;
            Disconnected?.Invoke();
        }

        private void OnServerAuthChallengeRequest(ServerAuthChallengeRequest serverAuthChallenge)
        {
            _networkClient.SendAsync(new ServerAuthChallengeResponse(_realmId, _username, _sessionKey, serverAuthChallenge.ServerSeed)).Wait();
            _crypto.Activate();
        }
        
        private void OnServerAuthChallengeResult(ServerAuthChallengeResult serverAuthChallengeResult)
        {
            _authenticated = serverAuthChallengeResult.Success;
            _authenticateDone.Set();
        }

        private void InitializeEventBus()
        {
            _eventBus.Subscribe<ServerAuthChallengeRequest>(WorldCommands.SERVER_AUTH_CHALLENGE, OnServerAuthChallengeRequest);
            _eventBus.Subscribe<ServerAuthChallengeResult>(WorldCommands.SERVER_AUTH_RESPONSE, OnServerAuthChallengeResult);
        }
        
        private void ReleaseEventBus()
        {
            _eventBus.Subscribe<ServerAuthChallengeRequest>(WorldCommands.SERVER_AUTH_CHALLENGE, OnServerAuthChallengeRequest);
            _eventBus.Subscribe<ServerAuthChallengeResult>(WorldCommands.SERVER_AUTH_RESPONSE, OnServerAuthChallengeResult);
        }

        private OpcodeRegistry<WorldCommands> CreateOpcodeRegistry()
        {
            OpcodeRegistry<WorldCommands> registry = new();
            registry.Register(WorldCommands.SERVER_AUTH_CHALLENGE, ServerAuthChallengeRequest.Parse);
            registry.Register(WorldCommands.SERVER_AUTH_RESPONSE, ServerAuthChallengeResult.Parse);
            return registry;
        }

        public void Dispose()
        {
            _networkClient.Connected -= OnConnected;
            _networkClient.Disconnected -= OnDisconnected;
            _networkClient.Dispose();
            _authenticateDone.Dispose();
            ReleaseEventBus();
        }
    }
}