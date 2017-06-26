using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Repositories.Excercise
{
    public interface IExcerciseRepository : IRepository<Exercise, Guid>
    {
        IEnumerable<Database.UserExcercise> GetExercisesForUser(Guid IdUser);
        Exercise GetById(Guid id, bool v);
    }
}
