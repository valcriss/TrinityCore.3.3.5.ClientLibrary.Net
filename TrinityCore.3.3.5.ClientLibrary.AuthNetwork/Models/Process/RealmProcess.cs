using TrinityCore._3._3._5.ClientLibrary.AuthNetwork.Enums;
using TrinityCore._3._3._5.ClientLibrary.AuthNetwork.Models.Messages;
using TrinityCore._3._3._5.ClientLibrary.AuthNetwork.Models.Results;
using TrinityCore._3._3._5.ClientLibrary.Network;

namespace TrinityCore._3._3._5.ClientLibrary.AuthNetwork.Models.Process;

public class RealmProcess : IDisposable
{
    private const int REALM_LIST_TIMEOUT = 5000;
    private readonly NetworkClient<AuthCommands> _networkClient;

    private readonly ManualResetEvent _realmListDone;

    private Realm[] _realms = [];

    public RealmProcess(NetworkClient<AuthCommands> networkClient)
    {
        _networkClient = networkClient;
        _realmListDone = new ManualResetEvent(false);
    }

    public void Dispose()
    {
        _realmListDone.Dispose();
        _networkClient.Dispose();
    }

    public async Task<Realm[]?> GetRealmListAsync()
    {
        try
        {
            _realms = [];
            await _networkClient.SendAsync(new RealmListRequest());
            _realmListDone.Reset();
            _realmListDone.WaitOne(REALM_LIST_TIMEOUT);
            return _realms;
        }
        catch
        {
            _realmListDone.Set();
            return null;
        }
    }

    public void OnRealmListResponse(RealmListResponse realmListResponse)
    {
        _realms = realmListResponse.Realms.ToArray();
        _realmListDone.Set();
    }
}