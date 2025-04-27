using TrinityCore._3._3._5.ClientLibrary.Network;
using TrinityCore._3._3._5.ClientLibrary.WorldNetwork.Models.Enums;
using TrinityCore._3._3._5.ClientLibrary.WorldNetwork.Models.Messages;

namespace TrinityCore._3._3._5.ClientLibrary.WorldNetwork.Models.Process;

public class InternalProcess: IDisposable
{
    private readonly NetworkClient<WorldCommands> _networkClient;
    
    public InternalProcess(NetworkClient<WorldCommands> networkClient)
    {
         _networkClient  = networkClient; 
    }

    public void Dispose()
    {
        _networkClient.Dispose();
    }

    public void OnServerTimeSyncRequest(ServerTimeSyncRequest serverTimeSyncRequest)
    {
        _networkClient.SendAsync(new ClientTimeSyncResponse(serverTimeSyncRequest.SyncNextCounter)).Wait();
    }
}