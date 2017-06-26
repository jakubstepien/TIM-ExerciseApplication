using MobileApp.Models;
using MobileApp.ViewModels.Trainings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileApp.Services.Training
{
    public interface ITrainingService
    {
        Task<ServiceResult> AddTraining(AddTrainingViewModel traing);

        Task<ServiceResult<IEnumerable<TrainingListItemViewModel>>> GetTrainingList();

        Task<ServiceResult> DeleteTraining(Guid id);

        Task<ServiceResult<TrainingModel>> GetTraining(Guid id);

        Task<ServiceResult> AddFinishedTraining(TrainingModel training);
    }
}
