using System;
using System.Linq.Expressions;

namespace DemoHarce.CrossCutting.Helpers
{
    public class WhenNumber<TException> : WhenBase<TException> where TException : Exception, new()
    {
        public void IsZero(Expression<Func<byte>> expression)
        {
            this.PrivateIsZero((LambdaExpression)expression);
        }

        public void IsZero(Expression<Func<Decimal>> expression)
        {
            this.PrivateIsZero((LambdaExpression)expression);
        }

        public void IsZero(Expression<Func<double>> expression)
        {
            this.PrivateIsZero((LambdaExpression)expression);
        }

        public void IsZero(Expression<Func<short>> expression)
        {
            this.PrivateIsZero((LambdaExpression)expression);
        }

        public void IsZero(Expression<Func<int>> expression)
        {
            this.PrivateIsZero((LambdaExpression)expression);
        }

        public void IsZero(Expression<Func<long>> expression)
        {
            this.PrivateIsZero((LambdaExpression)expression);
        }

        public void IsZero(Expression<Func<sbyte>> expression)
        {
            this.PrivateIsZero((LambdaExpression)expression);
        }

        public void IsZero(Expression<Func<float>> expression)
        {
            this.PrivateIsZero((LambdaExpression)expression);
        }

        public void IsZero(Expression<Func<ushort>> expression)
        {
            this.PrivateIsZero((LambdaExpression)expression);
        }

        public void IsZero(Expression<Func<uint>> expression)
        {
            this.PrivateIsZero((LambdaExpression)expression);
        }

        public void IsZero(Expression<Func<ulong>> expression)
        {
            this.PrivateIsZero((LambdaExpression)expression);
        }

        private void PrivateIsZero(LambdaExpression expression)
        {
            this.EnsureNotNull("expression", (object)expression);
            string name = ParamExpression.GetName(expression);
            IComparable value = ParamExpression.GetValue(expression) as IComparable;
            string message = StringExtensions.StringFormat("El valor de '{0}' no puede ser 0", (object)name);
            object zero = Activator.CreateInstance(value.GetType());
            this.CheckCondition((Func<bool>)(() => value != null && value.CompareTo(zero) == 0), message);
        }

        public void IsPositive(Expression<Func<byte>> expression)
        {
            this.PrivateIsPositive((LambdaExpression)expression);
        }

        public void IsPositive(Expression<Func<Decimal>> expression)
        {
            this.PrivateIsPositive((LambdaExpression)expression);
        }

        public void IsPositive(Expression<Func<double>> expression)
        {
            this.PrivateIsPositive((LambdaExpression)expression);
        }

        public void IsPositive(Expression<Func<short>> expression)
        {
            this.PrivateIsPositive((LambdaExpression)expression);
        }

        public void IsPositive(Expression<Func<int>> expression)
        {
            this.PrivateIsPositive((LambdaExpression)expression);
        }

        public void IsPositive(Expression<Func<long>> expression)
        {
            this.PrivateIsPositive((LambdaExpression)expression);
        }

        public void IsPositive(Expression<Func<sbyte>> expression)
        {
            this.PrivateIsPositive((LambdaExpression)expression);
        }

        public void IsPositive(Expression<Func<float>> expression)
        {
            this.PrivateIsPositive((LambdaExpression)expression);
        }

        public void IsPositive(Expression<Func<ushort>> expression)
        {
            this.PrivateIsPositive((LambdaExpression)expression);
        }

        public void IsPositive(Expression<Func<uint>> expression)
        {
            this.PrivateIsPositive((LambdaExpression)expression);
        }

        public void IsPositive(Expression<Func<ulong>> expression)
        {
            this.PrivateIsPositive((LambdaExpression)expression);
        }

        private void PrivateIsPositive(LambdaExpression expression)
        {
            this.EnsureNotNull("expression", (object)expression);
            string name = ParamExpression.GetName(expression);
            IComparable value = ParamExpression.GetValue(expression) as IComparable;
            string message = StringExtensions.StringFormat("El valor de '{0}' no puede ser positivo", (object)name);
            object zero = Activator.CreateInstance(value.GetType());
            this.CheckCondition((Func<bool>)(() => value != null && value.CompareTo(zero) > 0), message);
        }

        public void IsNegative(Expression<Func<byte>> expression)
        {
            this.PrivateIsNegative((LambdaExpression)expression);
        }

        public void IsNegative(Expression<Func<Decimal>> expression)
        {
            this.PrivateIsNegative((LambdaExpression)expression);
        }

        public void IsNegative(Expression<Func<double>> expression)
        {
            this.PrivateIsNegative((LambdaExpression)expression);
        }

        public void IsNegative(Expression<Func<short>> expression)
        {
            this.PrivateIsNegative((LambdaExpression)expression);
        }

        public void IsNegative(Expression<Func<int>> expression)
        {
            this.PrivateIsNegative((LambdaExpression)expression);
        }

        public void IsNegative(Expression<Func<long>> expression)
        {
            this.PrivateIsNegative((LambdaExpression)expression);
        }

        public void IsNegative(Expression<Func<sbyte>> expression)
        {
            this.PrivateIsNegative((LambdaExpression)expression);
        }

        public void IsNegative(Expression<Func<float>> expression)
        {
            this.PrivateIsNegative((LambdaExpression)expression);
        }

        public void IsNegative(Expression<Func<ushort>> expression)
        {
            this.PrivateIsNegative((LambdaExpression)expression);
        }

        public void IsNegative(Expression<Func<uint>> expression)
        {
            this.PrivateIsNegative((LambdaExpression)expression);
        }

        public void IsNegative(Expression<Func<ulong>> expression)
        {
            this.PrivateIsNegative((LambdaExpression)expression);
        }

        private void PrivateIsNegative(LambdaExpression expression)
        {
            this.EnsureNotNull("expression", (object)expression);
            string name = ParamExpression.GetName(expression);
            IComparable value = ParamExpression.GetValue(expression) as IComparable;
            string message = StringExtensions.StringFormat("El valor de '{0}' no puede ser negativo", (object)name);
            object zero = Activator.CreateInstance(value.GetType());
            this.CheckCondition((Func<bool>)(() => value != null && value.CompareTo(zero) < 0), message);
        }

        public void IsPositiveOrZero(Expression<Func<byte>> expression)
        {
            this.PrivateIsPositiveOrZero((LambdaExpression)expression);
        }

        public void IsPositiveOrZero(Expression<Func<Decimal>> expression)
        {
            this.PrivateIsPositiveOrZero((LambdaExpression)expression);
        }

        public void IsPositiveOrZero(Expression<Func<double>> expression)
        {
            this.PrivateIsPositiveOrZero((LambdaExpression)expression);
        }

        public void IsPositiveOrZero(Expression<Func<short>> expression)
        {
            this.PrivateIsPositiveOrZero((LambdaExpression)expression);
        }

        public void IsPositiveOrZero(Expression<Func<int>> expression)
        {
            this.PrivateIsPositiveOrZero((LambdaExpression)expression);
        }

        public void IsPositiveOrZero(Expression<Func<long>> expression)
        {
            this.PrivateIsPositiveOrZero((LambdaExpression)expression);
        }

        public void IsPositiveOrZero(Expression<Func<sbyte>> expression)
        {
            this.PrivateIsPositiveOrZero((LambdaExpression)expression);
        }

        public void IsPositiveOrZero(Expression<Func<float>> expression)
        {
            this.PrivateIsPositiveOrZero((LambdaExpression)expression);
        }

        public void IsPositiveOrZero(Expression<Func<ushort>> expression)
        {
            this.PrivateIsPositiveOrZero((LambdaExpression)expression);
        }

        public void IsPositiveOrZero(Expression<Func<uint>> expression)
        {
            this.PrivateIsPositiveOrZero((LambdaExpression)expression);
        }

        public void IsPositiveOrZero(Expression<Func<ulong>> expression)
        {
            this.PrivateIsPositiveOrZero((LambdaExpression)expression);
        }

        private void PrivateIsPositiveOrZero(LambdaExpression expression)
        {
            this.EnsureNotNull("expression", (object)expression);
            string name = ParamExpression.GetName(expression);
            IComparable value = ParamExpression.GetValue(expression) as IComparable;
            string message = StringExtensions.StringFormat("El valor de '{0}' no puede ser positivo o cero", (object)name);
            object zero = Activator.CreateInstance(value.GetType());
            this.CheckCondition((Func<bool>)(() => value != null && value.CompareTo(zero) >= 0), message);
        }

        public void IsNegativeOrZero(Expression<Func<byte>> expression)
        {
            this.PrivateIsNegativeOrZero((LambdaExpression)expression);
        }

        public void IsNegativeOrZero(Expression<Func<Decimal>> expression)
        {
            this.PrivateIsNegativeOrZero((LambdaExpression)expression);
        }

        public void IsNegativeOrZero(Expression<Func<double>> expression)
        {
            this.PrivateIsNegativeOrZero((LambdaExpression)expression);
        }

        public void IsNegativeOrZero(Expression<Func<short>> expression)
        {
            this.PrivateIsNegativeOrZero((LambdaExpression)expression);
        }

        public void IsNegativeOrZero(Expression<Func<int>> expression)
        {
            this.PrivateIsNegativeOrZero((LambdaExpression)expression);
        }

        public void IsNegativeOrZero(Expression<Func<long>> expression)
        {
            this.PrivateIsNegativeOrZero((LambdaExpression)expression);
        }

        public void IsNegativeOrZero(Expression<Func<sbyte>> expression)
        {
            this.PrivateIsNegativeOrZero((LambdaExpression)expression);
        }

        public void IsNegativeOrZero(Expression<Func<float>> expression)
        {
            this.PrivateIsNegativeOrZero((LambdaExpression)expression);
        }

        public void IsNegativeOrZero(Expression<Func<ushort>> expression)
        {
            this.PrivateIsNegativeOrZero((LambdaExpression)expression);
        }

        public void IsNegativeOrZero(Expression<Func<uint>> expression)
        {
            this.PrivateIsNegativeOrZero((LambdaExpression)expression);
        }

        public void IsNegativeOrZero(Expression<Func<ulong>> expression)
        {
            this.PrivateIsNegativeOrZero((LambdaExpression)expression);
        }

        private void PrivateIsNegativeOrZero(LambdaExpression expression)
        {
            this.EnsureNotNull("expression", (object)expression);
            string name = ParamExpression.GetName(expression);
            IComparable value = ParamExpression.GetValue(expression) as IComparable;
            string message = StringExtensions.StringFormat("El valor de '{0}' no puede ser negativo o cero", (object)name);
            object zero = Activator.CreateInstance(value.GetType());
            this.CheckCondition((Func<bool>)(() => value != null && value.CompareTo(zero) <= 0), message);
        }
    }
}
