using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Repositories
{
    public interface IStatisticRepository : IRepository<Statistic,Guid>
    {
        IEnumerable<Statistic> GetAllBetweenDate(DateTime after, DateTime before);
    }
}
