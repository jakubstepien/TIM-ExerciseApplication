using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MobileApp.ViewModels.Trainings;
using MobileApp.Utills.TimeInput;

namespace MobileApp.Services.Training
{
    public class TrainingService : AuthorizedService,ITrainingService
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
                        IdExcercise = s.IdExcercise,
                        Interval = s.IntervalTime.GetSecondsFromTimeString(),
                        Series = s.SeriesNumber,
                        TimeSpan = s.SeriesTime.GetSecondsFromTimeString()
                    }).ToArray()
                };
            });
            var response = await client.AddTraining(dto);
            return new ServiceResult { Success = response.Success, Message = response.Message };
        }
    }
}
