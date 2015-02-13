using Logicify.SEL.Handlers;
using Logicify.SEL.Impl;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestsForSimpleExpressionLanguage
{
    [TestClass]
    public class TestLocigalOperations
    {
        [TestMethod]
        public void Disjunction_should_return_True_if_one_element_is_True()
        {
            DefaultExpressionEvaluator evaluator = new DefaultExpressionEvaluator();                        
            var res = evaluator.Evaluate("$anyOf(true, false, false)");
            Assert.AreEqual(true, res);
        }

        [TestMethod] public void Disjunction_should_return_True_if_all_elements_are_True()
        {
            DefaultExpressionEvaluator evaluator = new DefaultExpressionEvaluator();
            evaluator.Context.RegisterHandler(new LogicalDisjunctionHandler());
            var res = evaluator.Evaluate("$anyOf(true, true, true)");
            Assert.AreEqual(true, res);
        }

        [TestMethod]
        public void Disjunction_should_return_False_if_all_elements_are_False()
        {
            DefaultExpressionEvaluator evaluator = new DefaultExpressionEvaluator();            
            var res = evaluator.Evaluate("$anyOf(false, false, false)");
            Assert.AreEqual(false, res);
        }

        [TestMethod]
        public void Nested_logical_expressions_should_work()
        {
            DefaultExpressionEvaluator evaluator = new DefaultExpressionEvaluator();            
            var res = evaluator.Evaluate("$anyOf(false, $not(true), false)");
            Assert.AreEqual(false, res);
        }

        [TestMethod]
        public void Complex_logical_expression_should_work()
        {
            DefaultExpressionEvaluator evaluator = new DefaultExpressionEvaluator();
            evaluator.Context.RegisterValue("myVar", true);                  
            var res = evaluator.Evaluate("$anyOf($not($myVar), $myVar)");
            Assert.AreEqual(true, res);
        }
    }

    
}
