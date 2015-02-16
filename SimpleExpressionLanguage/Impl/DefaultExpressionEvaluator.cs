using System;
using System.Text.RegularExpressions;
using Logicify.SEL.Common;
using Logicify.SEL.Exceptions;

namespace Logicify.SEL.Impl
{
    public class DefaultExpressionEvaluator: IExpressionEvaluator
    {
        private IExpressionContext _context;
        private readonly Regex EXPRESSION_REGEX = new Regex(@"\$(?<name>\w[\d\w]*)(?<is_func>\((?<arg>.*)?\))?");

        public IExpressionContext Context
        {
            get { return _context; }            
        }


        public Object Evaluate(string expression, IExpressionContext localContext = null)
        {
            return Evaluate(expression, localContext, 0);
        }

        private Object Evaluate(Object expression, IExpressionContext localContext, int recursionLevel)
        {
            // if expression is not a string - nothing to evaluate
            if (expression == null) return null;
            if (expression.GetType() != typeof(String)) return expression;            
            // Merge localcontext with global.
            // If there is no local context - use global           
            IExpressionContext expressionContext;
            if (localContext == null)
            {
                localContext = Context;
            }
            if (localContext != null && localContext != Context && recursionLevel == 0)
            {
                localContext.Inherit(Context);                
            }
            expressionContext = localContext;
            Object result = expression;
            Match match = EXPRESSION_REGEX.Match(expression.ToString()); // It is safe enough to cast since we allready detected expression type
            while (match.Success)
            {
                Object expressionValue = null;
                String expressionName = match.Groups["name"].Value;
                IExpressionHandler handler = expressionContext.GetFunctionHandlerByName(expressionName);
                Object argument = null;
                // If there is an argument
                if (match.Groups["is_func"].Success)
                {
                    // Apply interpolation to the argument
                    argument = Evaluate(match.Groups["arg"].Value, localContext, recursionLevel + 1);                    
                    // Validate it
                    try
                    {
                        argument = handler.ParseArgument(argument);
                    }
                    catch (SELSyntaxError e)
                    {
                        throw new SELSyntaxError(String.Format("Invalid argument for expression {0} in position {1}: {2}",
                            match.Value, match.Groups["arg"].Index, e.Message), e);
                    }
                    
                }
                expressionValue = handler.Invoke(argument, localContext);
                // If expression is int the root of out syntax try result shouldn't be serializaed and interpolated.
                if (result is string && result.ToString().Length == match.Length)
                {
                    result = expressionValue;
                    break;
                }
                else if (result is string)
                {                    
                    result = result.ToString().Remove(match.Index, match.Length).Insert(match.Index, expressionValue != null ? expressionValue.ToString() : "");
                    match = EXPRESSION_REGEX.Match(result.ToString());
                }
                else
                {
                    result = expressionValue;
                    break;
                }                               
            }
            return result;
        }

        public DefaultExpressionEvaluator(IExpressionContext context)
        {
            _context = context;
        }

        public DefaultExpressionEvaluator()
            : this(new DefaultExpressionContext())
        {
        }
    }
}
