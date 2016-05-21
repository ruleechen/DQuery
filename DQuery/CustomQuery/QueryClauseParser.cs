using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DQuery.CustomQuery
{
    public class QueryClauseParser
    {
        static Dictionary<string, ConditionType> ConditionTypeDict;
        static Dictionary<string, OperatorType> OperatorTypeDict;
        static Dictionary<string, ValueType> ValueTypeDict;

        static QueryClauseParser()
        {
            ConditionTypeDict = new Dictionary<string, ConditionType>(StringComparer.OrdinalIgnoreCase);
            OperatorTypeDict = new Dictionary<string, OperatorType>(StringComparer.OrdinalIgnoreCase);
            ValueTypeDict = new Dictionary<string, ValueType>(StringComparer.OrdinalIgnoreCase);

            foreach (var item in Enum.GetValues(typeof(ConditionType)))
            {
                var field = (ConditionType)item;
                ConditionTypeDict.Add(field.GetAttachedValue().ToStringOrEmpty(), field);
            }

            foreach (var item in Enum.GetValues(typeof(OperatorType)))
            {
                var field = (OperatorType)item;
                OperatorTypeDict.Add(field.GetAttachedValue().ToStringOrEmpty(), field);
            }

            foreach (var item in Enum.GetValues(typeof(ValueType)))
            {
                var field = (ValueType)item;
                ValueTypeDict.Add(field.GetAttachedValue().ToStringOrEmpty(), field);
            }
        }

        public static IEnumerable<QueryClause> Parse(string json)
        {
            json = string.IsNullOrWhiteSpace(json) ? "[]" : json;

            var raws = JsonConvert.DeserializeObject<List<QueryClauseRaw>>(json);

            return raws.Select(x => new QueryClause
            {
                Condition = ParseConditionType(x.Condition),
                FieldName = x.FieldName,
                Operator = ParseOperatorType(x.Operator),
                ValueType = ParseValueType(x.ValueType),
                Value = x.Value
            });
        }

        private static ConditionType ParseConditionType(string type)
        {
            return ConditionTypeDict.ContainsKey(type) ? ConditionTypeDict[type] : ConditionType.None;
        }

        private static OperatorType ParseOperatorType(string type)
        {
            return OperatorTypeDict.ContainsKey(type) ? OperatorTypeDict[type] : OperatorType.None;
        }

        private static ValueType ParseValueType(string type)
        {
            return ValueTypeDict.ContainsKey(type) ? ValueTypeDict[type] : ValueType.String;
        }
    }
}
