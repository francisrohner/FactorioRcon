using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactorioLib.Logging
{
    public interface ILogger
    {
        void LogError(string tag, string msg);
        void LogError(string tag, string msg, int level);
        void LogInfo(string tag, string msg);
        void LogWarning(string tag, string msg);        
    }
}
