using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;

namespace DemoHarce.CrossCutting.Helpers
{
    public static class Validators
    {
        [DebuggerStepThrough]
        public static void ThrowExceptionWhenIsNull(Expression<Func<object>> paramExpression)
        {
            Validators.EnsureValidParamExpression(paramExpression);
            Validators.ThrowExceptionWhenIsNull(Validators.GetParamName(paramExpression), Validators.GetParamValue(paramExpression));
        }

        [DebuggerStepThrough]
        public static void ThrowExceptionWhenIsNull(string paramName, object value)
        {
            Validators.EnsureValidParamName(paramName);
            if (value == null)
                throw new ArgumentNullException(StringExtensions.StringFormat("{0} no puede ser nulo", (object)paramName), paramName);
        }

        [DebuggerStepThrough]
        public static void ThrowExceptionWhenIsNullOrEmpty(string paramName, string value)
        {
            Validators.EnsureValidParamName(paramName);
            if (string.IsNullOrEmpty(value))
                throw new ArgumentNullException(StringExtensions.StringFormat("{0} no puede ser nulo o vacío", (object)paramName), paramName);
        }

        [DebuggerStepThrough]
        public static void ThrowExceptionWhenIsNullOrEmpty(Expression<Func<object>> paramExpression)
        {
            Validators.EnsureValidParamExpression(paramExpression);
            Validators.ThrowExceptionWhenIsNullOrEmpty(Validators.GetParamName(paramExpression), Validators.GetParamValue(paramExpression) as string);
        }

        [DebuggerStepThrough]
        public static void ThrowExceptionWhenIsNullOrWhiteSpace(string paramName, string value)
        {
            Validators.EnsureValidParamName(paramName);
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentNullException(StringExtensions.StringFormat("{0} no puede ser nulo, vacío o solo espacios", (object)paramName), paramName);
        }

        [DebuggerStepThrough]
        public static void ThrowExceptionWhenIsNullOrWhiteSpace(Expression<Func<object>> paramExpression)
        {
            Validators.EnsureValidParamExpression(paramExpression);
            Validators.ThrowExceptionWhenIsNullOrWhiteSpace(Validators.GetParamName(paramExpression), Validators.GetParamValue(paramExpression) as string);
        }

        [DebuggerStepThrough]
        public static void ThrowExceptionWhenIsNotValidIdentifier(string paramName, string value)
        {
            Validators.EnsureValidParamName(paramName);
            if (!CodeGenerator.IsValidLanguageIndependentIdentifier(value))
                throw new ArgumentException(StringExtensions.StringFormat("{0} no es un identificador válido", (object)paramName), paramName);
        }

        [DebuggerStepThrough]
        public static void ThrowExceptionWhenIsNotValidIdentifier(Expression<Func<object>> paramExpression)
        {
            Validators.ThrowExceptionWhenIsNull("paramExpression", (object)paramExpression);
            Validators.ThrowExceptionWhenIsNotValidIdentifier(Validators.GetParamName(paramExpression), Validators.GetParamValue(paramExpression) as string);
        }

        [DebuggerStepThrough]
        public static void ThrowExceptionWhenIsNullOrEmptyList(string paramName, IEnumerable list)
        {
            Validators.EnsureValidParamName(paramName);
            if (list == null || Enumerable.Count<object>(Enumerable.Cast<object>(list)) == 0)
                throw new ArgumentException(StringExtensions.StringFormat("La lista {0} no puede estar vacía", (object)paramName), paramName);
        }

        [DebuggerStepThrough]
        public static void ThrowExceptionWhenNotInEnum(string paramName, object value, Type enumType)
        {
            Validators.EnsureValidParamName(paramName);
            Validators.ThrowExceptionWhenIsNull("enumType", (object)enumType);
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
            if (!flag && value == null)
                throw new ArgumentException("El valor de '{0}' no puedo ser nulo si el tipo no es nulable", paramName);
            if (!Enumerable.Any<FlagsAttribute>(Enumerable.OfType<FlagsAttribute>((IEnumerable)enumType1.GetCustomAttributes(false))))
            {
                if (value != null && !Enum.IsDefined(enumType1, value))
                    throw new ArgumentException("El valor de '{0}' no es un valor posible", paramName);
            }
            else
            {
                IEnumerable<long> enumerable = Enumerable.Select<object, long>(Enumerable.Cast<object>((IEnumerable)Enum.GetValues(enumType1)), (Func<object, long>)(x => (long)Convert.ChangeType(x, typeof(long))));
                long num1 = 0;
                long num2 = (long)Convert.ChangeType(value, typeof(long));
                foreach (long num3 in enumerable)
                {
                    if ((num3 & num2) == num3)
                        num1 += num3;
                }
                if (num1 != num2)
                    throw new ArgumentException("El valor de '{0}' no es un valor posible", paramName);
            }
        }

        [DebuggerStepThrough]
        public static void ThrowExceptionWhenNotInEnum(Expression<Func<object>> paramExpression, Type enumType)
        {
            Validators.ThrowExceptionWhenIsNull("paramExpression", (object)paramExpression);
            Validators.ThrowExceptionWhenNotInEnum(Validators.GetParamName(paramExpression), Validators.GetParamValue(paramExpression), enumType);
        }

        [DebuggerStepThrough]
        public static void ThrowExceptionWhenIsNegative(Expression<Func<object>> paramExpression)
        {
            Validators.ThrowExceptionWhenIsNull("paramExpression", (object)paramExpression);
            Validators.ThrowExceptionWhenIsNegative(Validators.GetParamName(paramExpression), (int)Validators.GetParamValue(paramExpression));
        }

        [DebuggerStepThrough]
        public static void ThrowExceptionWhenIsNegative(string paramName, int value)
        {
            if (value < 0)
                throw new ArgumentException("El valor de '{0}' no puede ser un número negativo", paramName);
        }

        [DebuggerStepThrough]
        public static void ThrowExceptionWhenIsNegativeOrZero(Expression<Func<object>> paramExpression)
        {
            Validators.EnsureValidParamExpression(paramExpression);
            Validators.ThrowExceptionWhenIsNegativeOrZero(Validators.GetParamName(paramExpression), (int)Validators.GetParamValue(paramExpression));
        }

        [DebuggerStepThrough]
        public static void ThrowExceptionWhenIsNegativeOrZero(string paramName, int value)
        {
            if (value < 1)
                throw new ArgumentException("El valor de '{0}' no puede ser un número negativo", paramName);
        }

        [DebuggerStepThrough]
        public static void ThrowExceptionWhenIsEquals(Expression<Func<object>> paramExpression, object expectedValue)
        {
            Validators.ThrowExceptionWhenIsNull("paramExpression", (object)paramExpression);
            Validators.ThrowExceptionWhenIsEquals(Validators.GetParamName(paramExpression), Validators.GetParamValue(paramExpression), expectedValue);
        }

        [DebuggerStepThrough]
        public static void ThrowExceptionWhenIsEquals(string paramName, object value, object expectedValue)
        {
            Validators.EnsureValidParamName(paramName);
            if (value == null && expectedValue == null || value != null && value.Equals(expectedValue))
                throw new ArgumentException(StringExtensions.StringFormat("{0} tiene un valor incorrecto ({1})", (object)paramName, expectedValue), paramName);
        }

        [DebuggerStepThrough]
        public static void ThrowExceptionWhenIsNotEquals(Expression<Func<object>> paramExpression, object expectedValue)
        {
            Validators.ThrowExceptionWhenIsNull("paramExpression", (object)paramExpression);
            Validators.ThrowExceptionWhenIsNotEquals(Validators.GetParamName(paramExpression), Validators.GetParamValue(paramExpression), expectedValue);
        }

        [DebuggerStepThrough]
        public static void ThrowExceptionWhenIsNotEquals(string paramName, object value, object expectedValue)
        {
            Validators.EnsureValidParamName(paramName);
            if (value == null && expectedValue == null || value != null && !value.Equals(expectedValue))
                throw new ArgumentException(StringExtensions.StringFormat("{0} no tiene un valor correcto ({1})", (object)paramName, expectedValue), paramName);
        }

        [DebuggerStepThrough]
        public static void ThrowExceptionWhenIsTooLong(Expression<Func<object>> paramExpression, int maxLength)
        {
            Validators.ThrowExceptionWhenIsNull((Expression<Func<object>>)(() => paramExpression));
            Validators.ThrowExceptionWhenIsNegativeOrZero((Expression<Func<object>>)(() => (object)maxLength));
            Validators.ThrowExceptionWhenIsTooLong(Validators.GetParamName(paramExpression), Validators.GetParamValue(paramExpression) as string, maxLength);
        }

        [DebuggerStepThrough]
        public static void ThrowExceptionWhenIsTooLong(string paramName, string value, int maxLength)
        {
            Validators.EnsureValidParamName(paramName);
            if (value != null && value.Length > maxLength)
                throw new ArgumentException(StringExtensions.StringFormat("El valor de '{0}' es demasiado largo (máximo {1})", (object)paramName, (object)maxLength), paramName);
        }

        [DebuggerStepThrough]
        public static void ThrowExceptionWhenIsNotHexString(string paramName, string value)
        {
            Validators.EnsureValidParamName(paramName);
            if (value != null && Enumerable.Any<char>((IEnumerable<char>)value, (Func<char, bool>)(c => !Uri.IsHexDigit(c))))
                throw new ArgumentNullException(StringExtensions.StringFormat("{0} tiene que ser una cadena hexadecimal", (object)paramName), paramName);
        }

        [DebuggerStepThrough]
        public static void ThrowExceptionWhenIsNotHexString(Expression<Func<object>> paramExpression)
        {
            Validators.ThrowExceptionWhenIsNull((Expression<Func<object>>)(() => paramExpression));
            Validators.ThrowExceptionWhenIsNotHexString(Validators.GetParamName(paramExpression), Validators.GetParamValue(paramExpression) as string);
        }

        [DebuggerStepThrough]
        private static void EnsureValidParamName(string paramName)
        {
            if (string.IsNullOrWhiteSpace(paramName))
                throw new ArgumentException("El argumento 'paramName' no puede ser nulo o vacío", "paramName");
        }

        [DebuggerStepThrough]
        private static void EnsureValidParamExpression(Expression<Func<object>> paramExpression)
        {
            if (paramExpression == null)
                throw new ArgumentNullException("El argumento 'paramExpression' no puede ser nulo", "paramExpression");
        }

        private static object GetParamValue(Expression<Func<object>> paramExpression)
        {
            return paramExpression.Compile()();
        }

        private static string GetParamName(Expression<Func<object>> paramExpression)
        {
            Expression body = paramExpression.Body;
            MemberExpression memberExpression = !(body is UnaryExpression) ? body as MemberExpression : ((UnaryExpression)body).Operand as MemberExpression;
            if (memberExpression == null)
                return (string)null;
            return memberExpression.Member.Name;
        }
    }

}
