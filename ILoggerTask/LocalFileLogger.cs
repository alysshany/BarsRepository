using System;
using System.IO;

namespace ILoggerTask
{
    class LocalFileLogger<T> : ILogger
    {
        private string locationFile;

        public LocalFileLogger(string localFile)
        {
            this.locationFile = localFile;
        }

        public void LogInfo(string message)
        {
            File.AppendAllText(locationFile, $"[Info]: [{typeof(T).FullName}]:{message}" + '\n');
        }

        public void LogWarning(string message)
        {
            File.AppendAllText(locationFile, $"[Warning]: [{typeof(T).FullName}]: {message}" + '\n');
        }

        public void LogError(string message, Exception ex)
        {
            File.AppendAllText(locationFile, $"[Error]: [{typeof(T).FullName}]: {message}.{ex.Message}" + '\n');
        }
    }
}
