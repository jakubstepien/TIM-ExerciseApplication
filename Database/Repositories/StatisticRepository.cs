using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Repositories
{
    public class StatisticRepository : GenericRepository<Statistic>, IStatisticRepository
    {
        public StatisticRepository(DbContext context) : base(context)
        {
        }

        public IEnumerable<Statistic> GetAllBetweenDate(DateTime after, DateTime before)
        {
            return db.Set<Statistic>()
                .AsNoTracking()
                .Where(w => DbFunctions.TruncateTime(w.Date) <= before && DbFunctions.TruncateTime(w.Date) >= after)
                .ToArray();
        }
    }
}
