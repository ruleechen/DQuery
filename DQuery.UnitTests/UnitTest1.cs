using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Collections.Generic;
using DQuery.CustomQuery;

namespace DQuery.UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        private List<QueryClause> GetClauses()
        {
            return QueryClauseParser.Parse("[{\"operator\":\"=\",\"value\":\"001\",\"fieldname\":\"billno\",\"exfuc\":{\"name\":\"pyszm\"}},{\"condition\":\"and\",\"items\":[{\"operator\":\"like\",\"value\":\"A\",\"fieldname\":\"cusclass\"},{\"operator\":\"like\",\"condition\":\"or\",\"value\":\"YUN\",\"fieldname\":\"cusname\",\"exfuc\":{\"name\":\"isnull\",\"parameters\":[\"a\"]}}]}]");
        }

        [TestMethod]
        public void TestParser()
        {
            var clauses = GetClauses();
        }

        [TestMethod]
        public void TestBuilder()
        {
            var clauses = GetClauses();
            var lambda = ExpressionBuilder.Build<SampleEntity>(clauses, new SampleFunctions());
        }
    }

    public class SampleEntity
    {
        public string billno { get; set; }
        public string cusclass { get; set; }
        public string cusname { get; set; }
    }
}
