using System;
using System.Collections.Generic;

namespace DemoHarce.CrossCutting.Extensions
{
    public static class EnumExtension
    {
        public static T Add<T>(this T lhs, T rhs)
            where T : struct, IComparable
        {
            ThrowsExceptionWhenNotIsEnum(typeof(T));

            long l = (long)(object)lhs;
            long r = (long)(object)rhs;
            return (T)(object)(l |= r);
        }

        public static T Remove<T>(this T lhs, T rhs)
            where T : struct, IComparable
        {
            ThrowsExceptionWhenNotIsEnum(typeof(T));

            long l = (long)(object)lhs;
            long r = (long)(object)rhs;
            return (T)(object)(l ^= r);
        }

        public static bool Contains<T>(this T lhs, T rhs)
            where T : struct, IComparable
        {
            ThrowsExceptionWhenNotIsEnum(typeof(T));

            long l = (long)(object)lhs;
            long r = (long)(object)rhs;
            return (l & r) == r;
        }

        public static IEnumerable<T> GetList<T>(this T enumValue)
            where T : struct, IComparable
        {
            ThrowsExceptionWhenNotIsEnum(typeof(T));

            List<T> result = new List<T>();
            var values = Enum.GetValues(typeof(T));
            foreach (T value in values)
            {
                if (enumValue.Contains(value))
                    result.Add((T)value);
            }
            return result;
        }

        private static void ThrowsExceptionWhenNotIsEnum(Type type)
        {
            if (type == null)
                return;

            if (!type.IsEnum)
                throw new InvalidOperationException("T must be an enum");
        }
    }
}
