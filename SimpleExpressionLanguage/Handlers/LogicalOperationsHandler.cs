using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logicify.SEL.Common;

namespace Logicify.SEL.Handlers
{
    /// <summary>
    /// Expects to get the list of comma delimited BOOLEAN values. 
    /// Returns TRUE or False according to type
    /// </summary>
    public abstract class LogicalOperationsHandler: BaseExpressionHandler
    {
        
        /// <summary>
        /// It should be comma delimited list of boolean values. Like "true, false, false"
        /// </summary>
        /// <param name="rawArgumentValue"></param>
        /// <returns></returns>
        public override object ParseArgument(object rawArgumentValue)
        {
            ValueIsRequired(rawArgumentValue);
            ValueShouldBeAString(rawArgumentValue);
            List<bool> parsedValues = new List<bool>();
            try
            {
                foreach (string val in rawArgumentValue.ToString().Split(','))
                {
                    parsedValues.Add(Convert.ToBoolean(val));
                }
            }
            catch (FormatException e)
            {
                SyntaxError("All arguments should be boolean. Got: " + rawArgumentValue);
            }
            return parsedValues;
        }
        
    }

    public class LogicalConjunctionHandler : LogicalOperationsHandler
    {
        public override string Name { get { return "allOf"; } }
        public override IEnumerable<string> Aliases { get { return new String[] {"all"}; } }

        public override object Invoke(object argument, IExpressionContext context)
        {
            List<bool> values = argument as List<bool>;
            return !values.Contains(false);
        }
    }

    public class LogicalDisjunctionHandler : LogicalOperationsHandler
    {
        public override string Name { get { return "anyOf"; } }
        public override IEnumerable<string> Aliases { get { return new String[] { "any" }; } }

        public override object Invoke(object argument, IExpressionContext context)
        {
            List<bool> values = argument as List<bool>;
            return values.Contains(true);
        }
    }

    public class LogicalNotHandler : BaseExpressionHandler
    {
        public override string Name { get { return "not"; } }

        public override object ParseArgument(object rawArgumentValue)
        {
            ValueIsRequired(rawArgumentValue);
            if (rawArgumentValue is bool) return rawArgumentValue;
            if (rawArgumentValue is string)
            {
                try
                {
                    return Convert.ToBoolean(rawArgumentValue);
                }
                catch (FormatException e)
                {
                    SyntaxError("Argument value should be boolean");
                }
            }
            else
            {
                SyntaxError("Argument value should be boolean");
            }
            return rawArgumentValue;
        }

        public override object Invoke(object argument, IExpressionContext context)
        {            
            return !((bool)argument);
        }
    }
}
