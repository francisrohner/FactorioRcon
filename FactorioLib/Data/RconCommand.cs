using FactorioLib.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactorioLib.Data
{
    public enum COMMAND_TYPE
    {
        EXEC_CMD = 2,
        AUTH = 3,
        NONE = 255
    }
    public class RconCommand
    {
        public int RequestId;
        public COMMAND_TYPE CommandType;
        public string Message;
        public string ExtraData;
        
        public RconCommand(int requestId, string command)
        {
            RequestId = requestId;
            Message = command;
            ExtraData = string.Empty;
            CommandType = COMMAND_TYPE.EXEC_CMD;
        }

        public RconCommand(int requestId, string command, COMMAND_TYPE type)
        {
            RequestId = requestId;
            Message = command;
            ExtraData = string.Empty;
            CommandType = type;
        }

        public byte[] ToBytes()
        {
            byte[] buf;

            MemoryStream stream = new MemoryStream();
            //stream.WriteByte(0);
            stream.Write(BitConverter.GetBytes(RequestId), 0, 4);
            stream.Write(BitConverter.GetBytes((int)CommandType), 0, 4);
            buf = Encoding.ASCII.GetBytes(Message);            
            stream.Write(buf, 0, buf.Length);
            stream.WriteByte(0); //null char
            buf = Encoding.ASCII.GetBytes(ExtraData);
            stream.Write(buf, 0, buf.Length);
            stream.WriteByte(0); //null char
            //stream.Close();

            MemoryStream stream2 = new MemoryStream();
            byte[] len = BitConverter.GetBytes((int)stream.Length);
            stream2.Write(len, 0, len.Length);
            stream.Position = 0;
            stream.CopyTo(stream2);
            stream.Close();
            byte[] ret = stream2.ToArray();
            stream2.Close();
            return ret;
        }
    }
}
