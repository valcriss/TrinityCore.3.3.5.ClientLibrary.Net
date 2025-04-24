using TrinityCore._3._3._5.ClientLibrary.AuthNetwork.Enums;
using TrinityCore._3._3._5.ClientLibrary.AuthNetwork.Models.Messages;
using TrinityCore._3._3._5.ClientLibrary.AuthNetwork.Models.Network;
using TrinityCore._3._3._5.ClientLibrary.AuthNetwork.Models.Process;
using TrinityCore._3._3._5.ClientLibrary.AuthNetwork.Models.Results;
using TrinityCore._3._3._5.ClientLibrary.AuthNetwork.Models.Security;
using TrinityCore._3._3._5.ClientLibrary.Network;
using TrinityCore._3._3._5.ClientLibrary.Network.Core;
using TrinityCore._3._3._5.ClientLibrary.Network.Core.Parsers;
using TrinityCore._3._3._5.ClientLibrary.Network.Core.Readers;
using TrinityCore._3._3._5.ClientLibrary.Network.Core.Registry;
using TrinityCore._3._3._5.ClientLibrary.Network.Core.Writers;
using TrinityCore._3._3._5.ClientLibrary.Shared.Enums;

namespace TrinityCore._3._3._5.ClientLibrary.AuthNetwork
{
    public class AuthNetworkClient : IDisposable
    {
        private const int AUTHENTIFICATION_TIMEOUT = 5000;
        private const int REALM_LIST_TIMEOUT = 5000;

        public Action? Connected;
        public Action? Disconnected;
        public Action<ConnexionResult>? AuthenticationFailed;
        public Action<ConnexionResult>? AuthenticationSucceeded;

        private readonly NetworkClient<AuthCommands> _networkClient;
        private readonly NetworkEventBus<AuthCommands> _eventBus;
        private readonly AuthCredentials _credentials;
        private readonly AuthenticationProcess _authenticationProcess;
        private readonly RealmProcess _realmProcess;
        private readonly ManualResetEvent _authenticateDone;
        private readonly ManualResetEvent _realmListDone;

        public AuthNetworkClient(string host, int port, string username, string password)
        {
            _authenticateDone = new ManualResetEvent(false);
            _realmListDone = new ManualResetEvent(false);

            FrameReader<AuthCommands> frameReader = new(new AuthFrameHeaderReader());
            FrameWriter<AuthCommands> frameWriter = new(new AuthFrameHeaderWriter());
            PacketParser<AuthCommands> authPacketParser = new(CreateOpcodeRegistry());

            _eventBus = new();
            InitializeEventBus();

            _networkClient = new NetworkClient<AuthCommands>(host, port, frameReader, frameWriter, authPacketParser, _eventBus);
            _networkClient.Connected += OnConnected;
            _networkClient.Disconnected += OnDisconnected;

            _credentials = new AuthCredentials(username.ToUpper(), password);

            _authenticationProcess = new AuthenticationProcess(_networkClient, _credentials, _authenticateDone);
            _authenticationProcess.AuthenticationFailed += OnAuthenticationFailed;
            _authenticationProcess.AuthenticationSucceeded += OnAuthenticationSucceeded;

            _realmProcess = new RealmProcess(_realmListDone);
        }

        private void OnAuthenticationSucceeded(ConnexionResult result) => AuthenticationSucceeded?.Invoke(result);
        private void OnAuthenticationFailed(ConnexionResult result) => AuthenticationFailed?.Invoke(result);
        private void OnLogonChallengeResponse(LogonChallengeResponse logonChallengeResponse) => _authenticationProcess.OnLogonChallengeResponse(logonChallengeResponse);
        private void OnAuthProofResponse(AuthProofResponse authProofResponse) => _authenticationProcess.OnAuthProofResponse(authProofResponse);
        private void OnRealmListResponse(RealmListResponse realmListResponse) => _realmProcess.OnRealmListResponse(realmListResponse);

        public async Task<AuthenticationResult> AuthenticateAsync()
        {
            try
            {
                await _networkClient.ConnectAsync();
                _authenticateDone.Reset();
                _authenticateDone.WaitOne(AUTHENTIFICATION_TIMEOUT);
                return new AuthenticationResult(_credentials.Username, _credentials.SessionKey, true);
            }
            catch
            {
                _authenticateDone.Set();
                return new AuthenticationResult(_credentials.Username, _credentials.SessionKey, false);
            }
        }

        public async Task<RealmListResult?> GetRealmListAsync()
        {
            try
            {
                await _networkClient.SendAsync(new RealmListRequest());
                _realmListDone.Reset();
                _realmListDone.WaitOne(REALM_LIST_TIMEOUT);
                return new RealmListResult(_realmProcess.Realms);
            }
            catch
            {
                _realmListDone.Set();
                return null;
            }
        }

        public async Task DisconnectAsync() => await _networkClient.DisconnectAsync();

        private void OnDisconnected() => Disconnected?.Invoke();

        private void OnConnected()
        {
            Connected?.Invoke();
            _networkClient.SendAsync(new AuthLogonChallenge(_credentials.Username, _networkClient.GetIpAddress())).Wait();
        }

        private void InitializeEventBus()
        {
            _eventBus.Subscribe<LogonChallengeResponse>(AuthCommands.LOGON_CHALLENGE, OnLogonChallengeResponse);
            _eventBus.Subscribe<AuthProofResponse>(AuthCommands.LOGON_PROOF, OnAuthProofResponse);
            _eventBus.Subscribe<RealmListResponse>(AuthCommands.REALM_LIST, OnRealmListResponse);
        }


        private void CloseEventBus()
        {
            _eventBus.Unsubscribe<LogonChallengeResponse>(AuthCommands.LOGON_CHALLENGE, OnLogonChallengeResponse);
            _eventBus.Unsubscribe<AuthProofResponse>(AuthCommands.LOGON_PROOF, OnAuthProofResponse);
            _eventBus.Unsubscribe<RealmListResponse>(AuthCommands.REALM_LIST, OnRealmListResponse);
        }

        private OpcodeRegistry<AuthCommands> CreateOpcodeRegistry()
        {
            OpcodeRegistry<AuthCommands> registry = new();
            registry.Register(AuthCommands.LOGON_CHALLENGE, LogonChallengeResponse.Parse);
            registry.Register(AuthCommands.LOGON_PROOF, AuthProofResponse.Parse);
            registry.Register(AuthCommands.REALM_LIST, RealmListResponse.Parse);
            return registry;
        }

        public void Dispose()
        {
            _authenticateDone.Dispose();
            _realmListDone.Dispose();

            _networkClient.Connected -= OnConnected;
            _networkClient.Disconnected -= OnDisconnected;
            _networkClient.Dispose();

            _authenticationProcess.AuthenticationFailed -= OnAuthenticationFailed;
            _authenticationProcess.AuthenticationSucceeded -= OnAuthenticationSucceeded;
            _authenticationProcess.Dispose();

            _realmProcess.Dispose();

            CloseEventBus();
        }
    }
}