using FactorioLib.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactorioLib.Logging
{
    public class FileLogger : ILogger
    {
        public string FilePath { get; set; }
        private StreamWriter writer;

        public FileLogger()
        {
            int ec = FileSystemUtils.GetProgramDataPath(out string path);            
            if(ec > 0)
            {
                FilePath = path + @"\" + FileSystemUtils.GetDateTimeStr() + ".txt";
                try
                {
                    writer = new StreamWriter(FilePath);
                }
                catch
                {
                    //TODO WARN IN UI
                    writer = null;
                }
            }
            else //Unable to create directory under program data 
            {
                //TODO WARN IN UI
            }
            
        }
        public FileLogger(string filePath)
        {
            FilePath = filePath;
            try
            {
                writer = new StreamWriter(FilePath);
            }
            catch
            {
                writer = null;
                //TODO WARN IN UI
            }
        }
        
        private string _GenLine(string type, string tag, string msg)
        {
            return _GenLine(type, tag, msg, 0);
        }
        private string _GenLine(string type, string tag, string msg, int level)
        {
            string dt_str = DateTime.Now.ToString("YYYY-MM-dd HH:mm:ss.fff");
            return string.Format("[{0}|{1}|{2}]: {3} ==> {4}", type, dt_str, level, tag, msg);
        }

        public void LogError(string tag, string msg)
        {
            string line_out = string.Empty;
            //[ERROR|2019-04-06 14:12:13.100|0]: TAG ==> CONTENT
            //Ex:
            ////[ERROR|2019-04-06 14:12:13.100|0]: FileSystemUtils::FcnName ==> CONTENT
            writer.WriteLine(_GenLine("ERROR", tag, msg));
            writer.Flush(); //flush to disk
        }

        public void LogError(string tag, string msg, int level)
        {
            writer.WriteLine(_GenLine("ERROR", tag, msg, level));
            writer.Flush(); //flush to disk
        }

        public void LogInfo(string tag, string msg)
        {
            writer.WriteLine(_GenLine("INFO", tag, msg));
            writer.Flush(); //flush to disk
        }

        public void LogWarning(string tag, string msg)
        {
            writer.WriteLine(_GenLine("WARNING", tag, msg));
            writer.Flush(); //flush to disk
        }
    }
}
