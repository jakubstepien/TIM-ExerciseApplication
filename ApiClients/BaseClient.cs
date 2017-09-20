using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ApiClients
{
    public abstract class BaseClient
    {
        protected static HttpClient client = new HttpClient();
        public static void Init(string url = "http://192.168.1.8")
        {
            //dodać konfiguracje tego na starcie aplikacji
            client.BaseAddress = new Uri(url);
        }


        protected HttpRequestMessage GetRequest(HttpMethod method, string relativeAdress)
        {
            return new HttpRequestMessage(method, relativeAdress);
        }

        protected void WriteRequestBodyJson<T>(HttpRequestMessage request, T obj)
        {
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(obj);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            request.Content = content;
        }

    }
}
