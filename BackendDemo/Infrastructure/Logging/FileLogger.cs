using Microsoft.Extensions.Logging;
using System;
using System.IO;
using System.Text.Json;

namespace BackendDemo.Infrastructure.Logging
{
    public sealed class FileLogger : ILogger
    {
        private readonly string _category;
        private readonly Func<string> _getFilePath;
        private static readonly object _lockObj = new();

        public FileLogger(string category, Func<string> getFilePath)
        {
            _category = category;
            _getFilePath = getFilePath;
        }

        IDisposable ILogger.BeginScope<TState>(TState state) => NullScope.Instance;

        public bool IsEnabled(LogLevel logLevel) => true;

        public void Log<TState>(
            LogLevel logLevel,
            EventId eventId,
            TState state,
            Exception? exception,
            Func<TState, Exception?, string> formatter)
        {
            var log = new
            {
                Timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"),
                Level = logLevel.ToString(),
                Category = _category,
                Message = formatter(state, exception),
                Exception = exception?.ToString()
            };

            var json = JsonSerializer.Serialize(log);

            lock (_lockObj)
            {
                File.AppendAllText(_getFilePath(), json + Environment.NewLine);
            }
        }

        private sealed class NullScope : IDisposable
        {
            public static readonly NullScope Instance = new();
            public void Dispose() { }
        }
    }
}



















// using Microsoft.Extensions.Logging;
// using System;
// using System.IO;

// public class FileLogger : ILogger
// {
//     private readonly string _filePath;
//     private static readonly object _lockObj = new();

//     public FileLogger(string filePath)
//     {
//         _filePath = filePath;
//     }

//     // Implementación explícita de BeginScope para evitar el warning
//     IDisposable ILogger.BeginScope<TState>(TState state)
//     {
//         return NullScope.Instance;
//     }

//     public bool IsEnabled(LogLevel logLevel) => true;

//     public void Log<TState>(
//         LogLevel logLevel,
//         EventId eventId,
//         TState state,
//         Exception? exception,
//         Func<TState, Exception?, string> formatter)
//     {
//         var message = formatter(state, exception);

//         lock (_lockObj)
//         {
//             File.AppendAllText(_filePath,
//                 $"{DateTime.Now:yyyy-MM-dd HH:mm:ss.fff} [{logLevel}] {message}" +
//                 (exception != null ? $" | EXCEPTION: {exception}" : "") +
//                 Environment.NewLine);
//         }
//     }

//     private sealed class NullScope : IDisposable
//     {
//         public static readonly NullScope Instance = new();
//         public void Dispose() { }
//     }
// }




















// using Microsoft.Extensions.Logging;
// using System;
// using System.IO;

// namespace BackendDemo.Infrastructure.Logging
// {
//     public class FileLogger : ILogger
//     {
//         private readonly string _filePath;
//         private static object _lock = new object();
//         private readonly string _categoryName;

//         public FileLogger(string filePath, string categoryName)
//         {
//             _filePath = filePath;
//             _categoryName = categoryName;
//         }

//         public IDisposable BeginScope<TState>(TState state) => null!;

//         public bool IsEnabled(LogLevel logLevel) => true;

//         public void Log<TState>(
//             LogLevel logLevel,
//             EventId eventId,
//             TState state,
//             Exception? exception,
//             Func<TState, Exception?, string> formatter)
//         {
//             lock (_lock)
//             {
//                 Directory.CreateDirectory(Path.GetDirectoryName(_filePath)!);

//                 var message =
//                     $"{DateTime.Now:yyyy-MM-dd HH:mm:ss.fff} " +
//                     $"[{logLevel}] " +
//                     $"[{_categoryName}] " +
//                     $"{formatter(state, exception)}";

//                 if (exception != null)
//                 {
//                     message += Environment.NewLine + exception.ToString();
//                 }

//                 File.AppendAllText(_filePath, message + Environment.NewLine);
//             }
//         }
//     }
// }