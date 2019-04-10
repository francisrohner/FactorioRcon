using FactorioLib.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactorioLib.Data
{
    public enum RESPONSE_TYPE
    {
        RESPONSE_VALUE = 0,
        AUTH_RESPONSE = 2,
        NONE = 255
    }
    public class RconResponse
    {
        public int RequestId;
        public RESPONSE_TYPE ResponseType;
        public string Message;
        public string ExtraData;
        public static int FromBytes(byte[] data, out RconResponse response)
        {
            int ret = (int)ERROR_CODES.FAILURE;
            int off = 0; //offset
            response = new RconResponse();

            int length = BitConverter.ToInt32(data, 0);
            off += 4;
            try
            {
                response.RequestId = BitConverter.ToInt32(data, off);
                off += 4;

                response.ResponseType =
                    (RESPONSE_TYPE)BitConverter.ToInt32(data, off);
                off += 4;

                int[] zero_indices = new int[2];
                int zi_index = 0;
                for (int i = off; i < data.Length && zi_index < 2; i++)
                    if (data[i] == 0)
                        zero_indices[zi_index++] = i;

                response.Message =
                    Encoding.ASCII.GetString(data, off,
                    (zero_indices[0] - off));

                response.ExtraData =
                    Encoding.ASCII.GetString(data, zero_indices[0] + 1,
                    zero_indices[1] - zero_indices[0] - 1);
            }
            catch {}
            ret = (int)ERROR_CODES.SUCCESS;

            return ret;
        }
    }
}
