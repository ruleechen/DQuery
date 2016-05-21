using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace DQuery.CustomQuery
{
    public class ExpressionBuilder
    {
        public static Expression<Func<TSource, bool>> Build<TSource>(List<QueryClause> clauses, IEdmFunctions funs = null)
        {
            ConvertClauseValue<TSource>(clauses);

            var parameter = Expression.Parameter(typeof(TSource), "x");

            Expression exp = Expression<Func<TSource, bool>>.Constant(true);

            foreach (var clause in clauses)
            {
                var clauseExp = BuildClauseExp<TSource>(clause, parameter, funs);
                var clauseExpType = ExpressionType.Default;

                switch (clause.Condition)
                {
                    case ConditionType.None:
                    case ConditionType.And:
                        clauseExpType = ExpressionType.And;
                        break;

                    case ConditionType.Or:
                        clauseExpType = ExpressionType.Or;
                        break;

                    default:
                        throw new NotSupportedException(clause.Condition.ToString());
                }

                exp = Expression<Func<TSource, bool>>.MakeBinary(clauseExpType, exp, clauseExp);
            }

            return Expression.Lambda<Func<TSource, bool>>(exp, parameter);
        }

        private static Expression BuildClauseExp<TSource>(QueryClause clause, ParameterExpression parameter, IEdmFunctions funs = null)
        {
            var memberExp = Expression<Func<TSource, bool>>.Property(parameter, clause.FieldName);
            var propertyType = GetPropertyType(memberExp);
            var propertyValue = ConvertClauseValue(clause.Value, propertyType);
            var propertyValueExp = Expression<Func<TSource, bool>>.Constant(propertyValue, propertyType);

            Expression propertyExp = memberExp;
            if (clause.ValueType == ValueType.Pyszm)
            {
                propertyExp = EdmFunctionsExp.GetPyszmExp<TSource>(propertyExp, funs);
            }

            var expType = ExpressionType.Default;
            switch (clause.Operator)
            {
                case OperatorType.None:
                    expType = ExpressionType.Default;
                    break;

                case OperatorType.Equal:
                    expType = ExpressionType.Equal;
                    break;

                case OperatorType.NotEqual:
                    expType = ExpressionType.NotEqual;
                    break;

                case OperatorType.GreaterThan:
                    expType = ExpressionType.GreaterThan;
                    break;

                case OperatorType.GreaterThanOrEqual:
                    expType = ExpressionType.GreaterThanOrEqual;
                    break;

                case OperatorType.LessThan:
                    expType = ExpressionType.LessThan;
                    break;

                case OperatorType.LessThanOrEqual:
                    expType = ExpressionType.LessThanOrEqual;
                    break;

                case OperatorType.Like:
                    return GetStringContainsExp<TSource>(propertyExp, propertyValueExp, true);

                case OperatorType.NotLike:
                    return GetStringContainsExp<TSource>(propertyExp, propertyValueExp, false);

                case OperatorType.In:
                    //TODO:
                    break;

                default:
                    throw new NotSupportedException(clause.Operator.ToString());
            }

            return Expression<Func<TSource, bool>>.MakeBinary(expType, propertyExp, propertyValueExp);
        }

        private static BinaryExpression GetStringContainsExp<TSource>(Expression instance, Expression argument, bool contains)
        {
            var trueExp = Expression<Func<TSource, bool>>.Constant(true);
            var containsExp = Expression<Func<TSource, bool>>.Call(instance, typeof(string).GetMethod("Contains"), argument);
            return Expression<Func<TSource, bool>>.MakeBinary(contains ? ExpressionType.Equal : ExpressionType.NotEqual, containsExp, trueExp);
        }

        private static Type GetPropertyType(MemberExpression exp)
        {
            if (exp.Member.MemberType == MemberTypes.Property)
            {
                return (exp.Member as PropertyInfo).PropertyType;
            }

            if (exp.Member.MemberType == MemberTypes.Field)
            {
                return (exp.Member as FieldInfo).FieldType;
            }

            throw new NotSupportedException(exp.Member.MemberType.ToString());
        }

        private static object ConvertClauseValue(object value, Type valueType)
        {
            try
            {
                return Convert.ChangeType(value, valueType);
            }
            catch
            {
                return value;
            }
        }

        private static void ConvertClauseValue<TSource>(IEnumerable<QueryClause> clauses, IEnumerable<PropertyInfo> propertyInfos = null)
        {
            var clausesLeft = clauses.ToList(); // clone
            var clausesDeal = new List<QueryClause>();
            var values = new Dictionary<string, object>(StringComparer.OrdinalIgnoreCase);
            foreach (var clause in clauses)
            {
                if (string.IsNullOrWhiteSpace(clause.FieldName))
                {
                    continue;
                }

                if (!values.ContainsKey(clause.FieldName))
                {
                    values.Add(clause.FieldName, clause.Value);
                    clausesDeal.Add(clause);
                    clausesLeft.Remove(clause);
                }
            }

            if (clausesDeal.Count > 0)
            {
                var mapper = CreateMapper();
                var instance = mapper.Map<TSource>(values);

                if (propertyInfos == null)
                {
                    propertyInfos = typeof(TSource)
                        .GetProperties()
                        .Where(x => x.CanRead)
                        .Where(x => x.CanWrite)
                        .ToList();
                }

                foreach (var item in clausesDeal)
                {
                    var propertyInfo = propertyInfos.FirstOrDefault(x => x.Name.Equals(item.FieldName, StringComparison.OrdinalIgnoreCase));
                    if (propertyInfo != null) { item.Value = propertyInfo.GetValue(instance); }
                }

                if (clausesLeft.Count > 0)
                {
                    ConvertClauseValue<TSource>(clausesLeft, propertyInfos);
                }
            }
        }

        private static IMapper CreateMapper()
        {
            var config = new MapperConfiguration(cfg => { });

            var mapper = config.CreateMapper();

            return mapper;
        }
    }
}
