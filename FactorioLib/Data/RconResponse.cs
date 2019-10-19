using FactorioLib.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactorioLib.Data
{

    public class RconResponse
    {
        public enum Type
        {
            RESPONSE_VALUE = 0,
            AUTH_RESPONSE = 2,
            NONE = 255,
            EMPTY = -1
        }
        
        [Browsable(false)]
        public byte[] Raw { get; }
        public int RequestId { get; }
        public Type ResponseType { get; }
        public string Message { get; }
        //public string ExtraData { get; }

        protected RconResponse()
        {
            Raw = new byte[0];
            RequestId = -1;
            ResponseType = Type.EMPTY;
        }
        protected RconResponse(byte[] raw, int requestId, Type type, string message)
        {
            Raw = raw;
            RequestId = requestId;
            ResponseType = type;
            Message = message;
        }
        public static int FromBytes(byte[] data, out RconResponse response)
        {
            int ret = (int)ERROR_CODES.FAILURE;            
            int requestId = -1;
            Type type = Type.EMPTY;
            string message = string.Empty;

            if (data == null || data.Length == 0)
            {
                response = new RconResponse();
                ret = (int)ERROR_CODES.EMPTY_MESSAGE;
            }            
            try
            {
                using (MemoryStream stream = new MemoryStream(data))
                {                    
                    int length = Int32FromStream(stream); //4
                    requestId = Int32FromStream(stream); //4
                    type = (Type)Int32FromStream(stream); //4
                    message = StringFromStream(stream); //X
                }
                ret = (int)ERROR_CODES.SUCCESS;
            }
            catch(Exception ex)
            {
                Trace.WriteLine(ex);
            }
            response = new RconResponse(data, requestId, type, message);
            return ret;
        }

        private static string StringFromStream(Stream stream)
        {
            string ret = string.Empty;
            byte[] buf = new byte[4096];
            //while(stream.Read(buf, 0, ))
            using (MemoryStream ms = new MemoryStream())
            {
                while (stream.Position < stream.Length)
                {
                    int bytesRead = stream.Read(buf, 0, buf.Length);
                    if (bytesRead > 0)
                    {
                        ms.Write(buf, 0, bytesRead);
                    }

                    if (bytesRead == 0 || buf[bytesRead - 1] == 0)
                    {
                        break;
                    }                    
                }
                ret = Encoding.UTF8.GetString(ms.ToArray());
            }
            return ret;
        }

        private static int Int32FromStream(Stream stream)
        {
            byte[] buf = new byte[4];
            stream.Read(buf, 0, buf.Length);
            return BitConverter.ToInt32(buf, 0);
        }
        
    }
}
