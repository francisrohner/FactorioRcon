using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactorioLib.Logging
{
    public class MultiLogger : ILogger
    {
        public List<ILogger> _loggers;
        public MultiLogger()
        {
            _loggers = new List<ILogger>();
        }
        public void AddLogger(ILogger logger)
        {
            _loggers.Add(logger);
        }
        public void LogError(string tag, string msg)
        {
            foreach (ILogger logger in _loggers)
                logger.LogError(tag, msg);
        }

        public void LogError(string tag, string msg, int level)
        {
            foreach (ILogger logger in _loggers)
                logger.LogError(tag, msg, level);
        }

        public void LogInfo(string tag, string msg)
        {
            foreach (ILogger logger in _loggers)
                logger.LogInfo(tag, msg);
        }

        public void LogWarning(string tag, string msg)
        {
            foreach (ILogger logger in _loggers)
                logger.LogWarning(tag, msg);
        }
    }
}
