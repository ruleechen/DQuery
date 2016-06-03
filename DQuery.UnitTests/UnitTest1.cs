using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Collections.Generic;
using DQuery;
using DQuery.CustomQuery;
using System.IO;
using System.Text;


namespace DQuery.UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        public static string LoadJson(string fileName = "query.json")
        {
            var stream = typeof(UnitTest1).Assembly.GetManifestResourceStream("DQuery.UnitTests." + fileName);

            stream.Position = 0;

            var json = string.Empty;

            using (var reader = new StreamReader(stream, Encoding.UTF8))
            {
                json = reader.ReadToEnd();
            }

            var start = json.IndexOf('[');

            return json.Substring(start);
        }

        private List<QueryClause> GetClauses()
        {
            var json = LoadJson();
            return QueryClauseParser.Parse(json);
        }

        [TestMethod]
        public void TestBuilder()
        {
            var clauses = GetClauses();
            var lambda = ExpressionBuilder.Build<Property>(clauses, new SampleFunctions());

            using (var dataContext = new DemoEntities())
            {
                var result = dataContext.Properties.Where(LoadJson(), new SampleFunctions()).ToList();
                Assert.AreEqual(result.Count, 1);
            }
        }
    }

    public class SampleEntity
    {
        public string billno { get; set; }
        public string cusclass { get; set; }
        public string cusname { get; set; }
    }
}
