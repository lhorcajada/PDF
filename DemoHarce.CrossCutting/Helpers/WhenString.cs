using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace DemoHarce.CrossCutting.Helpers
{
    public class WhenString<TException> : WhenBase<TException> where TException : Exception, new()
    {
        public void IsNullOrEmpty(Expression<Func<string>> expression)
        {
            this.EnsureNotNull("expression", (object)expression);
            string name = ParamExpression.GetName((LambdaExpression)expression);
            string value = ParamExpression.GetValue((LambdaExpression)expression) as string;
            string message = StringExtensions.StringFormat("El valor de '{0}' no puede ser nulo o cadena vacía", (object)name);
            this.CheckCondition((Func<bool>)(() => string.IsNullOrEmpty(value)), message);
        }

        public void IsNullOrWhiteSpace(Expression<Func<string>> expression)
        {
            this.EnsureNotNull("expression", (object)expression);
            string name = ParamExpression.GetName((LambdaExpression)expression);
            string value = ParamExpression.GetValue((LambdaExpression)expression) as string;
            string message = StringExtensions.StringFormat("El valor de '{0}' no puede ser nulo, cadena vacía o todo espacios", (object)name);
            this.CheckCondition((Func<bool>)(() => string.IsNullOrWhiteSpace(value)), message);
        }

        public void IsNotHexString(Expression<Func<string>> expression)
        {
            this.EnsureNotNull("expression", (object)expression);
            string name = ParamExpression.GetName((LambdaExpression)expression);
            string value = ParamExpression.GetValue((LambdaExpression)expression) as string;
            string message = StringExtensions.StringFormat("El valor de '{0}' tiene que ser una cadena hexadecimal", (object)name);
            this.CheckCondition((Func<bool>)(() => value != null && Enumerable.Any<char>((IEnumerable<char>)value.ToUpper(), (Func<char, bool>)(c => !Uri.IsHexDigit(c)))), message);
        }

        public void IsNotValidIdentifier(Expression<Func<string>> expression)
        {
            this.EnsureNotNull("expression", (object)expression);
            string name = ParamExpression.GetName((LambdaExpression)expression);
            string value = ParamExpression.GetValue((LambdaExpression)expression) as string;
            string message = StringExtensions.StringFormat("El valor de '{0}' no es un identificador válido", (object)name);
            this.CheckCondition((Func<bool>)(() => value == null || !CodeGenerator.IsValidLanguageIndependentIdentifier(value)), message);
        }

        public void IsTooLong(Expression<Func<string>> expression, int maxLength)
        {
            this.EnsureNotNull("expression", (object)expression);
            string name = ParamExpression.GetName((LambdaExpression)expression);
            string value = ParamExpression.GetValue((LambdaExpression)expression) as string;
            string message = StringExtensions.StringFormat("El valor de '{0}' es demasiado largo (máximo {1})", (object)name, (object)maxLength);
            this.CheckCondition((Func<bool>)(() => value != null && value.Length > maxLength), message);
        }
    }

}
