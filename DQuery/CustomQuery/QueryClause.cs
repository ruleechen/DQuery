﻿using Newtonsoft.Json;

namespace DQuery.CustomQuery
{
    public class QueryClause
    {
        public ConditionType Condition { get; set; }

        public string FieldName { get; set; }

        public OperatorType Operator { get; set; }

        public ValueType ValueType { get; set; }

        public object Value { get; set; }
    }

    public class QueryClauseRaw
    {
        [JsonProperty("condition")]
        public string Condition { get; set; }

        [JsonProperty("fieldname")]
        public string FieldName { get; set; }

        [JsonProperty("operator")]
        public string Operator { get; set; }

        [JsonProperty("valuetype")]
        public string ValueType { get; set; }

        [JsonProperty("value")]
        public object Value { get; set; }
    }
}
