using TrinityCore._3._3._5.ClientLibrary.Network.Core.Packets;
using TrinityCore._3._3._5.ClientLibrary.Network.Core.Registry;

namespace TrinityCore._3._3._5.ClientLibrary.Network.Core.Parsers;

/// <summary>
///     Transforme RawPacket en ParsedPacket en utilisant l’OpcodeRegistry.
/// </summary>
public class PacketParser<TCommands> where TCommands : struct, Enum
{
    private readonly OpcodeRegistry<TCommands> _registry;

    public PacketParser(OpcodeRegistry<TCommands> registry)
    {
        _registry = registry ?? throw new ArgumentNullException(nameof(registry));
    }

    /// <summary>
    ///     Parse un RawPacket en appliquant le parser dédié ou retombe sur un paquet générique.
    /// </summary>
    public ParsedPacket<TCommands>? Parse(RawPacket<TCommands> raw)
    {
        ArgumentNullException.ThrowIfNull(raw);

        return _registry.TryGetParser(raw.Opcode, out Func<RawPacket<TCommands>, ParsedPacket<TCommands>?>? parser)
            ?
            // parser personnalisé
            parser?.Invoke(raw)
            : null;
    }
}