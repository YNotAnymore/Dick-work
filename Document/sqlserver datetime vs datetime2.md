#### SQL Server中DateTime与DateTime2的区别 ####

DateTime字段类型对应的时间格式是 **yyyy-MM-dd HH:mm:ss.fff** ，3个f，精确到1毫秒(ms)，


> 示例 2014-12-03 17:06:15.433 。

DateTime2字段类型对应的时间格式是** yyyy-MM-dd HH:mm:ss.fffffff** ，7个f，精确到0.1微秒(μs)，


> 示例 2014-12-03 17:23:19.2880929 。

如果用SQL的日期函数进行赋值，DateTime字段类型要用 **GETDATE()** ，DateTime2字段类型要用 **SYSDATETIME() **。


----------
datetime并不能精确到1毫秒，是1/300秒，一般而且是近视取离最近的有效值，比如.006可能变成存储.007,如果指定查询条件时也是一样的

这个就是sqlserver存储引擎决定的了，datetime在存储时只能做到这个精度，datetime存储时是分为日期和时间分开存储的

----------

[https://www.cnblogs.com/dudu/p/sql-server-datetime-vs-datetime2.html](https://www.cnblogs.com/dudu/p/sql-server-datetime-vs-datetime2.html "博文")