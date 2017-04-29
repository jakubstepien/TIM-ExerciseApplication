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
        public ValuesClient(string baseUrl, string token) : base(baseUrl, token)
        {
        }

        public IEnumerable<string> GetValues()
        {
            using (var client = new HttpClient())
            {
                SetBaseUrlAndToken(client);
                var response = client.GetAsync("api/Values").Result;
                var responseJson = response.Content.ReadAsStringAsync().Result;

                //dodać obsugle bledu

                var values = Newtonsoft.Json.JsonConvert.DeserializeObject<string[]>(responseJson);
                return values;
            }
        }
    }
}
