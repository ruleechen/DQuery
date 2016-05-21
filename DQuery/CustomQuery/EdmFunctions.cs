using System;
using System.Data.Objects.DataClasses;
using System.Linq.Expressions;

namespace DQuery.CustomQuery
{
    public class EdmFunctions
    {
        [EdmFunction("KTSmartModel.Store", "fun_getpy")]
        public static string GetPyszm(string str)
        {
            throw new NotSupportedException("Direct calls are not supported.");
        }

        public static Expression GetPyszmExp<TSource>(Expression argument)
        {
            return Expression<Func<TSource, bool>>.Call(null, typeof(EdmFunctions).GetMethod("GetPyszm"), argument);
        }
    }
}
