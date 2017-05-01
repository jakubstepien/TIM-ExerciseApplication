using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ApiClients
{
    public class ValuesClient : AuthorizedDataClient
    {
        public ValuesClient(string token) : base(token)
        {
        }

        public IEnumerable<string> GetValues()
        {
            var request = GetAuthorizedRequest(HttpMethod.Get, "api/Values");
            var response = client.SendAsync(request).Result;
            var responseJson = response.Content.ReadAsStringAsync().Result;

            var values = Newtonsoft.Json.JsonConvert.DeserializeObject<string[]>(responseJson);
            return values;
        }
    }
}
