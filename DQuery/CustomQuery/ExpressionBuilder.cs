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
        #region Build
        public IEdmFunctions EdmFunctions { get; set; }

        public Expression BuildClauseExp<TSource>(List<QueryClause> clauses, ParameterExpression parameter)
        {
            Expression exp = null;

            ConvertClauseValue<TSource>(clauses);

            foreach (var clause in clauses)
            {
                var clauseExpType = ExpressionType.Default;
                switch (clause.Condition)
                {
                    case ConditionType.And:
                        clauseExpType = ExpressionType.And;
                        break;

                    case ConditionType.Or:
                        clauseExpType = ExpressionType.Or;
                        break;

                    case ConditionType.None:
                        if (exp != null) { throw new InvalidOperationException("Missing condition type."); }
                        break;

                    default:
                        throw new NotSupportedException(clause.Condition.ToString());
                }

                Expression clauseExp;
                if (clause.Items.Count > 0)
                {
                    clauseExp = BuildClauseExp<TSource>(clause.Items, parameter);
                }
                else
                {
                    clauseExp = BuildClauseExp<TSource>(clause, parameter);
                }

                if (exp == null)
                {
                    exp = clauseExp;
                }
                else
                {
                    exp = Expression<Func<TSource, bool>>.MakeBinary(clauseExpType, exp, clauseExp);
                }
            }

            return exp;
        }

        public Expression BuildClauseExp<TSource>(QueryClause clause, ParameterExpression parameter)
        {
            var memberExp = Expression<Func<TSource, bool>>.Property(parameter, clause.FieldName);
            var memberValueExp = Expression<Func<TSource, bool>>.Constant(clause.Value, GetMemberType(memberExp.Member));

            Expression composedExp = memberExp;
            if (clause.ExFunction != null)
            {
                var name = (clause.ExFunction.Name ?? string.Empty).ToLower();
                switch (name)
                {
                    case "pyszm":
                        composedExp = GetPyszmExp<TSource>(memberExp, EdmFunctions);
                        break;

                    case "isnull":
                        composedExp = GetIsnullExp<TSource>(memberExp, clause.ExFunction.Parameters);
                        break;
                }
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
                    return GetStringContainsExp<TSource>(composedExp, memberValueExp, true);

                case OperatorType.NotLike:
                    return GetStringContainsExp<TSource>(composedExp, memberValueExp, false);

                case OperatorType.In:
                    //TODO:
                    break;

                default:
                    throw new NotSupportedException(clause.Operator.ToString());
            }

            return Expression<Func<TSource, bool>>.MakeBinary(expType, composedExp, memberValueExp);
        }

        public static Expression<Func<TSource, bool>> Build<TSource>(List<QueryClause> clauses, IEdmFunctions funcs)
        {
            var parameter = Expression.Parameter(typeof(TSource), "x");
            var builder = new ExpressionBuilder { EdmFunctions = funcs };
            var expression = builder.BuildClauseExp<TSource>(clauses, parameter);
            if (expression == null) { expression = Expression<Func<TSource, bool>>.Constant(true); }
            return Expression.Lambda<Func<TSource, bool>>(expression, parameter);
        }

        private static Expression GetStringContainsExp<TSource>(Expression instance, Expression argument, bool contains)
        {
            var trueExp = Expression<Func<TSource, bool>>.Constant(true);
            var containsExp = Expression<Func<TSource, bool>>.Call(instance, typeof(string).GetMethod("Contains"), argument);
            if (!contains) { return Expression<Func<TSource, bool>>.Not(containsExp); }
            return containsExp;
        }

        public static Expression GetIsnullExp<TSource>(MemberExpression member, List<object> parameters)
        {
            var memberType = GetMemberType(member.Member);

            var canBeNull = (!memberType.IsValueType || (Nullable.GetUnderlyingType(memberType) != null));
            if (!canBeNull)
            {
                return member;
            }

            if (parameters == null || parameters.Count == 0)
            {
                throw new ArgumentNullException("Isnull function require a parameter");
            }

            var defaultValue = ConvertValue<TSource>(member.Member, parameters.First());
            var defaultValueExp = Expression<Func<TSource, bool>>.Constant(defaultValue, memberType);

            var nullExp = Expression<Func<TSource, bool>>.Constant(null);
            var compareExp = Expression<Func<TSource, bool>>.MakeBinary(ExpressionType.Equal, member, nullExp);
            return Expression<Func<TSource, bool>>.Condition(compareExp, defaultValueExp, member);
        }

        public static Expression GetPyszmExp<TSource>(MemberExpression argument, IEdmFunctions funcs)
        {
            if (funcs == null)
            {
                throw new NotSupportedException("DQuery functions not specified.");
            }

            var func = funcs.GetPyszmFunc();
            if (func == null)
            {
                throw new NotImplementedException("Pyszm function not implemented.");
            }

            return Expression<Func<TSource, bool>>.Call(null, func.Method, argument);
        }
        #endregion

        #region helpers
        private static Type GetMemberType(MemberInfo member)
        {
            if (member.MemberType == MemberTypes.Property)
            {
                return (member as PropertyInfo).PropertyType;
            }

            if (member.MemberType == MemberTypes.Field)
            {
                return (member as FieldInfo).FieldType;
            }

            throw new NotSupportedException(member.MemberType.ToString());
        }

        private static object ConvertValue<TSource>(MemberInfo member, object value)
        {
            var values = new Dictionary<string, object>();
            values.Add(member.Name, value);

            var mapper = CreateMapper();
            var instance = mapper.Map<TSource>(values);

            if (member.MemberType == MemberTypes.Property)
            {
                return (member as PropertyInfo).GetValue(instance);
            }

            if (member.MemberType == MemberTypes.Field)
            {
                return (member as FieldInfo).GetValue(instance);
            }

            throw new NotSupportedException(member.MemberType.ToString());
        }

        private static void ConvertClauseValue<TSource>(IEnumerable<QueryClause> clauses, IEnumerable<PropertyInfo> propertyInfos = null)
        {
            if (!clauses.Any())
            {
                return;
            }

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
        #endregion
    }
}
