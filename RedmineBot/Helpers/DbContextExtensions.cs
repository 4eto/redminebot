using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace RedmineBot.Helpers
{
    public static class DbContextExtensions
    {
        public static IQueryable<T> LocalOrDatabase<T>(this DbContext context, Expression<Func<T, Boolean>> expression) where T : class
        {
            var localResults = context.Set<T>().Local.Where(expression.Compile());
            if (localResults.Any() == true)
                return localResults.AsQueryable();
            return context.Set<T>().Where(expression);
        }
    }
}