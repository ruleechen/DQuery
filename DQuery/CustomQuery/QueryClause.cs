using System.Collections.Generic;
using Newtonsoft.Json;

namespace DQuery.CustomQuery
{
    public class QueryClause
    {
        public ConditionType Condition { get; set; }

        public string FieldName { get; set; }

        public OperatorType Operator { get; set; }

        public object Value { get; set; }

        public FunctionEx FunctionEx { get; set; }

        public List<QueryClause> Items { get; set; }
    }

    public class QueryClauseRaw
    {
        [JsonProperty("condition")]
        public string Condition { get; set; }

        [JsonProperty("fieldname")]
        public string FieldName { get; set; }

        [JsonProperty("operator")]
        public string Operator { get; set; }

        [JsonProperty("value")]
        public object Value { get; set; }

        [JsonProperty("exfuc")]
        public FunctionEx FunctionEx { get; set; }

        [JsonProperty("items")]
        public List<QueryClauseRaw> Items { get; set; }
    }
}
