using ApiClients.Models.Account;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;

namespace ApiClients
{
    public class AccountClient : BaseClient
    {
        public string GetToken(string email, string password)
        {
            var request = GetRequest(HttpMethod.Post, "/Token");
            //json jako Content requesta nie działa musi byc FormUrlEncodedContent
            var formContent = new FormUrlEncodedContent(
                new[]
                {
                    new KeyValuePair<string, string>("grant_type", "password"),
                    new KeyValuePair<string, string>("username", email),
                    new KeyValuePair<string, string>("password", password),
                });
            request.Content = formContent;

            var response = client.SendAsync(request).Result;

            if (!response.IsSuccessStatusCode)
            {
                return null;
            }

            var responseJson = response.Content.ReadAsStringAsync().Result;
            var jObject = JObject.Parse(responseJson);
            return jObject.GetValue("access_token").ToString();
        }

        public bool Register(RegisterData data)
        {
            var request = GetRequest(HttpMethod.Post,"/api/Account/Register");
            WriteRequestBodyJson(request, data);
            var response = client.SendAsync(request).Result;
            return response.IsSuccessStatusCode;
        }
    }
}
