using NLog;
using Task.Contracts.Interfaces;

namespace Task.Services.Services
{
    public class LoggerManagerService : ILoggerManager
    {
        private static ILogger _logget;

        public LoggerManagerService()
        {
            _logget = LogManager.GetCurrentClassLogger();
        }

        public void LogInfo(string message)
        {
            _logget.Info(message);
        }

        public void LogWarn(string message)
        {
            _logget.Warn(message);
        }

        public void LogDebug(string message)
        {
            _logget.Debug(message);
        }

        public void LogError(string message)
        {
            _logget.Error(message);
        }
    }
}