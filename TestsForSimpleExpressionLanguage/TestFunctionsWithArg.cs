using Logicify.SEL.Handlers;
using Logicify.SEL.Impl;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestsForSimpleExpressionLanguage
{
    [TestClass]
    public class TestFunctionsWithArg
    {
        [TestMethod]
        public void Function_with_arg_should_be_evaluated()
        {
            DefaultExpressionEvaluator evaluator = new DefaultExpressionEvaluator();
            evaluator.Context.RegisterValue("myVar", "SomeVal");
            evaluator.Context.RegisterHandler(new CapitalizeHandler());
            var res = evaluator.Evaluate("Result: $upper(test).");
            Assert.AreEqual("Result: TEST.", res);
        }

        [TestMethod]
        public void Function_with_arg_should_be_evaluated_when_argument_is_expression()
        {
            DefaultExpressionEvaluator evaluator = new DefaultExpressionEvaluator();
            evaluator.Context.RegisterValue("myVar", "SomeVal");
            evaluator.Context.RegisterHandler(new CapitalizeHandler());
            var res = evaluator.Evaluate("Result: $upper($myVar).");
            Assert.AreEqual("Result: SOMEVAL.", res);
        }

        [TestMethod]
        public void Function_with_arg_should_be_evaluated_when_argument_contains_expression()
        {
            DefaultExpressionEvaluator evaluator = new DefaultExpressionEvaluator();
            evaluator.Context.RegisterValue("myVar", "SomeVal");
            evaluator.Context.RegisterHandler(new CapitalizeHandler());
            var res = evaluator.Evaluate("Result: $upper(This is $myVar).");
            Assert.AreEqual("Result: THIS IS SOMEVAL.", res);
        }
        
    }

}
