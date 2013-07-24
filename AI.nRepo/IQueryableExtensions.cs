using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

    public static class IQueryableExtensions
    {
        public static IQueryable<T> GetPage<T>(this IQueryable<T> queryable, int pageNumber, int pageSize)
        {
            return queryable.Skip((pageNumber - 1) * pageSize).Take(pageNumber);
        }
    }

