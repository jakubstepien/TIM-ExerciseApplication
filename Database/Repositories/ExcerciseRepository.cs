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
    }
}
