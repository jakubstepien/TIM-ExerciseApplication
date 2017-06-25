using ApiClients.Model.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ApiClients
{
    public class TrainingClient : AuthorizedDataClient
    {
        public TrainingClient(string token) : base(token)
        {
        }

        public async Task<Response> AddTraining(TrainingDTO exercise)
        {
            string url = "api/Trainings/";
            var response = await SendRequest(HttpMethod.Post, url, exercise);
            return response;
        }
    }
}
