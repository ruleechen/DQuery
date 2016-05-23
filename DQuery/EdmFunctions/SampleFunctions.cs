using System;
using System.Data.Objects.DataClasses;

namespace DQuery
{
    public class SampleFunctions : IEdmFunctions
    {
        [EdmFunction("KTSmartModel.Store", "fun_getpy")]
        public static string GetPyszm(string str)
        {
            throw new NotSupportedException("Direct calls are not supported.");
        }

        public Func<string, string> GetPyszmFunc()
        {
            return new Func<string, string>(SampleFunctions.GetPyszm);
        }
    }
}
