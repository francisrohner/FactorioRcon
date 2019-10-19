using FactorioLib.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactorioLib.Data
{
    public enum CommandType
    {
        EXEC_CMD = 2,
        AUTH = 3,
        NONE = 255
    }
    public class RconCommand
    {
        private static int CurentRequestId = 0;

        public int RequestId { get; }
        public CommandType CommandType { get; }
        public string Message { get; }

        [Browsable(false)]
        public byte[] Raw { get; }
        public string Hex => Helper.ToHex(Raw);
        public string CSV => Helper.ToByteCSV(Raw);

        public RconCommand(string command) : this(command, CommandType.EXEC_CMD)
        {            
        }

        public RconCommand(string command, CommandType type)
        {
            unsafe
            {
                ++CurentRequestId;
            }
            RequestId = CurentRequestId;
            Message = command;            
            CommandType = type;
            Raw = ToBytes();
        }

        private byte[] ToBytes()
        {
            byte[] ret, content;
            using (MemoryStream payload = new MemoryStream())
            {
                WriteInt32ToStream(payload, RequestId); //ID
                WriteInt32ToStream(payload, (int)CommandType); //Type
                WriteStringToStream(payload, Message); //Body
                payload.WriteByte(0); //Padding                
                content = payload.ToArray();
            }
            using(MemoryStream envelope = new MemoryStream())
            {
                envelope.Write(BitConverter.GetBytes(content.Length), 0, 4); //Size
                envelope.Write(content, 0, content.Length); //content
                ret = envelope.ToArray();
            }            
            return ret;
        }

        private void WriteInt32ToStream(Stream stream, int value)
        {
            stream.Write(BitConverter.GetBytes(value), 0, 4);
        }
        private void WriteStringToStream(Stream stream, string value)
        {
            byte[] buf = Encoding.UTF8.GetBytes(value);
            stream.Write(buf, 0, buf.Length);
            stream.WriteByte(0); //null terminate
        }
    }
}
