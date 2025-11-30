using Microsoft.Extensions.Logging;
using System;

namespace BackendDemo.Infrastructure.Logging
{
    public sealed class FileLoggerProvider : ILoggerProvider
    {
        private readonly Func<string> _getFilePath;

        public FileLoggerProvider(string baseLogPath)
        {
            _getFilePath = () =>
            {
                var date = DateTime.Now.ToString("yyyy-MM-dd");
                return Path.Combine(baseLogPath, $"log-{date}.txt");
            };
        }

        public ILogger CreateLogger(string categoryName)
        {
            return new FileLogger(categoryName, _getFilePath);
        }

        public void Dispose() { }
    }
}