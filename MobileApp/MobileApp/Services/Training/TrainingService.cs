using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MobileApp.ViewModels.Trainings;
using MobileApp.Utills.TimeInput;
using MobileApp.Models;

namespace MobileApp.Services.Training
{
    public class TrainingService : AuthorizedService, ITrainingService
    {
        public async Task<ServiceResult> AddTraining(AddTrainingViewModel training)
        {
            var client = new ApiClients.TrainingClient(token);
            var id = Guid.NewGuid();
            ApiClients.Models.DTO.TrainingDTO dto = null;
            await Task.Factory.StartNew(() =>
            {
                dto = new ApiClients.Models.DTO.TrainingDTO
                {
                    IdTraining = id,
                    IdUser = userId,
                    Name = training.Name,
                    Excercises = training.Excercises.Select(s => new ApiClients.Models.DTO.TrainingExcerciseDTO
                    {
                        Id = Guid.NewGuid(),
                        IdExcercise = s.IdExcercise,
                        Interval = s.IntervalTime.GetSecondsFromTimeString(),
                        Series = s.SeriesNumber,
                        TimeSpan = s.SeriesTime.GetSecondsFromTimeString(),
                        IntervalBeforeNextExercise = s.IntervalBetweenExcercises.GetSecondsFromTimeString(),
                    }).ToArray()
                };
            });
            var response = await client.AddTraining(dto);
            return new ServiceResult { Success = response.Success, Message = response.Message };
        }

        public async Task<ServiceResult<IEnumerable<TrainingListItemViewModel>>> GetTrainingList()
        {
            var client = new ApiClients.TrainingClient(token);
            var response = await client.GetTrainings(userId);
            var result = new ServiceResult<IEnumerable<TrainingListItemViewModel>> { Success = response.Success, Message = response.Message };
            if (response.Success)
            {
                await Task.Factory.StartNew(() =>
                {
                    result.Result = response.Data.Select(s => new TrainingListItemViewModel { Id = s.IdTraining, Name = s.Name });
                });
            }
            return result;
        }

        public async Task<ServiceResult> DeleteTraining(Guid id)
        {
            var client = new ApiClients.TrainingClient(token);
            var response = await client.DeleteTraining(id);
            return new ServiceResult { Success = response.Success, Message = response.Message };
        }

        public async Task<ServiceResult<TrainingModel>> GetTraining(Guid id)
        {
            var client = new ApiClients.TrainingClient(token);
            var response = await client.GetTraining(id);
            var result = new ServiceResult<TrainingModel> { Success = response.Success, Message = response.Message };
            if (response.Success)
            {
                await Task.Factory.StartNew(() =>
                {

                    result.Result = new TrainingModel
                    {
                        Id = response.Data.IdTraining,
                        Name = response.Data.Name,
                        Exercises = response.Data.Excercises
                            .Select(s => new TrainingExerciseModel
                            {
                                Id = s.IdExcercise,
                                CalloriesPerHour = s.CalloriesPerHour.Value,
                                Interval = s.Interval,
                                Name = s.Name,
                                NextExerciseInterval = s.IntervalBeforeNextExercise,
                                SeriesNumber = s.Series,
                                SeriesTime = s.TimeSpan,
                                ImageName = s.ImageName,
                            }).ToArray()
                    };
                });
            }
            return result;
        }

        public async Task<ServiceResult> AddFinishedTraining(TrainingModel training)
        {
            var client = new ApiClients.TrainingClient(token);
            ApiClients.Models.DTO.FinishedTrainingDTO dto = null;
            await Task.Factory.StartNew(() =>
            {
                dto = new ApiClients.Models.DTO.FinishedTrainingDTO
                {
                    Exercises = training.Exercises.Select(s => new ApiClients.Models.DTO.FinishedExerciseDTO
                    {
                        Date = DateTime.Now,
                        Name = training.Name + " - " + s.Name,
                        UserId = userId,
                        Callories = (decimal)s.SeriesTime * s.SeriesNumber * s.CalloriesPerHour / 3600m
                    }).ToArray()
                };
            });
            var response = await client.AddFinishedTraining(userId, dto);
            return new ServiceResult { Success = response.Success, Message = response.Message };
        }
    }
}
