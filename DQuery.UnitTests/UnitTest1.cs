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
            return QueryClauseParser.Parse("[{\"operator\": \"<>\",\"condition\": \"\",\"value\": \"001\",\"valueType\": \"string\",\"fieldname\": \"cuscd\"}, {\"Operator\":\"<>\",\"Condition\":\"and\",\"Value\":\"101\",\"ValueType\":\"string\",\"FieldName\":\"cuscd\",\"items\":[{\"operator\": \"<>\",\"condition\": \"\",\"value\": \"001\",\"valueType\": \"string\",\"fieldname\": \"cuscd\"},{\"operator\": \"<>\",\"condition\": \"and\",\"value\": \"001\",\"valueType\": \"string\",\"fieldname\": \"cuscd\"}]}]");
        }

        [TestMethod]
        public void TestParser()
        {
            var clauses = GetClauses();

            Assert.AreEqual(clauses.Count, 2);
            Assert.AreEqual(clauses[0].Items.Count, 0);
            Assert.AreEqual(clauses[1].Items.Count, 2);
            Assert.AreEqual(clauses[0].Operator, OperatorType.NotEqual);
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
        public string cuscd { get; set; }
    }
}
