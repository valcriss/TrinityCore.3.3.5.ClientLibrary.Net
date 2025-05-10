using TrinityCore._3._3._5.ClientLibrary.Dbc;
using TrinityCore._3._3._5.ClientLibrary.WorldState.States;

namespace TrinityCore._3._3._5.ClientLibrary.WorldState;

public class GameState
{
    private readonly WorldStateEventBus _worldStateEventBus;

    public GameState()
    {
        _worldStateEventBus = new WorldStateEventBus();
        Server = new ServerState(_worldStateEventBus);
        Account = new AccountState(_worldStateEventBus);
        Social = new SocialState(_worldStateEventBus);
        Player = new PlayerState(_worldStateEventBus);
        Entities = new EntitiesState(_worldStateEventBus);
        Environment = new EnvironmentState(_worldStateEventBus);
    }

    public ServerState Server { get; private set; }
    public AccountState Account { get; private set; }
    public SocialState Social { get; private set; }
    public PlayerState Player { get; private set; }
    public EntitiesState Entities { get; private set; }
    public EnvironmentState Environment { get; private set; }

    public WorldStateEventBus GetWorldStateEventBus()
    {
        return _worldStateEventBus;
    }
}