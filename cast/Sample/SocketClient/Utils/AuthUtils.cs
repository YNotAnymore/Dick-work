using Newtonsoft.Json;
using SignalR.SocketClientDemo.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.SocketClientDemo.Utils
{
    /// <summary>
    /// @auth : monster
    /// @since : 6/9/2021 10:32:34 AM
    /// @source : 
    /// @des : 
    /// </summary>
    public class AuthUtils
    {

        public static async Task<CommonRes> GetConnectionToken(HttpClient client, string accessToken)
        {

            HttpResponseMessage httpResponseMessage = await client.PostAsync($"{CommonConst.BaseUrl}/msgapi/chatHub/negotiate?negotiateVersion=1&access_token={accessToken}", new StringContent(""));

            string connectionToken;

            if (httpResponseMessage.IsSuccessStatusCode)
            {
                string resJson = await httpResponseMessage.Content.ReadAsStringAsync();

                dynamic json = JsonConvert.DeserializeObject<dynamic>(resJson);

                connectionToken = json.connectionToken;
                return new CommonRes() { Success = true, Res = connectionToken };
            }
            return default;

        }
        public static async Task<CommonRes> GetToken(HttpClient client, string phone)
        {

            HttpResponseMessage loginRes = await client.PostAsync($"{CommonConst.BaseUrl}/Member/Account/Login", new StringContent("{\"Phone\":\"" + phone + "\",\"Pwd\":\"1\"}", Encoding.UTF8, MediaTypeNames.Application.Json));

            string token;

            if (loginRes.IsSuccessStatusCode)
            {
                string resJson = await loginRes.Content.ReadAsStringAsync();

                BaseRes baseRes = JsonConvert.DeserializeObject<BaseRes>(resJson);

                if (baseRes.IsSuccess())
                {
                    token = baseRes.Data;
                    return new CommonRes() { Success = true, Res = token };
                }
                else
                {
                    Console.WriteLine($"登录异常：{resJson}");
                }
            }
            return default;

        }

    }

    public struct CommonRes
    {
        public bool Success { get; set; }
        public string Res { get; set; }
    }

}
