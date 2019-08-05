using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MediatRDemo.CusMessage;
using MediatRDemo.CusService;
using Newtonsoft.Json;

namespace MediatRDemo.CusEventHandle
{
  /// <summary>
  /// @desc : SomeEventHandler  
  /// @author : monster_yj
  /// @create : 2019/8/4 11:32:32 
  /// @source : 
  /// </summary>
  public class SomeEventHandler:INotificationHandler<SomeMessage>,IDisposable
  {

    public SomeEventHandler() { }

    public async Task Handle(SomeMessage notification, CancellationToken cancellationToken)
    {

      Console.WriteLine($"收到消息：{JsonConvert.SerializeObject(notification)}");


       await new SomeService().Method();
    }

    public void Dispose()
    {
      Console.WriteLine("Handler disposed at :{0}", DateTime.Now);
    }
  }
}
