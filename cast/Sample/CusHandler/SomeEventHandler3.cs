using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MediatRDemo.CusMessage;
using MediatRDemo.CusService;

namespace MediatRDemo.CusEventHandle
{
  /// <summary>
  /// @desc : SomeEventHandler  
  /// @author : monster_yj
  /// @create : 2019/8/4 11:32:32 
  /// @source : 
  /// </summary>
  public class SomeEventHandler3:INotificationHandler<SomeMessage>,IDisposable
  {

    public SomeEventHandler3() { }

    public async Task Handle(SomeMessage notification, CancellationToken cancellationToken)
    {

      Console.WriteLine($"SomeEventHandler3 收到消息：{notification.Msg}");


       await new SomeService().Method();
    }

    public void Dispose()
    {
      Console.WriteLine("SomeEventHandler3 Handler disposed at :{0}", DateTime.Now);
    }
  }
}
