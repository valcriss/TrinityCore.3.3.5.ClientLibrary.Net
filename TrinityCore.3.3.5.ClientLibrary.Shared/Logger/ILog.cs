namespace TrinityCore._3._3._5.ClientLibrary.Shared.Logger;

public interface ILog
{
    void Debug(string message);
    void Info(string message);
    void Warn(string message);
    void Error(string message);
    
    void Success(string message);
}