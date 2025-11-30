using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;

namespace BackendDemo.Infrastructure.Logging
{
    public static class LoggingExtensions
    {
        public static ILoggingBuilder AddFileLogging(this ILoggingBuilder builder, string folderPath)
        {
            Directory.CreateDirectory(folderPath);
            builder.AddProvider(new FileLoggerProvider(folderPath));
            return builder;
        }
    }
}