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

        protected async Task<Response<TResponseType>> SendRequest<TResponseType>(HttpMethod method, string url)
        {
            HttpResponseMessage response = await Send(method, url);
            return await ParseResponse<TResponseType>(response);
        }

        protected async Task<Response<TResponseType>> SendRequest<TResponseType,TRequestBody>(HttpMethod method, string url, TRequestBody data)
        {
            HttpResponseMessage response = await Send(method, url, data);
            return await ParseResponse<TResponseType>(response);
        }

        private async Task<Response<TResponseType>> ParseResponse<TResponseType>(HttpResponseMessage response)
        {
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var deserilizedObject = Newtonsoft.Json.JsonConvert.DeserializeObject<TResponseType>(content);
                return new Response<TResponseType> { Success = true, Data = deserilizedObject };
            }
            else
            {
                return new Response<TResponseType> { Success = false, Message = response.StatusCode.ToString() };
            }
        }

        protected async Task<Response> SendRequest(HttpMethod method, string url)
        {
            HttpResponseMessage response = await Send(method, url);
            return ParseResponse(response);
        }

        protected async Task<Response> SendRequest<TRequestBody>(HttpMethod method, string url, TRequestBody data)
        {
            HttpResponseMessage response = await Send(method, url, data);
            return ParseResponse(response);
        }

        private Response ParseResponse(HttpResponseMessage response)
        {
            if (response.IsSuccessStatusCode)
            {
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

        private async Task<HttpResponseMessage> Send<TRequestBody>(HttpMethod method, string url, TRequestBody data)
        {
            var request = GetAuthorizedRequest(method, url);
            WriteRequestBodyJson(request, data);
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
