using System;
using System.Collections;
using System.Linq;
using System.Linq.Expressions;

namespace DemoHarce.CrossCutting.Helpers
{
    public class WhenEnumerable<TException> : WhenBase<TException> where TException : Exception, new()
    {
        public void IsNullOrEmpty(Expression<Func<IEnumerable>> expression)
        {
            this.EnsureNotNull("expression", (object)expression);
            string name = ParamExpression.GetName((LambdaExpression)expression);
            IEnumerable value = ParamExpression.GetValue((LambdaExpression)expression) as IEnumerable;
            string message = StringExtensions.StringFormat("El valor de '{0}' no puede ser nulo o una lista vacía", (object)name);
            this.CheckCondition((Func<bool>)(() => value == null || !Enumerable.Any<object>(Enumerable.Cast<object>(value))), message);
        }
    }

}
