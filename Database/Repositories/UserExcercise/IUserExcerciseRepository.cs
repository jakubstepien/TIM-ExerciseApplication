using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Repositories.UserExcercise
{
    public interface IUserExcerciseRepository : IRepository<Database.UserExcercise,Guid>
    {
        Database.UserExcercise Get(Guid userId, Guid excerciseId);
    }
}
