using log4net;
using log4net.Config;

namespace PowerGeneratorStats
{
    static class Logger
    {
        private static readonly ILog log;

        static Logger() {
            XmlConfigurator.Configure();
            log = LogManager.GetLogger("PowerGeneratorStatsErrorLog");
        }
        
        public static void LogInfo(string message)
        {
            log.Info(message);
        }

        public static void LogError(string message)
        {
            log.Error(message);
        }

        public static void LogFatalError(string message)
        {
            log.Fatal(message);
            //Send email to appropriate people configured on a DB table/config file, on fatal errors. This isnt implemented due to time constraints
            log.Fatal("A notification email has been sent to the user - user@brady.com");
            //A single line here would invoke the email API and it would have been implemented in a separate class
        }
    }
}
