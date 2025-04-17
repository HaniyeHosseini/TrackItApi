using TrackApi.Infrastructure.Repositories.Base;
using TrackItApi.Domain.Models;

namespace TrackApi.Infrastructure.Repositories.Jobs
{
    public interface IJobRepository : IBaseRepository<Job>
    {
        Task<IList<Job>> GetJobsByGoalId(long goalId);
        Task<IList<Job>> GetJobsByDateFilter(DateTime? startDate, DateTime? endDate);
    }

}
