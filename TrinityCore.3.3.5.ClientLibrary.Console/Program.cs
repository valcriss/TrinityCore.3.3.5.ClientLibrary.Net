using TrinityCore._3._3._5.ClientLibrary.AuthNetwork;
using TrinityCore._3._3._5.ClientLibrary.AuthNetwork.Models.Results;
using TrinityCore._3._3._5.ClientLibrary.Shared.Logger;

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
            AuthenticationResult result = await authNetworkClient.AuthenticateAsync();

            if (result.IsAuthenticated)
            {
                Log.Success($"Authentifié avec succès. Bienvenue {result.AccountName}");
                RealmListResult? realms = await authNetworkClient.GetRealmListAsync();
                if (realms != null)
                {
                    Log.Success($"Récupération de la liste des royaumes réussie. Nombre de royaumes : {realms.Realms.Count}");
                    foreach (Realm realm in realms.Realms)
                    {
                        Log.Info($"Nom du royaume : {realm.Name}, IP : {realm.Address}, Port : {realm.Port}");
                    }
                }
                else
                {
                    Log.Error("Échec de la récupération de la liste des royaumes.");
                }
            }
            else
            {
                Log.Error($"Échec d'authentification");
            }
            
            while (System.Console.ReadKey(true).Key != ConsoleKey.Q)
            {
                await Task.Delay(100);
            }
            
            await authNetworkClient.DisconnectAsync();
        }
    }
}