using System.Linq.Expressions;
using System.Reflection;

namespace System.Linq
{
    /// <summary>
    /// Contenedor de extensiones para IOrderedQueryable&lt;T>
    /// </summary>
    public static class OrderedQueryableExtension
    {
        private static readonly MethodInfo ThenByMethod = typeof(Queryable).GetMethods()
                                                            .Single(method => method.Name == "ThenBy" &&
                                                                method.GetParameters().Length == 2);
        private static readonly MethodInfo ThenByDescendingMethod = typeof(Queryable).GetMethods()
                                                            .Single(method => method.Name == "ThenByDescending" &&
                                                                method.GetParameters().Length == 2);

        public static IOrderedQueryable<TSource> ThenBy<TSource>(this IOrderedQueryable<TSource> source, string propertyName)
        {
            return ThenBy(source, propertyName, ThenByMethod);
        }

        public static IOrderedQueryable<TSource> ThenByDescending<TSource>(this IOrderedQueryable<TSource> source, string propertyName)
        {
            return ThenBy(source, propertyName, ThenByDescendingMethod);
        }

        private static IOrderedQueryable<TSource> ThenBy<TSource>(IOrderedQueryable<TSource> source, string propertyName, MethodInfo orderMethod)
        {
            ParameterExpression parameter = Expression.Parameter(typeof(TSource), "x");
            Expression orderByProperty = Expression.Property(parameter, propertyName);

            LambdaExpression lambda = Expression.Lambda(orderByProperty, new[] { parameter });
            MethodInfo genericMethod = orderMethod.MakeGenericMethod
                (new[] { typeof(TSource), orderByProperty.Type });
            object ret = genericMethod.Invoke(null, new object[] { source, lambda });
            return (IOrderedQueryable<TSource>)ret;
        }
    }
}
