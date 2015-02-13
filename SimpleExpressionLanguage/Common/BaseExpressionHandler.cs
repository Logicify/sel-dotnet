using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logicify.SEL.Exceptions;

namespace Logicify.SEL.Common
{
    public abstract class BaseExpressionHandler : IExpressionHandler
    {
        private readonly List<string> _aliases = new List<string>();
        
        public abstract string Name { get; }
        public virtual IEnumerable<string> Aliases { get { return _aliases; } }

        public virtual object ParseArgument(object rawArgumentValue)
        {
            return rawArgumentValue;
        }
        public abstract object Invoke(object argument, IExpressionContext context);

        /// <summary>
        /// Throws syntax error with given message
        /// </summary>
        /// <param name="message"></param>
        protected void SyntaxError(string message)
        {
            throw new SELSyntaxError(message);
        }

        protected void ValueIsRequired(object val)
        {
            if (val == null)
            {
                throw new SELSyntaxError("Argument is required");
            }            
        }
        protected void ValueShouldBeAString(object val)
        {
            if (!(val is string))
            {
                throw new SELSyntaxError("Argument is required");
            }            
        }
    }
}
