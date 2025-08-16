using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OOPS_Practise.ChainOfResponsibilty.LoggingSystem
{
    public class Appender
    {
        // File, DB any out destinatio should be written here
        // Make use of strategy pattern here
        public Appender()
        {

        }
    }
    public class Logger
    {
        private static Logger instance;
        ILogger logger;
        private Logger()
        {
        }

        public static Logger getLoggerInstance()
        {
            if (instance == null)
            {
                return instance = new Logger();
            }
            return instance;
        }

        public void initializeLogger()
        {
            Console.WriteLine("initilization start");
            logger = new InfoLogger(new ErrorLogger(new DebugLogger(new WarningLogger())));
            Console.WriteLine("Logger is initialized");

        }
        public void setOutDestination()
        {
            // Change output strategies here using strategy pattern            
        }

        public void logMessage(LogType type, string message)
        {
            Console.WriteLine("Hey buddy here");
            string modifiedLogMessage = logger.log(type, message);
            Console.WriteLine(modifiedLogMessage);
            // Use appender to append message here
        }

    }
}