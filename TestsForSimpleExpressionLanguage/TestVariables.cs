using Logicify.SEL.Impl;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestsForSimpleExpressionLanguage
{
    [TestClass]
    public class TestVariables
    {
        [TestMethod]
        public void Handler_from_local_context_should_be_available()
        {
            DefaultExpressionEvaluator evaluator = new DefaultExpressionEvaluator();
            DefaultExpressionContext localContext = new DefaultExpressionContext();
            localContext.RegisterValue("myVar", "SomeVal");
            var res = evaluator.Evaluate("Value of myVar is $myVar.", localContext);
            Assert.AreEqual("Value of myVar is SomeVal.", res);
        }
    }
}
