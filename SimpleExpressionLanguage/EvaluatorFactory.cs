using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logicify.SEL.Common;
using Logicify.SEL.Handlers;
using Logicify.SEL.Impl;

namespace Logicify.SEL
{
    public class EvaluatorFactory
    {

        private IExpressionEvaluator _evaluator;

        public EvaluatorFactory()
        {
            _evaluator = new DefaultExpressionEvaluator();
        }

        public EvaluatorFactory AddLibrary(IHandlerLibrary library)
        {
            library.Register(_evaluator.Context);
            return this;
        }

        public EvaluatorFactory AddLogicalOperationsSupport()
        {
            AddLibrary(new LogicalOperationsLibrary());
            return this;
        }

        public EvaluatorFactory AddStringFunctionsSupportSupport()
        {
            AddLibrary(new StringFunctionsLibrary());
            return this;
        }

        public IExpressionEvaluator Build()
        {
            return _evaluator;
        }

        public static IExpressionEvaluator CreateDefault()
        {
            return new EvaluatorFactory().AddLogicalOperationsSupport().Build();
        }
    }
}
