using TrinityCore._3._3._5.ClientLibrary.Network.Core.Packets;
using TrinityCore._3._3._5.ClientLibrary.Shared.Logger;

namespace TrinityCore._3._3._5.ClientLibrary.Network.Core.Registry;

/// <summary>
///     Registre qui mappe chaque opcode à une fonction de parsing dédiée.
/// </summary>
public class OpcodeRegistry<TCommands> where TCommands : struct, Enum
{
    private readonly List<TCommands> _missingCommands = new();
    private readonly Dictionary<TCommands, Func<RawPacket<TCommands>, ParsedPacket<TCommands>?>> _parsers = new();

    /// <summary>
    ///     Enregistre un parser pour un opcode donné.
    /// </summary>
    public void Register<T>(TCommands opcode, Func<RawPacket<TCommands>, T?> parser) where T : ParsedPacket<TCommands>
    {
        _parsers[opcode] = parser ?? throw new ArgumentNullException(nameof(parser));
    }

    /// <summary>
    ///     Tente de récupérer le parser associé à l’opcode.
    /// </summary>
    public bool TryGetParser(TCommands opcode, out Func<RawPacket<TCommands>, ParsedPacket<TCommands>?>? parser)
    {
        if (_parsers.TryGetValue(opcode, out parser)) return true;

        if (!_missingCommands.Contains(opcode))
        {
            Log.Warn($"Parser not found for : {opcode}");
            _missingCommands.Add(opcode);
        }

        parser = null;
        return false;
    }
}