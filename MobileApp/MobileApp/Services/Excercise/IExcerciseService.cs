using MobileApp.ViewModels.Exercises;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileApp.Services.Excercise
{
    public interface IExcerciseService
    {
        Task<ServiceResult<IEnumerable<ExcerciseViewModel>>> GetExercisesViewModels();

        Task<ServiceResult<bool>> SetAsFavourite(Guid excerciseId);

        string GetImageSource(Guid excerciseId, string imageName);
    }
}
