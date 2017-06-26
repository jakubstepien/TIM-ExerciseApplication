using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Repositories
{
    public interface ITrainingRepository : IRepository<Training,Guid>
    {
        IEnumerable<Training> GetTrainingsForUser(Guid userId);
    }
}
