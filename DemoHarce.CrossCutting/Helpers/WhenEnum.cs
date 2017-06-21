using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace DemoHarce.CrossCutting.Helpers
{
    public class WhenEnum<TException> : WhenBase<TException> where TException : Exception, new()
    {
        public void NotContains(Expression<Func<object>> expression, Type enumType)
        {
            this.EnsureNotNull("expression", (object)expression);
            this.EnsureNotNullParameter((Expression<Func<object>>)(() => enumType));
            string name = ParamExpression.GetName((LambdaExpression)expression);
            object obj = ParamExpression.GetValue((LambdaExpression)expression);
            Type enumType1 = enumType;
            bool flag = false;
            if (enumType.IsGenericType)
            {
                if (!enumType.Assembly.FullName.Equals(typeof(Nullable<>).Assembly.FullName) || !enumType.Namespace.Equals(typeof(Nullable<>).Namespace) || !enumType.Name.Equals(typeof(Nullable<>).Name))
                    throw new ArgumentException("enumType debe ser una enumeración", "enumType");
                flag = true;
                enumType1 = Nullable.GetUnderlyingType(enumType);
            }
            if (!enumType1.IsEnum)
                throw new ArgumentException("enumType debe ser una enumeración", "enumType");
            Exception exception = (Exception)null;
            if (!flag && obj == null)
                exception = WhenBase<TException>.CreateException(StringExtensions.StringFormat("El valor de '{0}' no puedo ser nulo si el tipo no es nulable", (object)name));
            else if (!Enumerable.Any<FlagsAttribute>(Enumerable.OfType<FlagsAttribute>((IEnumerable)enumType1.GetCustomAttributes(false))))
            {
                if (obj != null && !Enum.IsDefined(enumType1, obj))
                    exception = WhenBase<TException>.CreateException(StringExtensions.StringFormat("El valor de '{0}' no es un valor posible", (object)name));
            }
            else
            {
                IEnumerable<long> enumerable = Enumerable.Select<object, long>(Enumerable.Cast<object>((IEnumerable)Enum.GetValues(enumType1)), (Func<object, long>)(x => (long)Convert.ChangeType(x, typeof(long))));
                long num1 = 0;
                long num2 = (long)Convert.ChangeType(obj, typeof(long));
                foreach (long num3 in enumerable)
                {
                    if ((num3 & num2) == num3)
                        num1 += num3;
                }
                if (num1 != num2)
                    exception = WhenBase<TException>.CreateException(StringExtensions.StringFormat("El valor de '{0}' no es un valor posible", (object)name));
            }
            if (exception != null)
                throw exception;
        }
    }

}
