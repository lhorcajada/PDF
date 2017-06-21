using System.Linq;

namespace System.Collections.Generic
{
    /// <summary>
    /// Contenedor de extensiones para el tipo <typeparamref name="IEnumerable"/>
    /// </summary>
    public static class EnumerableExtension
    {

        /// <summary>
        /// Se asegura que el contenido del IEnumerable esté materializado, aunque venga
        /// de un IQueryable desde Entity Framework
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="enumerable"></param>
        /// <returns></returns>
        public static IEnumerable<T> Materialize<T>(this IEnumerable<T> enumerable)
        {
            return enumerable.GetType().IsArray ? enumerable : enumerable.ToArray();
        }
        /// <summary>
        /// Devuelve el conjunto inicial excepto los pasados en <paramref name="second"/>
        /// Para comparar los elementos usará el predicado pasado en <paramref name="predicate"/>
        /// </summary>
        /// <typeparam name="T">Tipo de los elementos del conjunto</typeparam>
        /// <param name="source">Conjunto inicial</param>
        /// <param name="second">Conjunto a quitar</param>
        /// <param name="predicate">Función para comparar elementos</param>
        /// <returns>Conjunto resultante</returns>
        public static IEnumerable<T> Except<T>(this IEnumerable<T> source,
                                        IEnumerable<T> second,
                                        Func<T, T, bool> predicate)
        {
            return source.Except(second, new PredicateEqualityComparer<T>(predicate));
        }

        public static IEnumerable<T> Intersect<T>(this IEnumerable<T> source,
                                        IEnumerable<T> second,
                                        Func<T, T, bool> predicate)
        {
            return source.Intersect(second, new PredicateEqualityComparer<T>(predicate));
        }

        public static IEnumerable<TResult> IncludeWith<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, TResult> selector)
            where TSource : class
            where TResult : class
        {
            return source.Select(selector);
        }

        public static int Count(this IEnumerable source)
        {
            if (source == null)
                return 0;
            //return source.Cast<object>().Count();
            var enumerator = source.GetEnumerator();
            int count = 0;
            while (enumerator.MoveNext())
                count++;
            return count;
        }
    }

    public class PredicateEqualityComparer<T> : IEqualityComparer<T>
    {
        private readonly Func<T, T, bool> _predicate;

        public PredicateEqualityComparer(Func<T, T, bool> predicate)
        {
            _predicate = predicate;
        }

        public bool Equals(T x, T y)
        {
            return _predicate(x, y);
        }

        public int GetHashCode(T x)
        {
            return 0;
        }
    }
}
