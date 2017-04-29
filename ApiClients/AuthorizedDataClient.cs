using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ApiClients
{
    public abstract class AuthorizedDataClient
    {
        protected string token;
        protected string baseUrl;

        public AuthorizedDataClient(string baseUrl, string token)
        {
            this.token = token;
            this.baseUrl = baseUrl;
        }

        protected void SetBaseUrlAndToken(HttpClient client)
        {
            client.BaseAddress = new Uri(baseUrl);
            client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
        }
    }
}
