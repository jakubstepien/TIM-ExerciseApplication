using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MobileApp.ViewModels.Statistics;
using ApiClients;

namespace MobileApp.Services.Statistics
{
    public class StatisticsService : AuthorizedService, IStatisticsService
    {

        public async Task<ServiceResult<IEnumerable<FinishedExcercise>>> GetBetweenDate(DateTime after, DateTime before)
        {
            var client = new ExcerciseClient(token);
            var response = await client.GetFinishedExerciseByDate(userId, new ApiClients.Models.FinishedExerciseRequest { After = after, Before = before });
            var result = new ServiceResult<IEnumerable<FinishedExcercise>> { Success = response.Success, Message = response.Message };
            if (response.Success)
            {
                result.Result = response.Data.Select(s => new FinishedExcercise
                {
                    Name = s.Name,
                    Callories = s.Callories,
                    Date = s.Date
                });
            }
            return result;
        }
    }
}
