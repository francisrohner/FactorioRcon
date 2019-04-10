using System;

namespace FactorioLib.Logging
{
    public class EventLogger : ILogger
    {
        public delegate void EventLoggerHandler(object sender, EventLoggerArgs e);
        public class EventLoggerArgs : EventArgs
        {
            public string type;
            public string tag;
            public string msg;
            public int level;
            public EventLoggerArgs(string type, string tag, string msg)
            {
                this.type = type;
                this.tag = tag;
                this.msg = msg;
            }
            public EventLoggerArgs(string type, string tag, string msg, int level)
            {
                this.type = type;
                this.tag = tag;
                this.msg = msg;
                this.level = level;
            }
        }

        public EventLoggerHandler OnError;
        public EventLoggerHandler OnInfo;
        public EventLoggerHandler OnWarning;        
        
        public void LogError(string tag, string msg)
        {
            //Note: For anyone reading the code the ?. is syntactic sugar for if(OnError != null) OnError.Invoke(this, ...)
            OnError?.Invoke(this, new EventLoggerArgs("ERROR", tag, msg)); 
        }

        public void LogError(string tag, string msg, int level)
        {
            OnError?.Invoke(this, new EventLoggerArgs("ERROR", tag, msg, level));
        }

        public void LogInfo(string tag, string msg)
        {
            OnInfo?.Invoke(this, new EventLoggerArgs("INFO", tag, msg));
        }

        public void LogWarning(string tag, string msg)
        {
            OnWarning?.Invoke(this, new EventLoggerArgs("WARNING", tag, msg));
        }
    }
}
