using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ApiClients
{
    public abstract class AuthorizedDataClient : BaseClient
    {
        protected string token;

        public AuthorizedDataClient(string token)
        {
            this.token = token;
        }

        protected async Task<Response<T>> SendRequest<T>(HttpMethod method, string url) where T : class
        {
            HttpResponseMessage response = await Send(method, url);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var deserilizedObject = Newtonsoft.Json.JsonConvert.DeserializeObject<T>(content);
                return new Response<T> { Success = true, Data = deserilizedObject };
            }
            else
            {
                return new Response<T> { Success = false, Message = response.StatusCode.ToString() };
            }
        }

        protected async Task<Response> SendRequest(HttpMethod method, string url)
        {
            HttpResponseMessage response = await Send(method, url);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                return new Response { Success = true };
            }
            else
            {
                return new Response { Success = false, Message = response.StatusCode.ToString() };
            }
        }

        private async Task<HttpResponseMessage> Send(HttpMethod method, string url)
        {
            var request = GetAuthorizedRequest(method, url);
            var response = await client.SendAsync(request);
            return response;
        }

        protected HttpRequestMessage GetAuthorizedRequest(HttpMethod method, string relativeAdress)
        {
            var request = GetRequest(method, relativeAdress);
            request.Headers.Add("Authorization", "Bearer " + token);
            return request;
        }

    }
}
