using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Logicify.SEL.Common;
using Logicify.SEL.Exceptions;

namespace Logicify.SEL.Handlers
{
    public class ValueHandler: BaseExpressionHandler
    {
        private string _name;
        private object _value;

        public override string Name { get { return _name; } }

        public object ParseArgument(object rawArgumentValue)
        {
            if (rawArgumentValue != null)
            {
                throw new SELSyntaxError(_name + " shouldn't get any arguments");
            }
            return null;
        }

        public override Object Invoke(object argument, IExpressionContext context)
        {            
            return _value;
        }

        public ValueHandler(string name, Object value)
        {
            _name = name;
            _value = value;
        }
    }
}
