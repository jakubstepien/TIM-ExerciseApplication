using MobileApp.ViewModels.Statistics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileApp.Services.Statistics
{
    public interface IStatisticsService
    {
        Task<ServiceResult<IEnumerable<FinishedExcercise>>> GetBetweenDate(DateTime after, DateTime before);
    }
}
