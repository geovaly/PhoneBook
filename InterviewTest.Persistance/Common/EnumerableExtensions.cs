using System;
using System.Collections.Generic;
using System.Linq;

namespace InterviewTest.Persistance.Common
{
    public static class EnumerableExtensions
    {
        public static IEnumerable<T> Like<T>(this IEnumerable<T> items, Func<T, string> criteria, string value)
        {
            if (value == String.Empty)
                return items;

            return items.Where(e => criteria(e).Contains(value));
        }
    }
}
