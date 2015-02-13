using System;
using System.Collections.Generic;


namespace Logicify.SEL.Common
{
    public interface IExpressionEvaluator
    {
        IExpressionContext Context { get; }
        Object Evaluate(string expression, IExpressionContext localContext = null);
    }
}
