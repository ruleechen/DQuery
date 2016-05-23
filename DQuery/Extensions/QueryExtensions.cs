using DQuery.CustomQuery;
using System.Collections.Generic;
using System.Data.Objects;
using System.Linq;

namespace DQuery
{
    public static class QueryExtensions
    {
        public static IQueryable<TSource> Where<TSource>(this IQueryable<TSource> source, string json, IEdmFunctions funcs)
            where TSource : class
        {
            var clauses = QueryClauseParser.Parse(json);
            var lambda = ExpressionBuilder.Build<TSource>(clauses.ToList(), funcs);
            return source.Where(lambda);
        }

        public static IQueryable<TSource> Where<TSource>(this ObjectSet<TSource> source, string json, IEdmFunctions funcs)
            where TSource : class
        {
            return (source as IQueryable<TSource>).Where(json, funcs);
        }

        public static IEnumerable<TSource> Where<TSource>(this IEnumerable<TSource> source, string json, IEdmFunctions funcs)
            where TSource : class
        {
            var clauses = QueryClauseParser.Parse(json);
            var lambda = ExpressionBuilder.Build<TSource>(clauses.ToList(), funcs);
            return source.Where(lambda.Compile());
        }
    }
}
