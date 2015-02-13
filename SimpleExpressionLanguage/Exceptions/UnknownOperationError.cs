using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logicify.SEL.Exceptions
{
    class UnknownOperationError : SELException
    {        

        public UnknownOperationError(string operationName) : base("Operation or variable " + operationName + " is not available in this context")
        {
        }

        public UnknownOperationError(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
