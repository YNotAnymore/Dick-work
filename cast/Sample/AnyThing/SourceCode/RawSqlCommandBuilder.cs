using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;

namespace AnyThing.SourceCode
{

    public class RawSqlCommandBuilder
    {

		private readonly IRelationalCommandBuilderFactory _relationalCommandBuilderFactory;

		private readonly ISqlGenerationHelper _sqlGenerationHelper;

		private readonly IParameterNameGeneratorFactory _parameterNameGeneratorFactory;

		/// <summary>
		///     This is an internal API that supports the Entity Framework Core infrastructure and not subject to
		///     the same compatibility standards as public APIs. It may be changed or removed without notice in
		///     any release. You should only use it directly in your code with extreme caution and knowing that
		///     doing so can result in application failures when updating to a new Entity Framework Core release.
		/// </summary>
		public RawSqlCommandBuilder( IRelationalCommandBuilderFactory relationalCommandBuilderFactory,  ISqlGenerationHelper sqlGenerationHelper,  IParameterNameGeneratorFactory parameterNameGeneratorFactory)
		{
			//Microsoft.EntityFrameworkCore.Utilities.Check.NotNull(relationalCommandBuilderFactory, "relationalCommandBuilderFactory");
			//Microsoft.EntityFrameworkCore.Utilities.Check.NotNull(sqlGenerationHelper, "sqlGenerationHelper");
			//Microsoft.EntityFrameworkCore.Utilities.Check.NotNull(parameterNameGeneratorFactory, "parameterNameGeneratorFactory");
			_relationalCommandBuilderFactory = relationalCommandBuilderFactory;
			_sqlGenerationHelper = sqlGenerationHelper;
			_parameterNameGeneratorFactory = parameterNameGeneratorFactory;
		}

		///// <summary>
		/////     This is an internal API that supports the Entity Framework Core infrastructure and not subject to
		/////     the same compatibility standards as public APIs. It may be changed or removed without notice in
		/////     any release. You should only use it directly in your code with extreme caution and knowing that
		/////     doing so can result in application failures when updating to a new Entity Framework Core release.
		///// </summary>
		//public virtual IRelationalCommand Build(string sql)
		//{
		//	return _relationalCommandBuilderFactory.Create().Append(Microsoft.EntityFrameworkCore.Utilities.Check.NotEmpty(sql, "sql")).Build();
		//}

		/// <summary>
		///     This is an internal API that supports the Entity Framework Core infrastructure and not subject to
		///     the same compatibility standards as public APIs. It may be changed or removed without notice in
		///     any release. You should only use it directly in your code with extreme caution and knowing that
		///     doing so can result in application failures when updating to a new Entity Framework Core release.
		/// </summary>
		public virtual RawSqlCommand Build(string sql, IEnumerable<object> parameters)
		{
			IRelationalCommandBuilder relationalCommandBuilder = _relationalCommandBuilderFactory.Create();
			List<string> list = new List<string>();
			ParameterNameGenerator parameterNameGenerator = _parameterNameGeneratorFactory.Create();
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			foreach (object parameter in parameters)
			{
				DbParameter dbParameter = parameter as DbParameter;
				if (dbParameter != null)
				{
					if (string.IsNullOrEmpty(dbParameter.ParameterName))
					{
						dbParameter.ParameterName = _sqlGenerationHelper.GenerateParameterName(parameterNameGenerator.GenerateNext());
					}
					list.Add(dbParameter.ParameterName);
					relationalCommandBuilder.AddRawParameter(dbParameter.ParameterName, dbParameter);
				}
				else
				{
					string text = parameterNameGenerator.GenerateNext();
					string text2 = _sqlGenerationHelper.GenerateParameterName(text);
					list.Add(text2);
					relationalCommandBuilder.AddParameter(text, text2);
					dictionary.Add(text, parameter);
				}
			}
			string format = sql;
			object[] args = list.ToArray();
			sql = string.Format(format, args);
			return new RawSqlCommand(relationalCommandBuilder.Append(sql).Build(), dictionary);
		}


	}
}
