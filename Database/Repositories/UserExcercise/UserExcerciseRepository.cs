using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Repositories.UserExcercise
{
    public class UserExcerciseRepository : GenericRepository<Database.UserExcercise>, IUserExcerciseRepository
    {
        public UserExcerciseRepository(DbContext context) : base(context)
        {
        }

        public Database.UserExcercise Get(Guid userId, Guid excerciseId)
        {
            return db.Set<Database.UserExcercise>().SingleOrDefault(s => s.IdExercise == excerciseId && s.UserId == s.UserId);
        }
    }
}
