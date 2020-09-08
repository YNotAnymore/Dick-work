using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Extension
{
	public static class LinqExt
	{

		public static System.Linq.Expressions.Expression<Func<T, bool>> OrElse<T>(this System.Linq.Expressions.Expression<Func<T, bool>> one, System.Linq.Expressions.Expression<Func<T, bool>> another)
		{
			var parameterReplacer = new ParameterReplacer(one.Parameters[0], another.Parameters[0]);
			var right = parameterReplacer.Replace(another.Body);
			var body = System.Linq.Expressions.Expression.OrElse(one.Body, right);

			return System.Linq.Expressions.Expression.Lambda<Func<T, bool>>(body, parameterReplacer.ParameterExpression);
		}
		public static System.Linq.Expressions.Expression<Func<T, bool>> AndAlso<T>(this System.Linq.Expressions.Expression<Func<T, bool>> one, System.Linq.Expressions.Expression<Func<T, bool>> another)
		{
			if (one == null) return another;
			if (another == null) return one;
			var parameterReplacer = new ParameterReplacer(one.Parameters[0], another.Parameters[0]);
			var right = parameterReplacer.Replace(another.Body);
			var body = System.Linq.Expressions.Expression.AndAlso(one.Body, right);

			return System.Linq.Expressions.Expression.Lambda<Func<T, bool>>(body, parameterReplacer.ParameterExpression);
		}

		private class ParameterReplacer : System.Linq.Expressions.ExpressionVisitor
		{
			public ParameterReplacer(System.Linq.Expressions.ParameterExpression paramExpr, System.Linq.Expressions.ParameterExpression oldParamExpr0)
			{
				this.ParameterExpression = paramExpr;
				this.OldParameterExpression0 = oldParamExpr0;
			}

			public readonly System.Linq.Expressions.ParameterExpression ParameterExpression;
			public readonly System.Linq.Expressions.ParameterExpression OldParameterExpression0;
			/// <summary>
			/// 调度表达式
			/// </summary>
			/// <param name="expr"></param>
			/// <returns></returns>
			public System.Linq.Expressions.Expression Replace(System.Linq.Expressions.Expression expr)
			{
				return this.Visit(expr);
			}

			protected override System.Linq.Expressions.Expression VisitParameter(System.Linq.Expressions.ParameterExpression p)
			{
				if (ReferenceEquals(p, OldParameterExpression0))
					return this.ParameterExpression;
				else
					return p;
			}
		}

	}
}
