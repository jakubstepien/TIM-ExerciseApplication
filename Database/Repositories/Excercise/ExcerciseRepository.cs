using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Repositories.Excercise
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

        public Exercise GetById(Guid id, bool asNoTracking)
        {
            if (asNoTracking)
            {
                return db.Set<Exercise>()
                    .AsNoTracking()
                    .Include(i => i.UserExcercise)
                    .SingleOrDefault(s => s.IdExercise == id);
            }
            return GetById(id);
        }

        public IEnumerable<Database.UserExcercise> GetExercisesForUser(Guid IdUser, int page = 1, int pageSize = int.MaxValue)
        {
            return db.Set<Database.UserExcercise>()
                .AsNoTracking()
                .Include(i => i.Exercise)
                .Where(w => w.UserId == IdUser)
                .OrderByDescending(o => o.IsFavourite)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToArray();
        }
    }
}
