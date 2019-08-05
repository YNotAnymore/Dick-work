using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using Autofac;
using MediatR;
using MediatRDemo.CusEventHandle;
using MediatRDemo.CusMessage;

namespace MediatRDemo
{
  class Program
  {
    static void Main(string[] args)
    {


      #region 使用AutoFac构建

      var builder = new ContainerBuilder();

      #region office

      // first 注册Mediator
      builder
        .RegisterType<Mediator>()
        .As<IMediator>()
        .InstancePerLifetimeScope();

      //注册上下文
      builder.Register<ServiceFactory>(context =>
      {
        var c = context.Resolve<IComponentContext>();
        return t => c.Resolve(t);
      });

      // 定义需要扫描的程序集
      builder.RegisterAssemblyTypes(typeof(Program).Assembly).AsImplementedInterfaces(); // via assembly scan
      builder.RegisterAssemblyTypes(typeof(SomeEventHandler3).Assembly).AsImplementedInterfaces(); // via assembly scan

      var build = builder.Build();

      using (var scope = build.BeginLifetimeScope())
      {
        var officeMediator = scope.Resolve<IMediator>();

        officeMediator.Publish(new SomeMessage()
        {
          Id = 1,
          Msg = "autoFac office test msg"
        });

      }

      #endregion

//      Console.ReadKey(true);
//
//      builder.RegisterType<SomeEventHandler>().As<INotificationHandler<SomeMessage>>();
//      builder.RegisterType<SomeEventHandler2>().As<INotificationHandler<SomeMessage>>();
//
//      var container = builder.Build();
//
//      IMediator autoFacMediator = new Mediator((type =>
//      {
//
//        // get msg type
//        var msgType = type.GenericTypeArguments[0];
//
//        var targetType = typeof(INotificationHandler<>);
//
//        msgType.GenericTypeArguments[0] = msgType;
//
//        using (var scope = container.BeginLifetimeScope())
//        {
//          var info = scope.Resolve(msgType);
//
//          return info;
//        }
//
//      }));

      #endregion

//      autoFacMediator.Publish(new SomeMessage()
//      {
//        Id = 1,
//        Msg = "autoFac test msg"
//      });
//
//      Console.ReadKey(true);

      #region 基本实现

//      IMediator mediator = new Mediator((type =>
//      {
//        return new[]
//        {
//          new SomeEventHandler()
//        };
//
//        var argument = type.GenericTypeArguments[0];//获取泛型类
//
//        Console.WriteLine("------------factory---------------");
//        return type.GetConstructor(new Type[] { }).Invoke(null);
//
//        //System.MissingMethodException:“Cannot create an instance of an interface.”
//        //return Activator.CreateInstance(type);
//      }));
//
//      mediator.Publish(new SomeMessage()
//      {
//        Id = 1,
//        Msg = "test msg"
//      });

      // flow : 发送消息  通过serviceFactory获取接收此消息的对象 IEnumable<INotificationHandler<Msg>> 然后进行调用。

      #endregion
      
      Console.WriteLine("Hello World!");

      Console.ReadKey(true);
    }
  }
}