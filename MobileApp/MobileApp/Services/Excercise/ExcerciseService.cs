using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MobileApp.ViewModels.Exercises;

namespace MobileApp.Services.Excercise
{
    public class ExcerciseService : AuthorizedService,IExcerciseService
    {
        Utills.IApp app;

        public ExcerciseService(Utills.IApp app)
        {
            this.app = app;
        }

        public async Task<ServiceResult<IEnumerable<ExcerciseViewModel>>> GetExercisesViewModels()
        {
            var client = new ApiClients.ExcerciseClient(token);
            var response = await client.GetExercises(userId);
            
            if (response.Success)
            {
                ExcerciseViewModel[] viewModels = null;
                await Task.Factory.StartNew(() =>
                {
                    var exercises = response.Data;
                    viewModels = exercises
                        .Select(s => new ExcerciseViewModel
                        {
                            Id = s.IdExercise,
                            Name = s.Name,
                            Description = s.Description,
                            DetailsVisable = false,
                            ImageName = s.ImageName,
                            CaloriesPerHour = s.CaloriesPerHour,
                            Favourite = s.IsFavourite
                        })
                        .ToArray();
                });
                return new ServiceResult<IEnumerable<ExcerciseViewModel>> { Success = true, Result = viewModels, Message = response.Message };
            }
            return new ServiceResult<IEnumerable<ExcerciseViewModel>> { Success = false, Message = response.Message };
        }

        public async Task<ServiceResult<bool>> SetAsFavourite(Guid excerciseId)
        {
            var client = new ApiClients.ExcerciseClient(token);
            var response = await client.FavouriteExercise(excerciseId, userId);
            return new ServiceResult<bool> { Success = response.Success, Result = response.Data, Message = response.Message };
        }

        public string GetImageSource(Guid excerciseId, string imageName)
        {
            return app.ApiServer + "/images/" + excerciseId.ToString() + "/" + imageName;
        }

        public async Task<ServiceResult> SavedFinishedExercise(string exerciseName, decimal calories)
        {
            var client = new ApiClients.ExcerciseClient(token);
            var response = await client.AddFinishedExercise(userId, new ApiClients.Models.DTO.FinishedExerciseDTO
            {
                UserId = userId,
                Callories = calories,
                Date = DateTime.Now,
                Name = exerciseName
            });
            return new ServiceResult { Success = response.Success, Message = response.Message };
        }
    }
}
