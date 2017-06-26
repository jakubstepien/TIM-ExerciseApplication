using ApiClients.Models;
using ApiClients.Models.DTO;
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

        public async Task<Response> AddTraining(TrainingDTO training)
        {
            string url = "api/Trainings/";
            var response = await SendRequest(HttpMethod.Post, url, training);
            return response;
        }

        public async Task<Response<IEnumerable<TrainingDTO>>> GetTrainings(Guid userId)
        {
            string url = "api/Trainings/user/" + userId.ToString() + "/";
            var response = await SendRequest<IEnumerable<TrainingDTO>>(HttpMethod.Get, url);
            return response;
        }

        public async Task<Response<TrainingDTO>> GetTraining(Guid id)
        {
            string url = "api/Trainings/" + id.ToString() + "/";
            var response = await SendRequest<TrainingDTO>(HttpMethod.Get, url);
            return response;
        }

        public async Task<Response> DeleteTraining(Guid id)
        {
            string url = "api/Trainings/" + id.ToString() + "/";
            var response = await SendRequest(HttpMethod.Delete, url);
            return response;
        }

        public async Task<Response> AddFinishedTraining(Guid userId, FinishedTrainingDTO finishedTraining)
        {
            string url = "api/Trainings/finished/user/" + userId + "/";
            var response = await SendRequest(HttpMethod.Post, url, finishedTraining);
            return response;
        }
    }
}
