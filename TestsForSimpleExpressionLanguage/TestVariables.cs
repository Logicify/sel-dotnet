using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logicify.SEL.Impl;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestsForSimpleExpressionLanguage
{
    [TestClass]
    public class TestVariables
    {
        [TestMethod]
        public void String_variable_should_be_interpolated()
        {
            DefaultExpressionEvaluator evaluator = new DefaultExpressionEvaluator();
            evaluator.Context.RegisterValue("myVar", "SomeVal");
            var res = evaluator.Evaluate("Value of myVar is $myVar.");
            Assert.AreEqual("Value of myVar is SomeVal.", res);
        }

        [TestMethod]
        public void Expression_in_the_root_should_be_returned_as_result()
        {
            DefaultExpressionEvaluator evaluator = new DefaultExpressionEvaluator();
            evaluator.Context.RegisterValue("myVar", 1);
            var res = evaluator.Evaluate("$myVar");
            Assert.AreEqual(1, res);
        }
    }
}
