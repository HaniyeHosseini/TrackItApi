using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackApi.Infrastructure.Repositories.Base.Queries;
using TrackItApi.Domain.Models;

namespace TrackApi.Infrastructure.Repositories.Jobs.Queries
{
    public interface IJobQueryRepository : IBaseQueryRepository<Job>
    {
        Task<IList<Job>> GetJobsByGoalId(long goalId);
        Task<IList<Job>> GetJobsByDateFilter(DateTime? startDate, DateTime? endDate);
    }
}
