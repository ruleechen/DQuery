using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Collections.Generic;
using DQuery;
using DQuery.CustomQuery;


namespace DQuery.UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        private string GetJson()
        {
            return "[{\"operator\":\"=\",\"value\":\"002\",\"fieldname\":\"billno\"},{\"condition\":\"and\",\"items\":[{\"operator\":\"like\",\"value\":\"A\",\"fieldname\":\"cusclass\"},{\"operator\":\"like\",\"condition\":\"or\",\"value\":\"YUN\",\"fieldname\":\"cusname\",\"exfuc\":{\"name\":\"isnull\",\"params\":[\"bYUNb\"]}}]}]";
        }

        private List<QueryClause> GetClauses()
        {
            return QueryClauseParser.Parse(GetJson());
        }

        [TestMethod]
        public void TestBuilder()
        {
            var clauses = GetClauses();
            var lambda = ExpressionBuilder.Build<SampleEntity>(clauses, new SampleFunctions());

            var entities = new List<SampleEntity>();
            entities.Add(new SampleEntity { billno = "001", cusclass = "ABC", cusname = null });
            entities.Add(new SampleEntity { billno = "002", cusclass = "A", cusname = "" });
            var result = entities.Where(GetJson(), new SampleFunctions()).ToList();

            Assert.AreEqual(result.Count, 1);
            Assert.AreEqual(result[0].billno, "002");
        }
    }

    public class SampleEntity
    {
        public string billno { get; set; }
        public string cusclass { get; set; }
        public string cusname { get; set; }
    }
}
