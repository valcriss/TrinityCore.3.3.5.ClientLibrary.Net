using TrinityCore._3._3._5.ClientLibrary.AuthNetwork.Models.Messages;
using TrinityCore._3._3._5.ClientLibrary.AuthNetwork.Models.Results;

namespace TrinityCore._3._3._5.ClientLibrary.AuthNetwork.Models.Process;

public class RealmProcess : IDisposable
{
    public List<Realm> Realms { get; set; } = new();
    private readonly ManualResetEvent _realmListDone;
    public RealmProcess(ManualResetEvent realmListDone)
    {
        _realmListDone = realmListDone;
    }
    public void OnRealmListResponse(RealmListResponse realmListResponse)
    {
        Realms = new List<Realm>();
        Realms = realmListResponse.Realms;
        _realmListDone.Set();
    }

    public void Dispose()
    {
        _realmListDone.Dispose();
    }
}