﻿using ApiClients.Models.Account;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;

namespace ApiClients
{
    public class LoginClient : BaseClient
    {
        public string GetToken()
        {
            var request = GetRequest(HttpMethod.Post, "/Token");
            //json jako Content requesta nie działa musi byc FormUrlEncodedContent
            var formContent = new FormUrlEncodedContent(
                new[]
                {
                    new KeyValuePair<string, string>("grant_type", "password"),
                    new KeyValuePair<string, string>("username", "test@test.test"),
                    new KeyValuePair<string, string>("password", "qwert123"),
                });
            request.Content = formContent;

            var response = client.SendAsync(request).Result;

            //dodac obsluge bledu

            var responseJson = response.Content.ReadAsStringAsync().Result;
            var jObject = JObject.Parse(responseJson);
            return jObject.GetValue("access_token").ToString();
        }
    }
}
