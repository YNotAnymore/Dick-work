### 1.db migration ###

> target sqlserver db to mysql

a. download mysql

[https://dev.mysql.com/downloads/](https://dev.mysql.com/downloads/ "mysql downloads url")

[https://www.jianshu.com/p/710e5861c198](https://www.jianshu.com/p/710e5861c198 "windows环境下配置mysql")

[https://blog.csdn.net/yulutian/article/details/78971369](https://blog.csdn.net/yulutian/article/details/78971369 "缺失my.ini文件")


	mysqld --initialize

**error:**mysql启动失败：mysql服务无法启动

**solution:**删除根目录的my.ini 将 my.ini 放入bin目录下


	heidiSql连接时：

	mysql authentication plugin 'caching_sha2_password' cannot be loaded:找不到指定模块

[https://stackoverflow.com/questions/49194719/authentication-plugin-caching-sha2-password-cannot-be-loaded](https://stackoverflow.com/questions/49194719/authentication-plugin-caching-sha2-password-cannot-be-loaded "参考文章")

	 solution: ALTER USER 'root'@'127.0.0.1' IDENTIFIED WITH mysql_native_password BY 'root';

迁移过程:

安装 mysql for net

	error:迁移过程中，未将对象引用设置到对象的实例。

在DbContext添加特性

    [DbConfigurationType(typeof(MySql.Data.Entity.MySqlEFConfiguration))]

error:The underlying provider does not support the type 'nvarchar(max)'.

重新生成迁移文件...

	c.String(unicode: false)


----------

	error:调用context下的dbset属性 未将对象引用设置到对象的实例。

在app.config中添加：

	  <runtime>
	    <assemblyBinding xmlns="urn:schemas-microsoft-com:asm.v1">
	      <dependentAssembly>
	        <assemblyIdentity name="MySql.Data" publicKeyToken="c5687fc88969c44d" culture="neutral" />
	        <bindingRedirect oldVersion="0.0.0.0-8.0.13.0" newVersion="6.10.8.0" />
	      </dependentAssembly>
	    </assemblyBinding>
	  </runtime>

[https://www.twblogs.net/a/5bf6e019bd9eee18cf8a9407/zh-cn](https://www.twblogs.net/a/5bf6e019bd9eee18cf8a9407/zh-cn "帮助文章")


----------

summary:

mysql环境搭建出行无法打开服务、连接不了、没有配置文件、常用命令不熟等问题

迁移时，出现缺少特性注解问题。 然后mysql迁移时必须安装mysql for net

在使用mysql 的 dbContext时 需要在配置文件的runtime下添加相应的dll支持。

业务上存在一系列的主外键关系，导致不能随意复制。

----------
since:8/29/2019 9:48:41 AM 