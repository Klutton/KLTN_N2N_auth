using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Nyan_n2n.Common.Models;

namespace Nyan_n2n.Common.Authentication
{
    public class ConnectServer
    {
        public static async Task<LoginRes> Con(string serverAddr, string username, string password)
        {
            using (var client = new HttpClient())
            {
                var values = new Dictionary<string, string>
                {
                    { "username", username },
                    { "password", password },
                    { "key", "QSD>ak)as[d6a5d4AFfm.+faSD51" }
                };

                var content = new FormUrlEncodedContent(values);

                var response = await client.PostAsync(serverAddr, content);

                var responseString = await response.Content.ReadAsStringAsync();

                var resData = new LoginRes(false);

                if (!response.IsSuccessStatusCode && response.Content.Headers.ContentType.MediaType == "application/json")
                    return resData;

                resData.Success = true;

                var data = JsonConvert.DeserializeObject<Dictionary<string, object>>(responseString);

                resData.ServerName = data["server_name"].ToString();

                resData.ServerInfo = data["server_info"].ToString();

                resData.Servers = JsonConvert.DeserializeObject<List<string>>(data["servers"].ToString());

                return resData;
            }
        }
    }
}
