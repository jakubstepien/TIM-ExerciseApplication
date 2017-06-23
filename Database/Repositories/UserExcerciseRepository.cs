using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Repositories
{
    public class UserExcerciseRepository : GenericRepository<UserExcercise>, IUserExcerciseRepository
    {
        public UserExcerciseRepository(DbContext context) : base(context)
        {
        }

        public UserExcercise Get(Guid userId, Guid excerciseId)
        {
            return db.Set<UserExcercise>().SingleOrDefault(s => s.IdExercise == excerciseId && s.UserId == s.UserId);
        }
    }
}
