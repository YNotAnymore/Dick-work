using System;
using System.Collections.Generic;
using System.Text;
using MediatR;

namespace MediatRDemo.CusMessage
{
  /// <summary>
  /// @desc : SomeMessage  
  /// @author : monster_yj
  /// @create : 2019/8/4 11:33:00 
  /// @source : 
  /// </summary>
  public class SomeMessage : INotification
  {

    public int Id { get; set; }

    public string Msg { get; set; }

  }
}
