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

        protected HttpRequestMessage GetAuthorizedRequest(HttpMethod method, string relativeAdress)
        {
            var request = GetRequest(method, relativeAdress);
            request.Headers.Add("Authorization", "Bearer " + token);
            return request;
        }
    }
}
