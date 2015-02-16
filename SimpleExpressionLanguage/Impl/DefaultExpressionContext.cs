using System;
using System.Collections;
using System.Collections.Generic;
using Logicify.SEL.Common;
using Logicify.SEL.Exceptions;
using Logicify.SEL.Handlers;

namespace Logicify.SEL.Impl
{
    public class DefaultExpressionContext: IExpressionContext
    {
        private Dictionary<String, IExpressionHandler> _handlers = new Dictionary<string, IExpressionHandler>();
        private IExpressionContext _parentContext;

        public void RegisterHandler(IExpressionHandler functionHandler)
        {
            if (!_handlers.ContainsKey(functionHandler.Name))
            {
                _handlers.Add(functionHandler.Name, functionHandler);
            }
            foreach (var expressionHandler in _handlers)
            {
                if (!_handlers.ContainsKey(expressionHandler.Key))
                {
                    _handlers.Add(expressionHandler.Key, expressionHandler.Value);
                }
            }
        }

        public void RegisterValue(string name, Object value)
        {
            RegisterHandler(new ValueHandler(name, value));
        }

        public IExpressionHandler GetFunctionHandlerByName(string handlerName)
        {
            if (!_handlers.ContainsKey(handlerName))
            {
                if (_parentContext != null)
                {
                    return _parentContext.GetFunctionHandlerByName(handlerName);
                }                
                throw new UnknownOperationError(handlerName);
            }
            return _handlers[handlerName];
        }

        public void Inherit(IExpressionContext parentContext)
        {
            _parentContext = parentContext;
        }


        public DefaultExpressionContext()
        {
            // Put default handlers into the context
            RegisterHandler(new LogicalConjunctionHandler());
            RegisterHandler(new LogicalDisjunctionHandler());
            RegisterHandler(new LogicalNotHandler());
        }
        

        public IEnumerator GetEnumerator()
        {
            return _handlers.GetEnumerator();
        }
    }
}
