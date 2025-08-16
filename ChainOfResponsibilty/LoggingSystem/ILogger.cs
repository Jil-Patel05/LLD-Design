using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OOPS_Practise.ChainOfResponsibilty.LoggingSystem
{
    public class LogMessage
    {
        private string message;
        private string logLevel;
        private string currentTime;
        public void setMessage(string message)
        {
            this.message = message;
        }
        public string getMessage()
        {
            return this.message;
        }
        public void setLogLevel(LogType type)
        {
            switch (type)
            {
                case LogType.INFO:
                    this.logLevel = "INFO";
                    break;
                case LogType.DEBUG:
                    this.logLevel = "DEBUG";
                    break;
                case LogType.ERROR:
                    this.logLevel = "ERROR";
                    break;
                default:
                    this.logLevel = "WARNING";
                    break;
            }

        }
        public string getLogLevel()
        {
            return this.logLevel;
        }
        public void setCurrentTime()
        {
            this.currentTime = DateTime.Now.ToString();
        }
        public string getCurrentTime()
        {
            return this.currentTime;
        }

    }
    public enum LogType
    {
        INFO,
        DEBUG,
        ERROR,
        WARNING
    }
    public interface ILogger
    {
        public string log(LogType type, string message);

    }

    public class InfoLogger : ILogger
    {
        ILogger nextLogger;
        LogMessage m;
        public InfoLogger(ILogger logger)
        {
            m = new LogMessage();
            m.setLogLevel(LogType.INFO);
            this.nextLogger = logger;
        }
        public string log(LogType type, string message)
        {
            if (type == LogType.INFO)
            {
                m.setMessage(message);
                m.setCurrentTime();
                return m.getCurrentTime() + " " + m.getLogLevel() + " " + m.getMessage();
            }
            else
            {
                return this.nextLogger.log(type, message);
            }
        }
    }
    public class ErrorLogger : ILogger
    {
        ILogger nextLogger;
        LogMessage m;
        public ErrorLogger(ILogger logger)
        {
            m = new LogMessage();
            m.setLogLevel(LogType.ERROR);
            this.nextLogger = logger;
        }
        public string log(LogType type, string message)
        {
            if (type == LogType.ERROR)
            {
                m.setMessage(message);
                m.setCurrentTime();
                return m.getCurrentTime() + " " + m.getLogLevel() + " " + m.getMessage();
            }
            else
            {
                return this.nextLogger.log(type, message);
            }
        }
    }
    public class DebugLogger : ILogger
    {
        ILogger nextLogger;
        LogMessage m;
        public DebugLogger(ILogger logger)
        {
            m = new LogMessage();
            m.setLogLevel(LogType.DEBUG);
            this.nextLogger = logger;
        }
        public string log(LogType type, string message)
        {
            if (type == LogType.DEBUG)
            {
                m.setMessage(message);
                m.setCurrentTime();
                return m.getCurrentTime() + " " + m.getLogLevel() + " " + m.getMessage();
            }
            else
            {
                return this.nextLogger.log(type, message);
            }
        }
    }
    public class WarningLogger : ILogger
    {
        LogMessage m;
        public WarningLogger()
        {
            m = new LogMessage();
            m.setLogLevel(LogType.WARNING);
        }
        public string log(LogType type, string message)
        {
            try
            {
                if (type == LogType.WARNING)
                {
                    m.setMessage(message);
                    m.setCurrentTime();
                    return m.getCurrentTime() + " " + m.getLogLevel() + " " + m.getMessage();

                }
                else
                {
                    throw new Exception("Log type is not matched with any logger, Please check it again.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"New error: {ex}");
            }
            return "Log level is not executed";
        }
    }
}