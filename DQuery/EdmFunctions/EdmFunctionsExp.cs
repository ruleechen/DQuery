using System;
using System.Linq.Expressions;

namespace DQuery
{
    internal class EdmFunctionsExp
    {
        public static Expression GetPyszmExp<TSource>(Expression argument, IEdmFunctions funcs)
        {
            if (funcs == null)
            {
                throw new NotSupportedException("DQuery functions not specified.");
            }

            var func = funcs.GetPyszmFunc();
            if (func == null)
            {
                throw new NotImplementedException("Pyszm function not implemented.");
            }

            return Expression<Func<TSource, bool>>.Call(null, func.Method, argument);
        }

        // More function here
    }
}
