using TrinityCore._3._3._5.ClientLibrary.AuthNetwork;
using TrinityCore._3._3._5.ClientLibrary.AuthNetwork.Models.Results;
using TrinityCore._3._3._5.ClientLibrary.Dbc;
using TrinityCore._3._3._5.ClientLibrary.Network.Core.Tools;
using TrinityCore._3._3._5.ClientLibrary.Shared.Logger;
using TrinityCore._3._3._5.ClientLibrary.WorldNetwork;
using TrinityCore._3._3._5.ClientLibrary.WorldNetwork.Models.Results;
using TrinityCore._3._3._5.ClientLibrary.WorldState;

namespace TrinityCore._3._3._5.ClientLibrary.Console;

internal class Program
{
    private const string HOST = "127.0.0.1";
    private const int AUTH_PORT = 3724;
    private const string USERNAME = "test";
    private const string PASSWORD = "test";
    private const string DBC_PATH = @"D:\Développement\clientdata\3.3.5\dbc";
    private const LogLevel LOG_LEVEL = LogLevel.INFO;

    private static AuthNetworkClient? _authNetworkClient;
    private static WorldNetworkClient? _worldNetworkClient;
    private static GameState? _worldState;

    private static async Task Main(string[] args)
    {
        _worldState = new GameState(new DbcCollection(DBC_PATH));
        ConfigureLogger();

        try
        {
            await RunClientAsync();
            WaitForQuitCommand();
        }
        catch (Exception ex)
        {
            Log.Error($"Une erreur est survenue : {ex.Message}");
        }
        finally
        {
            await DisconnectAsync();
        }
    }

    private static void ConfigureLogger()
    {
        Log.SetLogger(new ConsoleLogger());
        Log.SetLogLevel(LOG_LEVEL);
        Log.Success("Démarrage du client AuthNetwork...");
    }

    private static async Task RunClientAsync()
    {
        AuthenticationResult authResult = await AuthenticateToServerAsync();
        if (!authResult.IsAuthenticated)
        {
            Log.Error($"Échec d'authentification : {authResult.ConnexionResult}");
            return;
        }

        Log.Success($"Authentifié avec succès. Bienvenue {authResult.Username}");

        Realm? realm = await SelectRealmAsync();
        if (realm == null) return;

        await ConnectToWorldAsync(realm, authResult);
    }

    private static async Task<AuthenticationResult> AuthenticateToServerAsync()
    {
        _authNetworkClient = new AuthNetworkClient(HOST, AUTH_PORT, USERNAME, PASSWORD);
        return await _authNetworkClient.AuthenticateAsync();
    }

    private static async Task<Realm?> SelectRealmAsync()
    {
        if (_authNetworkClient == null) return null;

        Realm[]? realms = await _authNetworkClient.GetRealmListAsync();
        if (realms == null || realms.Length == 0)
        {
            Log.Error("Échec de la récupération de la liste des royaumes.");
            return null;
        }

        Log.Success($"Récupération de la liste des royaumes réussie. Nombre de royaumes : {realms.Length}");
        Realm realm = realms.First();
        Log.Info($"Sélection du royaume : {realm.Name}, IP : {realm.Address}, Port : {realm.Port}");

        return realm;
    }

    private static async Task ConnectToWorldAsync(Realm realm, AuthenticationResult authResult)
    {
        if (_worldState == null) return;

        _worldNetworkClient = new WorldNetworkClient(
            realm.Address,
            realm.Port,
            realm.Id,
            authResult.Username,
            authResult.SessionKey.ToCleanByteArray(),
            _worldState.GetWorldStateEventBus()
        );

        ConfigureWorldClientEvents();

        if (!await _worldNetworkClient.AuthenticateAsync())
        {
            Log.Error("Échec de l'authentification au royaume.");
            return;
        }

        Log.Success("Authentification au royaume réussie.");
        await SelectAndLoginCharacterAsync();
    }

    private static void ConfigureWorldClientEvents()
    {
        if (_worldNetworkClient == null) return;

        _worldNetworkClient.Connected += () => Log.Success("Connecté au royaume.");
        _worldNetworkClient.Disconnected += () => Log.Error("Déconnecté du royaume.");
    }

    private static async Task SelectAndLoginCharacterAsync()
    {
        if (_worldNetworkClient == null) return;

        Character[] characters = await _worldNetworkClient.GetCharacterListAsync();
        if (characters.Length == 0)
        {
            Log.Warn("Aucun personnage trouvé sur ce compte.");
            return;
        }

        DisplayCharacters(characters);

        Character selectedCharacter = characters.First();
        bool loggedIn = await _worldNetworkClient.LoginCharacter(selectedCharacter.Guid);

        if (loggedIn)
            Log.Success($"Connecté au personnage : {selectedCharacter.Name}");
        else
            Log.Error($"Échec de la connexion au personnage : {selectedCharacter.Name}");
    }

    private static void DisplayCharacters(Character[] characters)
    {
        foreach (Character character in characters) Log.Info($"Personnage : {character.Name}, Niveau : {character.Level}, Classe : {character.Class}");
    }

    private static void WaitForQuitCommand()
    {
        while (System.Console.ReadKey(true).Key != ConsoleKey.Q) Task.Delay(100).Wait();
    }

    private static async Task DisconnectAsync()
    {
        if (_authNetworkClient != null)
        {
            await _authNetworkClient.DisconnectAsync();
            _authNetworkClient.Dispose();
        }

        if (_worldNetworkClient != null)
        {
            await _worldNetworkClient.DisconnectAsync();
            _worldNetworkClient.Dispose();
        }
    }
}