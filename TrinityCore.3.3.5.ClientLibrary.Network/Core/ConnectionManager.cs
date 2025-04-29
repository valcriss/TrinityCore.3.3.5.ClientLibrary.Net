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
    private Socket? _socket;
    private CancellationTokenSource? _cts;

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
        if (_socket != null)
            throw new InvalidOperationException("Déjà connecté.");

        _socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        
        // Résolution du nom d'hôte en adresse IP
        IPHostEntry hostEntry = await Dns.GetHostEntryAsync(_host);
        IPAddress ipAddress = hostEntry.AddressList.FirstOrDefault(ip => ip.AddressFamily == AddressFamily.InterNetwork) 
                             ?? throw new InvalidOperationException("Impossible de résoudre l'adresse IP.");
        
        // Connexion au serveur
        await _socket.ConnectAsync(ipAddress, _port);

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

        if (_socket != null)
        {
            if (_socket.Connected)
            {
                _socket.Shutdown(SocketShutdown.Both);
            }
            _socket.Close();
            _socket = null;
        }

        // On notifie la déconnexion
        Disconnected?.Invoke();

        await Task.CompletedTask;
    }

    /// <summary>
    ///     Boucle de lecture asynchrone. Les octets reçus sont dispatchés via l'événement DataReceived.
    /// </summary>
    private async Task ReceiveLoopAsync(CancellationToken token)
    {
        byte[] buffer = new byte[44000];

        try
        {
            while (!token.IsCancellationRequested)
            {
                if (_socket == null || !_socket.Connected)
                {
                    Log.Error("Socket is null or disconnected.");
                    break;
                }

                int bytesRead = await _socket.ReceiveAsync(new ArraySegment<byte>(buffer), SocketFlags.None);
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
            // en cas d'erreur ou de fin de boucle, on notifie la déconnexion
            Disconnected?.Invoke();
        }
    }

    /// <summary>
    ///     Envoie asynchrone d'un buffer de données sur la connexion.
    /// </summary>
    /// <param name="data">Le tableau d'octets à envoyer.</param>
    public async Task SendAsync(byte[]? data)
    {
        if (_socket == null || !_socket.Connected)
            throw new InvalidOperationException("Connexion closed.");
        if (data == null || data.Length == 0)
            return;
        Log.Verbose("-> Sending data: " + BitConverter.ToString(data));
        try
        {
            await _socket.SendAsync(new ArraySegment<byte>(data), SocketFlags.None);
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
        IPAddress? ipAddress = ((IPEndPoint?)_socket?.LocalEndPoint)?.Address;
        if (ipAddress == null) return IPAddress.None;
        return ipAddress;
    }
}
