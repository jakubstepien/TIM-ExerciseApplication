using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication
{
    public static class LinqHelpers
    {
        public static void ForEach<T> (this IEnumerable<T> collection, Action<T> action)
        {
            foreach (var element in collection)
            {
                action.Invoke(element);
            }
        }
    }
}