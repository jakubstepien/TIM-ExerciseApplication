using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Repositories.Statistic
{
    public interface IStatisticRepository : IRepository<Database.Statistic, Guid>
    {
        IEnumerable<Database.Statistic> GetAllBetweenDate(DateTime after, DateTime before);
    }
}
