namespace TrinityCore._3._3._5.ClientLibrary.Shared.Logger;

public class ConsoleLogger : ILog
{
    private readonly object _lockObject = new();

    private readonly Queue<ConsoleItem> _queue = new();

    public void Debug(string message)
    {
        lock (_lockObject)
        {
            _queue.Enqueue(new ConsoleItem(ConsoleColor.DarkGray, message));
            Process();
        }
    }

    public void Info(string message)
    {
        lock (_lockObject)
        {
            _queue.Enqueue(new ConsoleItem(ConsoleColor.White, message));
            Process();
        }
    }

    public void Warn(string message)
    {
        lock (_lockObject)
        {
            _queue.Enqueue(new ConsoleItem(ConsoleColor.Yellow, message));
            Process();
        }
    }

    public void Error(string message)
    {
        lock (_lockObject)
        {
            _queue.Enqueue(new ConsoleItem(ConsoleColor.Red, message));
            Process();
        }
    }

    public void Success(string message)
    {
        lock (_lockObject)
        {
            _queue.Enqueue(new ConsoleItem(ConsoleColor.Green, message));
            Process();
        }
    }

    private void Process()
    {
        while (_queue.Count > 0)
        {
            Console.ResetColor();
            ConsoleItem item = _queue.Dequeue();
            Console.ForegroundColor = item.GetColor();
            Console.WriteLine(item.GetMessage());
            Console.ResetColor();
        }
    }

    private class ConsoleItem
    {
        private readonly ConsoleColor _color;
        private readonly string _message;

        public ConsoleItem(ConsoleColor color, string message)
        {
            _color = color;
            _message = message;
        }

        public ConsoleColor GetColor()
        {
            return _color;
        }

        public string GetMessage()
        {
            return _message;
        }
    }
}