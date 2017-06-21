using System;
using System.Linq.Expressions;

namespace DemoHarce.CrossCutting.Helpers
{
    public class WhenObject<TException> : WhenBase<TException> where TException : Exception, new()
    {
        public void IsNull(Expression<Func<object>> expression)
        {
            this.EnsureNotNull("expression", (object)expression);
            string name = ParamExpression.GetName((LambdaExpression)expression);
            object value = ParamExpression.GetValue((LambdaExpression)expression);
            string message = StringExtensions.StringFormat("El valor de '{0}' no puede ser nulo", (object)name);
            this.CheckCondition((Func<bool>)(() => value == null), message);
        }

        public void IsNotNull(Expression<Func<object>> expression)
        {
            this.EnsureNotNull("expression", (object)expression);
            string name = ParamExpression.GetName((LambdaExpression)expression);
            object value = ParamExpression.GetValue((LambdaExpression)expression);
            string message = StringExtensions.StringFormat("El valor de '{0}' no puede ser no nulo", (object)name);
            this.CheckCondition((Func<bool>)(() => value != null), message);
        }

        public void Equals(Expression<Func<object>> expression, object expectedValue)
        {
            this.EnsureNotNull("expression", (object)expression);
            string name = ParamExpression.GetName((LambdaExpression)expression);
            object value = ParamExpression.GetValue((LambdaExpression)expression);
            string message = StringExtensions.StringFormat("El valor de '{0}' no puede ser {1}", (object)name, expectedValue);
            this.CheckCondition((Func<bool>)(() => value == null && expectedValue == null || value != null && value.Equals(expectedValue)), message);
        }

        public void NotEquals(Expression<Func<object>> expression, object expectedValue)
        {
            this.EnsureNotNull("expression", (object)expression);
            string name = ParamExpression.GetName((LambdaExpression)expression);
            object value = ParamExpression.GetValue((LambdaExpression)expression);
            string message = StringExtensions.StringFormat("El valor de '{0}' tiene que ser {1}", (object)name, expectedValue);
            this.CheckCondition((Func<bool>)(() => value == null && expectedValue != null || value != null && !value.Equals(expectedValue)), message);
        }
    }

}
