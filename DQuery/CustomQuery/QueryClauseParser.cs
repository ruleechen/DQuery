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

        static QueryClauseParser()
        {
            ConditionTypeDict = new Dictionary<string, ConditionType>(StringComparer.OrdinalIgnoreCase);
            OperatorTypeDict = new Dictionary<string, OperatorType>(StringComparer.OrdinalIgnoreCase);

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
        }

        public static List<QueryClause> Parse(string json)
        {
            json = string.IsNullOrWhiteSpace(json) ? "[]" : json;

            var raws = JsonConvert.DeserializeObject<List<QueryClauseRaw>>(json);

            return ParseItems(raws);
        }

        private static List<QueryClause> ParseItems(List<QueryClauseRaw> raws)
        {
            if (raws == null)
            {
                return new List<QueryClause>();
            }

            return raws.Select(x => new QueryClause
            {
                Condition = ParseConditionType(x.Condition),
                FieldName = x.FieldName,
                Operator = ParseOperatorType(x.Operator),
                Value = x.Value,
                ExFunction = x.ExFunction,
                Items = ParseItems(x.Items)
            })
            .ToList();
        }

        private static ConditionType ParseConditionType(string type)
        {
            return type != null && ConditionTypeDict.ContainsKey(type) ? ConditionTypeDict[type] : ConditionType.None;
        }

        private static OperatorType ParseOperatorType(string type)
        {
            return type != null && OperatorTypeDict.ContainsKey(type) ? OperatorTypeDict[type] : OperatorType.None;
        }
    }
}
