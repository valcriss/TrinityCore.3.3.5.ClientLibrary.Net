using TrinityCore._3._3._5.ClientLibrary.Client;
using TrinityCore._3._3._5.ClientLibrary.Shared.Logger;

namespace TrinityCore._3._3._5.ClientLibrary.Console;

internal class Program
{
    private const string HOST = "127.0.0.1";
    private const string USERNAME = "test";
    private const string PASSWORD = "test";
    private const string DBC_PATH = @"D:\Développement\clientdata\3.3.5\dbc";
    private const LogLevel LOG_LEVEL = LogLevel.INFO;

    private static GameClient? _gameClient;

    private static async Task Main(string[] args)
    {
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
        _gameClient = new GameClient(HOST, USERNAME, PASSWORD, DBC_PATH);
        await _gameClient.Connect();
    }

    private static void WaitForQuitCommand()
    {
        while (System.Console.ReadKey(true).Key != ConsoleKey.Q) Task.Delay(100).Wait();
    }

    private static async Task DisconnectAsync()
    {
        if (_gameClient != null) await _gameClient.Disconnect();
    }
}