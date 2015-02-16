using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Logicify.SEL.Common
{
    public interface IHandlerLibrary
    {
        string Name { get; }
        /// <summary>
        /// Registres library in given expression context
        /// </summary>
        /// <param name="context"></param>
        void Register(IExpressionContext context);
    }
}
