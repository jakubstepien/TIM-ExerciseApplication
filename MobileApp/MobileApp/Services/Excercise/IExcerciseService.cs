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
        Task<ServiceResult<IEnumerable<ExerciseListElement>>> GetExercisesViewModels();

        Task<ServiceResult<bool>> SetAsFavourite(Guid excerciseId);
    }
}
