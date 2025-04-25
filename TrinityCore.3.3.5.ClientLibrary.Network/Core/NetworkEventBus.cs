using TrinityCore._3._3._5.ClientLibrary.Network.Core.Packets;

namespace TrinityCore._3._3._5.ClientLibrary.Network.Core;

/// <summary>
///     Bus d'événements pour dispatcher des paquets entrants selon leur opcode.
/// </summary>
public class NetworkEventBus<TCommands> where TCommands : struct, Enum
{
    private readonly object _lock = new();

    private readonly Dictionary<TCommands, Dictionary<Type, List<Delegate>>> _subscribers = new();

    public void Subscribe<T>(TCommands command, Action<T> handler) where T : ParsedPacket<TCommands>
    {
        if (handler == null) throw new ArgumentNullException(nameof(handler));

        lock (_lock)
        {
            if (!_subscribers.TryGetValue(command, out Dictionary<Type, List<Delegate>>? typeDict))
            {
                typeDict = new Dictionary<Type, List<Delegate>>();
                _subscribers[command] = typeDict;
            }

            Type packetType = typeof(T);
            if (!typeDict.TryGetValue(packetType, out List<Delegate>? handlers))
            {
                handlers = new List<Delegate>();
                typeDict[packetType] = handlers;
            }

            handlers.Add(handler);
        }
    }

    public void Unsubscribe<T>(TCommands command, Action<T> handler) where T : ParsedPacket<TCommands>
    {
        if (handler == null) throw new ArgumentNullException(nameof(handler));

        lock (_lock)
        {
            if (_subscribers.TryGetValue(command, out Dictionary<Type, List<Delegate>>? typeDict) &&
                typeDict.TryGetValue(typeof(T), out List<Delegate>? handlers))
            {
                handlers.Remove(handler);
                if (handlers.Count == 0) typeDict.Remove(typeof(T));
            }
        }
    }

    public void Dispatch<T>(TCommands command, Type packetType, T packet) where T : ParsedPacket<TCommands>
    {
        List<Delegate> handlers = new();

        lock (_lock)
        {
            if (_subscribers.TryGetValue(command, out Dictionary<Type, List<Delegate>>? typeDict) &&
                typeDict.TryGetValue(packetType, out List<Delegate>? handlerList))
                handlers.AddRange(handlerList);
        }

        foreach (Delegate handler in handlers)
            try
            {
                // Utilisation de reflection pour invoquer le handler avec le type correct
                Type handlerType = handler.GetType();
                Type genericActionType = typeof(Action<>).MakeGenericType(packetType);

                if (handlerType == genericActionType || handlerType.GetInterfaces().Contains(genericActionType)) handler.DynamicInvoke(packet);
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Error in EventBus handler for command {command}: {ex}");
            }
    }
}