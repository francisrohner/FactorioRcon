using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactorioLib.Utils
{
    public static class FileSystemUtils
    {
        public static int GetTempPath(out string path)
        {
            int ret = (int)ERROR_CODES.FAILURE;
            //%USERPROFILE%\AppData\Local\Temp\FactorioRcon
            path = string.Empty;
            string appdata_local = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            path = appdata_local + @"\Temp\" + Globals.APP_NAME;
            try
            {
                if (!Directory.Exists(path)) Directory.CreateDirectory(path);
                ret = (int)ERROR_CODES.SUCCESS;
            } catch{}
            return ret;
        }
        public static int GetProgramDataPath(out string path)
        {
            int ret = (int)ERROR_CODES.FAILURE;
            path = string.Empty;
            string pdata = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData);
            try
            {
                if (!Directory.Exists(path)) Directory.CreateDirectory(path);
                ret = (int)ERROR_CODES.SUCCESS;
            }
            catch { }

            return ret;
        }
        public static string GetDateTimeStr()
        {
            return GetDateTimeStr(DateTime.Now);
        }
        public static string GetDateTimeStr(DateTime dateTime)
        {
            return dateTime.ToString("yyyy-mm-dd__HH-mm-ss-fff");
        }
    }
}
