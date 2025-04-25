namespace TrinityCore._3._3._5.ClientLibrary.Shared.Logger;

public static class Log
{
    private static ILog? _logger;
    private static int _logLevel;

    public static void SetLogger(ILog log)
    {
        _logger = log;
    }

    public static void SetLogLevel(LogLevel value)
    {
        _logLevel = (int)value;
    }

    public static void Debug(string message)
    {
        if (_logger == null) return;
        if (_logLevel > (int)LogLevel.Debug) return;
        _logger.Debug(message);
    }

    public static void Info(string message)
    {
        if (_logger == null) return;
        if (_logLevel > (int)LogLevel.Info) return;
        _logger.Info(message);
    }

    public static void Warn(string message)
    {
        if (_logger == null) return;
        if (_logLevel > (int)LogLevel.Warning) return;
        _logger.Warn(message);
    }

    public static void Error(string message)
    {
        if (_logger == null) return;
        if (_logLevel > (int)LogLevel.Error) return;
        _logger.Error(message);
    }

    public static void Success(string message)
    {
        if (_logger == null) return;
        if (_logLevel > (int)LogLevel.Success) return;
        _logger.Success(message);
    }
}