using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactorioLib.Logging
{
    public class MultiLogger : ILogger
    {
        public List<ILogger> loggers;
        public MultiLogger()
        {
            loggers = new List<ILogger>();
        }
        public void AddLogger(ILogger logger)
        {
            loggers.Add(logger);
        }
        public void LogError(string tag, string msg)
        {
            foreach (ILogger logger in loggers)
                logger.LogError(tag, msg);
        }

        public void LogError(string tag, string msg, int level)
        {
            foreach (ILogger logger in loggers)
                logger.LogError(tag, msg, level);
        }

        public void LogInfo(string tag, string msg)
        {
            foreach (ILogger logger in loggers)
                logger.LogInfo(tag, msg);
        }

        public void LogWarning(string tag, string msg)
        {
            foreach (ILogger logger in loggers)
                logger.LogWarning(tag, msg);
        }
    }
}
