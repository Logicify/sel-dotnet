using Logicify.SEL.Common;

namespace Logicify.SEL.Handlers
{
    public class CapitalizeHandler : BaseExpressionHandler
    {
        public override string Name
        {
            get { return "upper"; }
        }

        public override object ParseArgument(object rawArgumentValue)
        {
            ValueIsRequired(rawArgumentValue);
            ValueShouldBeAString(rawArgumentValue);
            return rawArgumentValue;
        }

        public override object Invoke(object argument, IExpressionContext context)
        {
            return argument.ToString().ToUpper();
        }
    }
}
