using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logicify.SEL.Common;

namespace Logicify.SEL.Handlers
{
    public class LogicalOperationsLibrary : IHandlerLibrary
    {
        public string Name {
            get { return "LogicalOperations"; }
        }

        public void Register(IExpressionContext context)
        {
            context.RegisterHandler(new LogicalConjunctionHandler());
            context.RegisterHandler(new LogicalDisjunctionHandler());
            context.RegisterHandler(new LogicalNotHandler());
        }        
    }

    public class StringFunctionsLibrary : IHandlerLibrary
    {
        public string Name
        {
            get { return "StringFunctions"; }
        }

        public void Register(IExpressionContext context)
        {
            context.RegisterHandler(new CapitalizeHandler());
        }
    }
}
