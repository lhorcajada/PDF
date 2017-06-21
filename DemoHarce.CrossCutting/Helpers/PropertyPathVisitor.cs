using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace DemoHarce.CrossCutting.Helpers
{
    public class PropertyPathVisitor : ExpressionVisitor
    {
        private Stack<string> _stack;

        public string GetPropertyPath(Expression expression)
        {
            _stack = new Stack<string>();
            Visit(expression);

            return string.Join(".", _stack.ToArray());
            //return _stack.Aggregate(new StringBuilder(), (sb, name) => (sb.Length > 0 ? sb.Append(".") : sb).Append(name)).ToString();
        }

        protected override Expression VisitMember(MemberExpression node)
        {
            if (node == null) return null;

            if (_stack != null)
                _stack.Push(node.Member.Name);
            return base.VisitMember(node);
        }

        protected override Expression VisitMethodCall(MethodCallExpression node)
        {
            if (node == null)
                return null;

            if (!IsLinqOperator(node.Method))
                return base.VisitMethodCall(node);

            for (int i = 1; i < node.Arguments.Count; i++)
                Visit(node.Arguments[i]);

            Visit(node.Arguments[0]);
            return node;
        }

        private static bool IsLinqOperator(MethodInfo method)
        {
            //if (method.DeclaringType != typeof(Queryable) && method.DeclaringType != typeof(Enumerable))
            //	return false;
            return Attribute.GetCustomAttribute(method, typeof(ExtensionAttribute)) != null;
        }
    }
}
