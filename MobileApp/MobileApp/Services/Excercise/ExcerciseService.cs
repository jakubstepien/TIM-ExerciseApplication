using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MobileApp.ViewModels.Exercises;

namespace MobileApp.Services.Excercise
{
    public class ExcerciseService : IExcerciseService
    {
        private readonly Guid userId;
        private readonly string token;

        public ExcerciseService()
        {
            token = Utills.UserStore.GetToken();
            userId = Utills.UserStore.GetId().Value;
        }

        public async Task<ServiceResult<IEnumerable<ExerciseListElement>>> GetExercisesViewModels()
        {
            var client = new ApiClients.ExcerciseClient(token);
            var response = await client.GetExercises(userId);
            if (response.Success)
            {
                var exercises = response.Data;
                var viewModels = exercises
                    .Select(s => new ExerciseListElement
                    {
                        Id = s.IdExercise,
                        Name = s.Name,
                        Description = s.Description,
                        DetailsVisable = false
                    })
                    .ToArray();
                return new ServiceResult<IEnumerable<ExerciseListElement>> { Success = true, Result = viewModels, Message = response.Message };
            }
            return new ServiceResult<IEnumerable<ExerciseListElement>> { Success = false, Message = response.Message };
        }

        public async Task<ServiceResult<bool>> SetAsFavourite(Guid excerciseId)
        {
            var client = new ApiClients.ExcerciseClient(token);
            var response = await client.FavouriteExercise(excerciseId, userId);
            return new ServiceResult<bool> { Success = response.Success, Result = response.Data, Message = response.Message };
        }
    }
}
