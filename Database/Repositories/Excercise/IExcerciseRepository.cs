using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Repositories.Excercise
{
    public interface IExcerciseRepository : IRepository<Exercise, Guid>
    {
        IEnumerable<Database.UserExcercise> GetExercisesForUser(Guid IdUser, int page = 0, int pageSize = int.MaxValue);
        Exercise GetById(Guid id, bool v);
    }
}
