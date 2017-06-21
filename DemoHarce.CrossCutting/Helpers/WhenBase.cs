using System;
using System.Diagnostics;
using System.Linq.Expressions;

namespace DemoHarce.CrossCutting.Helpers
{
    public abstract class WhenBase<TException> where TException : Exception, new()
    {
        [DebuggerStepThrough]
        protected void CheckCondition(Func<bool> condition, string message)
        {
            if (!condition())
                return;
            Exception exception = WhenBase<TException>.CreateException(message);
            if (exception != null)
                throw exception;
        }

        [DebuggerStepThrough]
        protected static Exception CreateException(string message)
        {
            Exception exception;
            try
            {
                exception = (Exception)Activator.CreateInstance(typeof(TException), new object[1]
                {
          (object) message
                });
            }
            catch
            {
                try
                {
                    exception = (Exception)Activator.CreateInstance<TException>();
                }
                catch
                {
                    exception = (Exception)new NotImplementedException();
                }
            }
            return exception;
        }

        [DebuggerStepThrough]
        protected void EnsureNotNullParameter(Expression<Func<object>> expression)
        {
            this.EnsureNotNull("expression", (object)expression);
            string name = ParamExpression.GetName((LambdaExpression)expression);
            if (ParamExpression.GetValue((LambdaExpression)expression) == null)
                throw new ArgumentNullException(StringExtensions.StringFormat("El argumento '{0}' no puede ser nulo", (object)name));
        }

        [DebuggerStepThrough]
        protected void EnsureNotNull(string paramName, object value)
        {
            if (value == null)
                throw new ArgumentNullException(StringExtensions.StringFormat("El valor de '{0}' no puede ser nulo", (object)paramName));
        }
    }

}
