using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace UA.Core.Infrastructure.Extension
{
    public static class LinqExt
    {

        #region get expression

        public static Expression<Func<T, bool>> GetWhereExpression<T>(IQueryable<T> queryable)
        {
            if (queryable.Expression is MethodCallExpression methodCallExpression)
            {
                return GetWhereExpression<T>(methodCallExpression);
            }
            return null;
        }

        public static Expression<Func<T, bool>> GetWhereExpression<T>(this MethodCallExpression expression)
        {
            Expression<Func<T, bool>> where = null;

            if (expression.Arguments[1] is UnaryExpression unary) where = unary.Operand as Expression<Func<T, bool>>;

            if (expression.Arguments[0] is MethodCallExpression methodCallExpression)
                return where.AndAlso(GetWhereExpression<T>(methodCallExpression));
            return where;
        }

        /// <summary>
        /// 获取排序表达式
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <param name="propName">属性名（支持一级）</param>
        /// <param name="orderArr">对应的排序值，下标表示排序值</param>
        /// <param name="defaultOrder">默认排序值</param>
        /// <returns></returns>
        public static Expression<Func<T, int>> GetOrderExpression<T, T2>(string propName, T2[] orderArr, int defaultOrder = int.MaxValue)
        {
            ParameterExpression parameterExpression = Expression.Parameter(typeof(T));

            MemberExpression memberExpression = Expression.Property(parameterExpression, propName);

            Expression elseExpression = Expression.Constant(defaultOrder);

            for (int i = 0; i < orderArr.Length; i++)
            {
                var t = orderArr[i];
                var orderNum = i;
                elseExpression = Expression.Condition(
                          Expression.Equal(memberExpression, Expression.Constant(t))
                          , Expression.Constant(orderNum)
                          , elseExpression
                      );

            }
            return Expression.Lambda<Func<T, int>>(elseExpression, parameterExpression);
        }

        #endregion

        #region left join
        public class GroupResult<Touter, TInner>
        {
            public Touter Outer { get; set; }
            public IEnumerable<TInner> Inner { get; set; }
        }

        public static IQueryable<TResult> LeftJoin<TOuter, TInner, TKey, TGroupResult, TResult>(this IQueryable<TOuter> outerQueryable, IEnumerable<TInner> innerQueryable, Expression<Func<TOuter, TKey>> outerKeySelector, Expression<Func<TInner, TKey>> innerKeySelector, Expression<Func<TOuter, IEnumerable<TInner>, TGroupResult>> resultSelector, Expression<Func<TGroupResult, IEnumerable<TInner>>> collectionSelector, Expression<Func<TGroupResult, TInner, TResult>> selector)
        {
            return outerQueryable.GroupJoin(innerQueryable, outerKeySelector, innerKeySelector, resultSelector)
                .SelectMany(collectionSelector, selector);
        }
        /// <summary>
        /// 一对一 left join
        /// </summary>
        /// <typeparam name="TOuter"></typeparam>
        /// <typeparam name="TInner"></typeparam>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="outerQueryable"></param>
        /// <param name="innerQueryable"></param>
        /// <param name="outerKeySelector"></param>
        /// <param name="innerKeySelector"></param>
        /// <param name="selector"></param>
        /// <returns></returns>
        public static IQueryable<TResult> LeftJoin<TOuter, TInner, TKey, TResult>(this IQueryable<TOuter> outerQueryable, IEnumerable<TInner> innerQueryable, Expression<Func<TOuter, TKey>> outerKeySelector, Expression<Func<TInner, TKey>> innerKeySelector, Expression<Func<GroupResult<TOuter, TInner>, TInner, TResult>> selector) => outerQueryable.LeftJoin(innerQueryable, outerKeySelector, innerKeySelector, (outer, inner) => new GroupResult<TOuter, TInner> { Outer = outer, Inner = inner }, combination => combination.Inner.DefaultIfEmpty(), selector);
        #endregion

        #region combination predicate
        public static Expression<Func<T, bool>> OrElse<T>(this Expression<Func<T, bool>> one, Expression<Func<T, bool>> another)
        {
            var parameterReplacer = new ParameterReplacer(one.Parameters[0], another.Parameters[0]);
            var right = parameterReplacer.Replace(another.Body);
            var body = Expression.OrElse(one.Body, right);

            return Expression.Lambda<Func<T, bool>>(body, parameterReplacer.ParameterExpression);
        }
        public static Expression<Func<T, bool>> AndAlso<T>(this Expression<Func<T, bool>> one, Expression<Func<T, bool>> another)
        {
            if (one == null) return another;
            if (another == null) return one;
            var parameterReplacer = new ParameterReplacer(one.Parameters[0], another.Parameters[0]);
            var right = parameterReplacer.Replace(another.Body);
            var body = Expression.AndAlso(one.Body, right);

            return Expression.Lambda<Func<T, bool>>(body, parameterReplacer.ParameterExpression);
        }
        #endregion

        #region inner struct
        private class ParameterReplacer : ExpressionVisitor
        {
            public ParameterReplacer(ParameterExpression paramExpr, ParameterExpression oldParamExpr0)
            {
                this.ParameterExpression = paramExpr;
                this.OldParameterExpression0 = oldParamExpr0;
            }

            public readonly ParameterExpression ParameterExpression;
            public readonly ParameterExpression OldParameterExpression0;
            /// <summary>
            /// 调度表达式
            /// </summary>
            /// <param name="expr"></param>
            /// <returns></returns>
            public Expression Replace(Expression expr)
            {
                return this.Visit(expr);
            }

            protected override Expression VisitParameter(ParameterExpression p)
            {
                if (ReferenceEquals(p, OldParameterExpression0))
                    return this.ParameterExpression;
                else
                    return p;
            }
        }
        #endregion

    }
}
