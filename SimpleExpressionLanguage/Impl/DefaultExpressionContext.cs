using System;
using System.Collections.Generic;
using Logicify.SEL.Common;
using Logicify.SEL.Exceptions;
using Logicify.SEL.Handlers;

namespace Logicify.SEL.Impl
{
    public class DefaultExpressionContext: IExpressionContext
    {
        private Dictionary<String, IExpressionHandler> _handlers = new Dictionary<string, IExpressionHandler>();

        public void RegisterHandler(IExpressionHandler functionHandler)
        {
            _handlers.Add(functionHandler.Name, functionHandler);
        }

        public void RegisterValue(string name, Object value)
        {
            RegisterHandler(new ValueHandler(name, value));
        }

        public IExpressionHandler GetFunctionHandlerByName(string handlerName)
        {
            if (!_handlers.ContainsKey(handlerName))
            {
                throw new UnknownOperationError(handlerName);
            }
            return _handlers[handlerName];
        }

        public DefaultExpressionContext()
        {
            // Put default handlers into the context
            RegisterHandler(new LogicalConjunctionHandler());
            RegisterHandler(new LogicalDisjunctionHandler());
            RegisterHandler(new LogicalNotHandler());
        }
    }
}
