using System.Linq.Expressions;
using System.Reflection;

namespace System.Linq
{
    /// <summary>
    /// Contenedor de extensiones para IQueryable&lt;T>
    /// </summary>
    public static class QueryableExtension
    {
        private static readonly MethodInfo OrderByMethod = typeof(Queryable).GetMethods()
                                                            .Single(method => method.Name == nameof(Queryable.OrderBy) &&
                                                                method.GetParameters().Length == 2);
        private static readonly MethodInfo OrderByDescendingMethod = typeof(Queryable).GetMethods()
                                                            .Single(method => method.Name == nameof(Queryable.OrderByDescending) &&
                                                                method.GetParameters().Length == 2);

        public static IOrderedQueryable<TSource> OrderBy<TSource>(this IQueryable<TSource> source, string propertyName)
        {
            return OrderBy(source, propertyName, OrderByMethod);
        }
        [Obsolete]
        public static IOrderedQueryable<TSource> OrderBy<TSource>(this IQueryable<TSource> source, string propertyName, bool isAscending)
        {
            if (isAscending)
                return OrderBy(source, propertyName, OrderByMethod);
            else
                return OrderBy(source, propertyName, OrderByDescendingMethod);

        }
        public static IOrderedQueryable<TSource> ApplyOrder<TSource>(this IQueryable<TSource> source, string propertyName, bool isAscending)
        {
            if (isAscending)
                return OrderBy(source, propertyName, OrderByMethod);
            else
                return OrderBy(source, propertyName, OrderByDescendingMethod);

        }
        public static IOrderedQueryable<TSource> OrderByDescending<TSource>(this IQueryable<TSource> source, string propertyName)
        {
            return OrderBy(source, propertyName, OrderByDescendingMethod);
        }

        private static IOrderedQueryable<TSource> OrderBy<TSource>(IQueryable<TSource> source, string propertyName, MethodInfo orderMethod)
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
