using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Repositories
{
    public class TrainingRepository : GenericRepository<Training>, ITrainingRepository
    {
        public TrainingRepository(DbContext context) : base(context)
        {
        }

        public override Training GetById(Guid id)
        {
            return db.Set<Training>().Include(i => i.Excercises).SingleOrDefault(s => s.IdTraining == id);
        }

        public IEnumerable<Training> GetTrainingsForUser(Guid userId)
        {
            return db.Set<Training>().AsNoTracking().Where(w => w.IdUser == userId).ToArray();
        }
    }
}
