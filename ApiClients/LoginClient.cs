using ApiClients.Models.Account;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;

namespace ApiClients
{
    public class LoginClient
    {
        public string PostToken(string baseUrl)
        {
            using (var client = new HttpClient())
            {
                var tokenModel = new Token { GrantType = "password", UserName = "test@test.test", Password = "qwert123" };
                var formContent = new FormUrlEncodedContent(new[]
                    {
                         new KeyValuePair<string, string>("grant_type", "password"),
                         new KeyValuePair<string, string>("username", "test@test.test"),
                         new KeyValuePair<string, string>("password", "qwert123"),
                         });
                client.BaseAddress = new Uri(baseUrl);
                var response = client.PostAsync(@"/Token", formContent).Result;
                var responseJson = response.Content.ReadAsStringAsync().Result;
                var jObject = JObject.Parse(responseJson);
                return jObject.GetValue("access_token").ToString();
            }
        }
    }
}
