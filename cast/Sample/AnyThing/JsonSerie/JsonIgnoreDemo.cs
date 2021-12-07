using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnyThing.JsonSerie
{


    public class Data
    {
        public string Name { get; set; }
        [JsonIgnore]
        public string Name2 { get; set; }
        [JsonIgnore]
        public string Name3 { get; set; }
    }

    /// <summary>
    /// @auth : monster
    /// @since : 2021/11/28 星期日 23:44:58
    /// @source : 
    /// @des : 
    /// </summary>
    public class JsonIgnoreDemo
    {

        public static void Run()
        {

            var data = new Data() { Name = "Name", Name2 = "Name2", Name3 = "Name3" };

            var setting = new JsonSerializerSettings
            {
                ContractResolver = new ContractAllPropResolver()
            };

            string v = JsonConvert.SerializeObject(data, setting);

            var t = JsonConvert.DeserializeObject<Data>(v, setting);

        }

    }

    /// <summary>
    /// 输出所有属性（无视jsonIgnore）
    /// </summary>
    public class ContractAllPropResolver : DefaultContractResolver
    {

        protected override IList<JsonProperty> CreateProperties(Type type, MemberSerialization memberSerialization)
        {
            var props = base.CreateProperties(type, memberSerialization);

            foreach (var prop in props)
            {
                // 取消属性忽略
                prop.Ignored = false;
            }

            return props;
        }
    }

}
