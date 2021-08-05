using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace Common.Extension
{
    /// <summary>
    /// @auth : monster
    /// @since : 7/5/2021 12:00:54 PM
    /// @source : 
    /// @des : 
    /// </summary>
    public static class JsonElementExt
    {

        public static Dictionary<string, string> GetProp(this JsonElement json)
        {
            Dictionary<string, string> dic = new Dictionary<string, string>();
            if (json.ValueKind == JsonValueKind.Object)
            {
                foreach (var item in json.EnumerateObject())
                {
                    dic[item.Name] = item.Value.GetRawText();
                }
            }
            return dic;
        }

    }
}
