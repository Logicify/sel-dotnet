using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logicify.SEL.Common
{
    public interface IExpressionContext: IEnumerable
    {
        void RegisterHandler(IExpressionHandler functionHandler);
        void RegisterValue(string name, Object value);
        void UpdateValue(string name, Object value);
        IExpressionHandler GetFunctionHandlerByName(string handlerName);        
        void Inherit(IExpressionContext parentContext);
    }
}
