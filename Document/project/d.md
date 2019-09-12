
asp.net mvc 处理JsonResult返回格式：

1.配置global[无效]

	// JSON格式增加时区
    var JsonFormatter = new JsonMediaTypeFormatter();
    JsonFormatter.SerializerSettings.DateTimeZoneHandling = DateTimeZoneHandling.Local;

    GlobalConfiguration.Configuration.Formatters.Clear();
    GlobalConfiguration.Configuration.Formatters.Add(JsonFormatter);

2.继承JsonResult重写其方法

3.处理Odata 适配

----------
since:9/5/2019 10:12:34 AM 