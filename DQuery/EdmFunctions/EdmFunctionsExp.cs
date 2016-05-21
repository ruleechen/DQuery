using System;
using System.Linq.Expressions;

namespace DQuery
{
    internal class EdmFunctionsExp
    {
        public static Expression GetPyszmExp<TSource>(Expression argument, IEdmFunctions funs)
        {
            var func = funs.GetPyszmFunc();
            return Expression<Func<TSource, bool>>.Call(null, func.Method, argument);
        }

        // More function here
    }
}
