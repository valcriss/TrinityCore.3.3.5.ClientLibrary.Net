namespace TrinityCore._3._3._5.ClientLibrary.WorldState;

public class WorldStateEventBus
{
    private readonly Dictionary<Type, List<Delegate>> _eventHandlers = new();

    public void Register<T>(Action<T> handler) where T : class
    {
        if (!_eventHandlers.ContainsKey(typeof(T))) _eventHandlers[typeof(T)] = new List<Delegate>();
        _eventHandlers[typeof(T)].Add(handler);
    }

    public void Unregister<T>(Action<T> handler) where T : class
    {
        if (_eventHandlers.ContainsKey(typeof(T)))
        {
            _eventHandlers[typeof(T)].Remove(handler);
            if (_eventHandlers[typeof(T)].Count == 0) _eventHandlers.Remove(typeof(T));
        }
    }

    public void Publish<T>(T eventMessage) where T : class
    {
        if (_eventHandlers.ContainsKey(typeof(T)))
            foreach (Delegate handler in _eventHandlers[typeof(T)])
                ((Action<T>)handler)(eventMessage);
    }
}