using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logicify.SEL.Exceptions
{
    public class SELException: Exception
    {
        public SELException(string message) : base(message)
        {
        }

        public SELException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
