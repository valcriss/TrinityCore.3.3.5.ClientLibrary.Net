using TrinityCore._3._3._5.ClientLibrary.AuthNetwork.Enums;
using TrinityCore._3._3._5.ClientLibrary.AuthNetwork.Models.Messages;
using TrinityCore._3._3._5.ClientLibrary.AuthNetwork.Models.Network;
using TrinityCore._3._3._5.ClientLibrary.AuthNetwork.Models.Process;
using TrinityCore._3._3._5.ClientLibrary.AuthNetwork.Models.Registry;
using TrinityCore._3._3._5.ClientLibrary.AuthNetwork.Models.Results;
using TrinityCore._3._3._5.ClientLibrary.AuthNetwork.Models.Security;
using TrinityCore._3._3._5.ClientLibrary.Network;
using TrinityCore._3._3._5.ClientLibrary.Network.Core;
using TrinityCore._3._3._5.ClientLibrary.Network.Core.Parsers;
using TrinityCore._3._3._5.ClientLibrary.Network.Core.Readers;
using TrinityCore._3._3._5.ClientLibrary.Network.Core.Registry;
using TrinityCore._3._3._5.ClientLibrary.Network.Core.Writers;

namespace TrinityCore._3._3._5.ClientLibrary.AuthNetwork
{
    public class AuthNetworkClient : IDisposable
    {
        public Action? Connected;
        public Action? Disconnected;

        private readonly NetworkClient<AuthCommands> _networkClient;
        private readonly NetworkEventBus<AuthCommands> _eventBus;
        private readonly AuthCredentials _credentials;
        private readonly AuthenticationProcess _authenticationProcess;
        private readonly RealmProcess _realmProcess;
        private readonly AuthOpcodeRegistryFactory _opcodeRegistryFactory = new();

        public AuthNetworkClient(string host, int port, string username, string password)
        {
            
            FrameReader<AuthCommands> frameReader = new(new AuthFrameHeaderReader());
            FrameWriter<AuthCommands> frameWriter = new(new AuthFrameHeaderWriter());
            PacketParser<AuthCommands> authPacketParser = new(_opcodeRegistryFactory.Create());
            
            _eventBus = new();
            
            _credentials = new AuthCredentials(username.ToUpper(), password);
            
            _networkClient = new NetworkClient<AuthCommands>(host, port, frameReader, frameWriter, authPacketParser, _eventBus);
            _networkClient.Connected += OnConnected;
            _networkClient.Disconnected += OnDisconnected;
            
            _authenticationProcess = new AuthenticationProcess(_networkClient, _credentials);
            _realmProcess = new RealmProcess(_networkClient);
            
            InitializeEventBus();
        }

        public async Task<AuthenticationResult> AuthenticateAsync() => await _authenticationProcess.AuthenticateAsync();
        public async Task<Realm[]?> GetRealmListAsync() => await _realmProcess.GetRealmListAsync();
        public async Task DisconnectAsync() => await _networkClient.DisconnectAsync();
        private void OnDisconnected() => Disconnected?.Invoke();

        private void OnConnected()
        {
            Connected?.Invoke();
            _networkClient.SendAsync(new AuthLogonChallenge(_credentials.Username, _networkClient.GetIpAddress())).Wait();
        }

        private void InitializeEventBus()
        {
            _eventBus.Subscribe<LogonChallengeResponse>(AuthCommands.LOGON_CHALLENGE, _authenticationProcess.OnLogonChallengeResponse);
            _eventBus.Subscribe<AuthProofResponse>(AuthCommands.LOGON_PROOF, _authenticationProcess.OnAuthProofResponse);
            _eventBus.Subscribe<RealmListResponse>(AuthCommands.REALM_LIST, _realmProcess.OnRealmListResponse);
        }
        
        private void ReleaseEventBus()
        {
            _eventBus.Unsubscribe<LogonChallengeResponse>(AuthCommands.LOGON_CHALLENGE, _authenticationProcess.OnLogonChallengeResponse);
            _eventBus.Unsubscribe<AuthProofResponse>(AuthCommands.LOGON_PROOF, _authenticationProcess.OnAuthProofResponse);
            _eventBus.Unsubscribe<RealmListResponse>(AuthCommands.REALM_LIST, _realmProcess.OnRealmListResponse);
        }

        public void Dispose()
        {
            _networkClient.Connected -= OnConnected;
            _networkClient.Disconnected -= OnDisconnected;
            _networkClient.Dispose();
            
            _authenticationProcess.Dispose();

            _realmProcess.Dispose();

            ReleaseEventBus();
        }
    }
}