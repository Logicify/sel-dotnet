using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logicify.SEL.Exceptions
{
    public class SELSyntaxError: SELException
    {
        public SELSyntaxError(string message) : base(message)
        {
        }

        public SELSyntaxError(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
