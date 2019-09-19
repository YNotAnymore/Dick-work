using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Newbe.Mahua.Plugins.Parrot.Chat
{
    /// <summary>
    /// @auth : monster
    /// @since : 2019/9/19 16:56:23
    /// @source : 
    /// @des : 
    /// </summary>
    public class XiaoBingRobot
    {

        private const string DefaultName = "小冰";
        
        public string Name { get; set; }

        public XiaoBingRobot(string name)
        {
            Name = name;
        }

        public void SendMsg(string str)
        {
            using (var client = new HttpClient())
            {
                client.PostAsync("https://m.weibo.cn/msgDeal/sendMsg?content=在干嘛&uid=5175429989&st=0b66e9", null);
            }
        }
        
    }
}
