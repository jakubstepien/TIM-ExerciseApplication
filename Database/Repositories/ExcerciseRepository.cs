using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Repositories
{
    public class ExcerciseRepository : GenericRepository<Exercise>, IExcerciseRepository
    {
        public ExcerciseRepository(DbContext context) : base(context)
        {
        }

        public override Exercise GetById(Guid id)
        {
            return db.Set<Exercise>()
                .Include(i => i.UserExcercise)
                .SingleOrDefault(s => s.IdExercise == id);
        }

        public IEnumerable<Exercise> GetExercisesForUser(Guid IdUser)
        {
            return db.Set<Exercise>()
                .AsNoTracking()
                .Where(w => w.UserExcercise.Any(a => a.UserId == IdUser))
                .ToArray();
        }
    }
}
