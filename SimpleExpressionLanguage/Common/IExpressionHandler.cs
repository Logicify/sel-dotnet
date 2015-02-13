using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Logicify.SEL.Exceptions;

namespace Logicify.SEL.Common
{
    public interface IExpressionHandler
    {
        string Name { get; }
        IEnumerable<string> Aliases { get; }

        /// <summary>
        /// 
        /// </summary>
        /// <exception cref="SELSyntaxError">When argument is not valid for this handler</exception>
        /// <param name="rawArgumentValue"></param>
        object ParseArgument(object rawArgumentValue);

        Object Invoke(Object argument, IExpressionContext context);
    }
}
