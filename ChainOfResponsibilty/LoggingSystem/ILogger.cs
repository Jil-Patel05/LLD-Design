using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OOPS_Practise.ChainOfResponsibilty.LoggingSystem
{
    public enum LogType
    {
        INFO,
        DEBUG,
        ERROR,
        WARNING
    }
    public interface ILogger
    {
        public void log(LogType type, string message);

    }

    public class InfoLogger : ILogger
    {
        ILogger nextLogger;
        public InfoLogger(ILogger logger)
        {
            this.nextLogger = logger;
        }
        public void log(LogType type, string message)
        {
            if (type == LogType.INFO)
            {
                Console.WriteLine($"Info {message}");
            }
            else
            {
                this.nextLogger.log(type, message);
            }
        }
    }
    public class ErrorLogger : ILogger
    {
        ILogger nextLogger;
        public ErrorLogger(ILogger logger)
        {
            this.nextLogger = logger;
        }
        public void log(LogType type, string message)
        {
            if (type == LogType.ERROR)
            {
                Console.WriteLine($"Error {message}");
            }
            else
            {
                this.nextLogger.log(type, message);
            }
        }
    }
    public class DebugLogger : ILogger
    {
        ILogger nextLogger;
        public DebugLogger(ILogger logger)
        {
            this.nextLogger = logger;
        }
        public void log(LogType type, string message)
        {
            if (type == LogType.DEBUG)
            {
                Console.WriteLine($"Debug {message}");
            }
            else
            {
                this.nextLogger.log(type, message);
            }
        }
    }
    public class WarningLogger : ILogger
    {
        public void log(LogType type, string message)
        {
            try
            {
                if (type == LogType.WARNING)
                {
                    Console.WriteLine($"Warning {message}");
                }
                else
                {
                    throw new Exception("Log type is not matched with any logger, Please check it again.");
                }
            }
            catch (Exception ex) {
                Console.WriteLine($"New error: {ex}");
            }
        }
    }
}