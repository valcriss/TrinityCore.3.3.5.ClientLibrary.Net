using TrinityCore._3._3._5.ClientLibrary.AuthNetwork;
using TrinityCore._3._3._5.ClientLibrary.AuthNetwork.Models.Results;
using TrinityCore._3._3._5.ClientLibrary.Network.Core;
using TrinityCore._3._3._5.ClientLibrary.Network.Core.Tools;
using TrinityCore._3._3._5.ClientLibrary.Shared.Logger;
using TrinityCore._3._3._5.ClientLibrary.WorldNetwork;
using TrinityCore._3._3._5.ClientLibrary.WorldNetwork.Models.Enums;
using TrinityCore._3._3._5.ClientLibrary.WorldNetwork.Models.Results;

namespace TrinityCore._3._3._5.ClientLibrary.Console
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            Log.SetLogger(new ConsoleLogger());
            Log.SetLogLevel(LogLevel.Info);
            Log.Success("Démarrage du client AuthNetwork...");

            AuthNetworkClient authNetworkClient = new("127.0.0.1", 3724, "daniel", "daniel");
            AuthenticationResult authentication = await authNetworkClient.AuthenticateAsync();

            if (authentication.IsAuthenticated)
            {
                Log.Success($"Authentifié avec succès. Bienvenue {authentication.Username}");
                Realm[]? realms = await authNetworkClient.GetRealmListAsync();
                if (realms != null)
                {
                    Log.Success($"Récupération de la liste des royaumes réussie. Nombre de royaumes : {realms.Length}");
                    Realm realm = realms.First();
                    Log.Info($"Sélection du royaume : {realm.Name}, IP : {realm.Address}, Port : {realm.Port}");
                    NetworkEventBus<WorldCommands> eventBus = new();
                    WorldNetworkClient worldNetworkClient = new(realm.Address, realm.Port, realm.Id, authentication.Username, authentication.SessionKey.ToCleanByteArray(), eventBus);
                    worldNetworkClient.Connected += () => Log.Success("Connecté au royaume.");
                    worldNetworkClient.Disconnected += () => Log.Error("Déconnecté du royaume.");
                    bool authenticate = await worldNetworkClient.AuthenticateAsync();
                    if (authenticate)
                    {
                        Log.Success("Authentification au royaume réussie.");
                        Character[] characters = await worldNetworkClient.GetCharacterListAsync();
                        foreach (Character character in characters)
                        {
                            Log.Info($"Personnage : {character.Name}, Niveau : {character.Level}, Classe : {character.Class}");
                        }
                    }
                    else
                    {
                        Log.Error($"Échec de l'authentification au royaume.");
                    }
                }
                else
                {
                    Log.Error("Échec de la récupération de la liste des royaumes.");
                }
            }
            else
            {
                Log.Error($"Échec d'authentification : {authentication.ConnexionResult}");
            }

            while (System.Console.ReadKey(true).Key != ConsoleKey.Q)
            {
                await Task.Delay(100);
            }

            await authNetworkClient.DisconnectAsync();
        }
    }
}