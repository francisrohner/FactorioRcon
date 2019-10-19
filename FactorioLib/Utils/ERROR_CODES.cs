using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactorioLib.Utils
{
    public enum ERROR_CODES
    {        
        INCORRECT_PASSWORD = -5,
        EMPTY_MESSAGE = -4,
        TRANSMIT_ERROR = -3,
        TIMEOUT = -2,
        FAILURE = -1,
        UNSUPPORTED = 0,
        SUCCESS = 1
    }
}
