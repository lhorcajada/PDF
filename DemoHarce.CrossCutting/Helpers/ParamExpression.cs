using System;
using System.Linq.Expressions;

namespace DemoHarce.CrossCutting.Helpers
{
    public static class ParamExpression
    {
        public static object GetValue(LambdaExpression paramExpression)
        {
            return paramExpression.Compile().DynamicInvoke();
        }

        public static string GetName(LambdaExpression paramExpression)
        {
            Expression body = paramExpression.Body;
            MemberExpression memberExpression = !(body is UnaryExpression) ? body as MemberExpression : ((UnaryExpression)body).Operand as MemberExpression;
            if (memberExpression == null)
                return (string)null;
            return memberExpression.Member.Name;
        }

        public static string GetPath(LambdaExpression paramExpression)
        {
            return new PropertyPathVisitor().GetPropertyPath((Expression)paramExpression);
        }

        public static string NameOf<T>(Expression<Func<T, object>> propertyExpression)
        {
            return ParamExpression.GetName((LambdaExpression)propertyExpression);
        }
    }

}
