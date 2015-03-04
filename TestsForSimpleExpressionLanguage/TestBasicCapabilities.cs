using System;
using Logicify.SEL.Impl;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestsForSimpleExpressionLanguage
{
    [TestClass]
    public class TestBasicCapabilities
    {
        /// <summary>
        /// sadasdsad
        /// </summary>
        [TestMethod]
        public void Eval_on_string_without_expressions_should_be_original_string()
        {
            DefaultExpressionEvaluator evaluator = new DefaultExpressionEvaluator();
            Object res = evaluator.Evaluate("Some test string");            
            Assert.AreEqual("Some test string", res);            
        }

        [TestMethod]
        public void Update_variable_works()
        {
            DefaultExpressionEvaluator evaluator = new DefaultExpressionEvaluator();
            evaluator.Context.RegisterValue("test", 1);
            evaluator.Context.UpdateValue("test", 2);
            var res = evaluator.Evaluate("Res: $test.");
            Assert.AreEqual("Res: 2.", res);
        }
    }
}
