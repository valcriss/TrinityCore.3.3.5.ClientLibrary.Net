using System.Net;
using System.Net.Sockets;
using TrinityCore._3._3._5.ClientLibrary.Shared.Logger;

namespace TrinityCore._3._3._5.ClientLibrary.Network.Core;

/// <summary>
///     Gère la connexion TCP, la réception asynchrone des données et la notification des événements
/// </summary>
public class ConnectionManager : IDisposable
{
    private readonly string _host;
    private readonly int _port;
    private TcpClient? _client;
    private CancellationTokenSource? _cts;
    private NetworkStream? _stream;

    public ConnectionManager(string host, int port)
    {
        _host = host;
        _port = port;
    }

    /// <summary>
    ///     Pour libérer les ressources.
    /// </summary>
    public void Dispose()
    {
        DisconnectAsync().GetAwaiter().GetResult();
        _cts?.Dispose();
    }

    /// <summary>
    ///     Événement déclenché à chaque fois que des données brutes sont reçues.
    /// </summary>
    public event Action<byte[]>? DataReceived;


    /// <summary>
    ///     Événement déclenché lorsque la connexion est ouverte (serveur ou client).
    /// </summary>
    public event Action? Connected;


    /// <summary>
    ///     Événement déclenché lorsque la connexion est fermée (serveur ou client).
    /// </summary>
    public event Action? Disconnected;

    /// <summary>
    ///     Ouvre la connexion et démarre la boucle de réception en tâche de fond.
    /// </summary>
    public async Task ConnectAsync()
    {
        if (_client != null)
            throw new InvalidOperationException("Déjà connecté.");

        _client = new TcpClient();
        await _client.ConnectAsync(_host, _port);
        _stream = _client.GetStream();

        Connected?.Invoke();

        _cts = new CancellationTokenSource();
        _ = Task.Run(() => ReceiveLoopAsync(_cts.Token));
    }

    /// <summary>
    ///     Ferme la connexion et stoppe la boucle de réception.
    /// </summary>
    public async Task DisconnectAsync()
    {
        if (_cts != null && !_cts.IsCancellationRequested)
            await _cts.CancelAsync();

        _stream?.Close();
        _client?.Close();

        // On notifie la déconnexion
        Disconnected?.Invoke();

        await Task.CompletedTask;
    }

    /// <summary>
    ///     Boucle de lecture asynchrone. Les octets reçus sont dispatchés via l'événement DataReceived.
    /// </summary>
    private async Task ReceiveLoopAsync(CancellationToken token)
    {
        byte[] buffer = new byte[8192];

        try
        {
            while (!token.IsCancellationRequested)
            {
                if (_stream == null)
                {
                    Log.Error("Socket stream is null.");
                    break;
                }

                int bytesRead = await _stream.ReadAsync(buffer, 0, buffer.Length, token);
                if (bytesRead == 0)
                {
                    Log.Warn("Server closed the connection.");
                    break; // le serveur a fermé la connexion
                }

                // Copie des données reçues dans un tableau à la taille exacte
                byte[] data = new byte[bytesRead];
                Array.Copy(buffer, data, bytesRead);
                Log.Verbose("<- Receiving data: " + BitConverter.ToString(data));
                DataReceived?.Invoke(data);
            }
        }
        catch (OperationCanceledException)
        {
            // cancellation demandée, on sort proprement
        }
        catch (Exception ex)
        {
            Log.Error(ex.Message);
        }
        finally
        {
            // en cas d’erreur ou de fin de boucle, on notifie la déconnexion
            Disconnected?.Invoke();
        }
    }

    /// <summary>
    ///     Envoie asynchrone d'un buffer de données sur la connexion.
    /// </summary>
    /// <param name="data">Le tableau d'octets à envoyer.</param>
    public async Task SendAsync(byte[]? data)
    {
        if (_stream == null)
            throw new InvalidOperationException("Connexion closed.");
        if (data == null || data.Length == 0)
            return;
        Log.Verbose("-> Sending data: " + BitConverter.ToString(data));
        try
        {
            await _stream.WriteAsync(data, 0, data.Length);
        }
        catch (Exception ex)
        {
            // log ou gestion d'erreur et potentiellement déclencher Disconnected
            Log.Error(ex.Message);
            Disconnected?.Invoke();
        }
    }

    public IPAddress GetIpAddress()
    {
        IPAddress? ipAddress = ((IPEndPoint?)_client?.Client.LocalEndPoint)?.Address;
        if (ipAddress == null) return IPAddress.None;
        return ipAddress;
    }
}