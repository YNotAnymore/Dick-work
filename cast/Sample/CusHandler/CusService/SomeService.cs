using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MediatRDemo.CusService
{
  /// <summary>
  /// @desc : SomeService  
  /// @author : monster_yj
  /// @create : 2019/8/4 11:36:10 
  /// @source : 
  /// </summary>
  public class SomeService
  {
    public async Task Method()
    {
      Console.WriteLine("SomeService 开始处理");
      await Task.Delay(5000);
      //_logger.LogDebug("当前用户:{0}", _context.CurrentUser);
      Console.WriteLine("SomeService Method at :{0}", DateTime.Now);
    }

  }
}
