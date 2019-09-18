
asp.net mvc 处理JsonResult返回格式：

1.配置global[无效]

	// JSON格式增加时区
    var JsonFormatter = new JsonMediaTypeFormatter();
    JsonFormatter.SerializerSettings.DateTimeZoneHandling = DateTimeZoneHandling.Local;

    GlobalConfiguration.Configuration.Formatters.Clear();
    GlobalConfiguration.Configuration.Formatters.Add(JsonFormatter);

2.继承JsonResult重写其方法

3.处理Odata 适配

### linq生成sql错误 [mysql] ###

在linq中的最终的select中的列又加入相关的linq查询 可能引起(别名错误)

ps: sqlserver 可以使用子查询中的别名  mysql 不行

----------
since:9/5/2019 10:12:34 AM 