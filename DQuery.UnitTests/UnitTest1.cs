using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using DQuery.CustomQuery;

namespace DQuery.UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestParser()
        {
            var clauses = QueryClauseParser.Parse("[{\"operator\": \"<>\",\"condition\": \"\",\"value\": \"001\",\"valueType\": \"string\",\"fieldname\": \"cuscd\"}, {\"Operator\":\"<>\",\"Condition\":\"and\",\"Value\":\"101\",\"ValueType\":\"string\",\"FieldName\":\"cuscd\",\"items\":[{\"operator\": \"<>\",\"condition\": \"\",\"value\": \"001\",\"valueType\": \"string\",\"fieldname\": \"cuscd\"},{\"operator\": \"<>\",\"condition\": \"\",\"value\": \"001\",\"valueType\": \"string\",\"fieldname\": \"cuscd\"}]}]");

            Assert.AreEqual(clauses.Count, 2);
            Assert.AreEqual(clauses[0].Items.Count, 0);
            Assert.AreEqual(clauses[1].Items.Count, 2);
            Assert.AreEqual(clauses[0].Operator, OperatorType.NotEqual);
        }
    }
}
