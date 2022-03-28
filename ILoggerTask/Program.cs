using System;

namespace ILoggerTask
{
    class Program
    {
        private const string location = @"c:\p\test.txt";
        static void Main()
        {
            var intLog = new LocalFileLogger<int>(location);
            intLog.LogInfo("Testing Info with int");
            intLog.LogWarning("Testing Warning with int");
            intLog.LogError("Testing Error with int",
                new Exception("Testing Exception with int"));

            var structLog = new LocalFileLogger<Person>(location);
            structLog.LogInfo("Testing Info with struct");
            structLog.LogWarning("Testing Warning with struct");
            structLog.LogError("Testing Error with struct",
                new Exception("Testing Exception with struct"));

            var stringLog = new LocalFileLogger<string>(location);
            stringLog.LogInfo("Testing Info with string");
            stringLog.LogWarning("Testing Warning with string");
            stringLog.LogError("Testing Error with string",
                new Exception("Testing Exception with string"));

            var classLog = new LocalFileLogger<Student>(location);
            classLog.LogInfo("Testing Info with class");
            classLog.LogWarning("Testing Warning with class");
            classLog.LogError("Testing Error with class",
                new Exception("Testing Exception with class"));
        }
    }

    public interface ILogger
    {
        void LogInfo(string message);
        void LogWarning(string message);
        void LogError(string message, Exception ex);
    }
}
