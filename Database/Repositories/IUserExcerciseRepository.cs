using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Repositories
{
    public interface IUserExcerciseRepository : IRepository<UserExcercise,Guid>
    {
        UserExcercise Get(Guid userId, Guid excerciseId);
    }
}
