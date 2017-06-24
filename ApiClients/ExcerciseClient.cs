using ApiClients.Model.DTO;
using ApiClients.Models;
using ApiClients.Models.Account;
using ApiClients.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ApiClients
{
    public class ExcerciseClient : AuthorizedDataClient
    {
        public ExcerciseClient(string token) : base(token)
        {
        }

        public async Task<Response<IEnumerable<ExerciseDTO>>> GetExercises(Guid userId)
        {
            string url = "api/exercises/user/" + userId + "/";
            var response = await SendRequest<IEnumerable<ExerciseDTO>>(HttpMethod.Get, url);
            return response;
        }

        public async Task<Response<ExerciseDTO>> GetExercise(Guid id)
        {
            string url = "api/Exercises/" + id + "/";
            var response = await SendRequest<ExerciseDTO>(HttpMethod.Get, url);
            return response;
        }

        public async Task<Response> UpdateExercise(Guid id, ExerciseDTO exercise)
        {
            string url = "api/Exercises/" + id + "/";
            var response = await SendRequest(HttpMethod.Put, url, exercise);
            return response;
        }

        public async Task<Response> AddExercise(Guid userId, ExerciseDTO exercise)
        {
            string url = "api/exercises/user/" + userId + "/";
            var response = await SendRequest(HttpMethod.Post, url, exercise);
            return response;
        }

        public async Task<Response> DeleteExerciseFromUser(Guid id, Guid userId)
        {
            string url = "api/exercises/" + id + "/user/" + userId + "/";
            var response = await SendRequest(HttpMethod.Delete, url);
            return response;
        }

        public async Task<Response<bool>> FavouriteExercise(Guid id, Guid userId)
        {
            string url = "api/exercises/favourite/" + id + "/user/" + userId + "/";
            var response = await SendRequest<bool>(HttpMethod.Post, url);
            return response;
        }

        public async Task<Response> AddFinishedExercise(Guid userId, FinishedExerciseDTO finishedExercise)
        {
            string url = "api/exercises/finished/user/"+ userId +"/";
            var response = await SendRequest(HttpMethod.Post, url, finishedExercise);
            return response;
        }

        public async Task<Response<IEnumerable<FinishedExerciseDTO>>> GetFinishedExerciseByDate(Guid userId, FinishedExerciseRequest finishedExercise)
        {
            string url = "api/exercises/statistics/user/" + userId + "/";
            var response = await SendRequest<IEnumerable<FinishedExerciseDTO>, FinishedExerciseRequest>(HttpMethod.Post, url, finishedExercise);
            return response;
        }
    }
}
