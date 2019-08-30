
	由于主键设置了 auto_increment 导致添加时设置的主键值无效。

解决：

在主键值上添加注解：

	[DatabaseGenerated(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.None)]//不自动增长

[https://blog.csdn.net/u011872945/article/details/72960023](https://blog.csdn.net/u011872945/article/details/72960023 "参考")

扩展直接继承DatabaseGenerated特性使用指定的值，减少代码量。

[https://www.cnblogs.com/sccd/p/5942712.html](https://www.cnblogs.com/sccd/p/5942712.html "ASP.Net Web.config 中引用外部config文件")

error:iis访问出错 0x80070003 配置错误 无法读取配置文件

[https://blog.csdn.net/qq_36535245/article/details/79959638](https://blog.csdn.net/qq_36535245/article/details/79959638 "参考文章")

iis重新配置网站，好了。。。。。。，奇葩

### error:odata client 不支持 datetime ###

原因: Simple.Odata.V4.Client 仅支持DateTimeOffSet

解决：将odata相关包相关nuget删除 仅添加Simple.Odata.Client

[https://github.com/OData/WebApi/issues/136](https://github.com/OData/WebApi/issues/136 "相关issues")

> 注：在ef将类的属性设为virtual时，ef会根据主外键自动加载。

### 使用Func作为OrderBy的参数时查询过长 ###

解决：使用Expression<Func<TSource, TKey>> 而不使用 Func


----------

record:User/Role/Product/Order相关迁移，deep in ef,环境搭建，配置文件迁移

next target: 重构 Vlxm.LH.Service.Controllers.OrdersActionController.GetOrders

----------
since:8/30/2019 10:27:10 AM 