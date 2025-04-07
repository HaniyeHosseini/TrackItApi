using TrackApi.Infrastructure.Repositories.Base;
using TrackItApi.Domain.Models;

namespace TrackApi.Infrastructure.Repositories.Goals
{
    public interface IGoalRepository : IBaseRepository<Goal>
    {
        Task<IList<Goal>> GetGoalsByDateFilter(DateTime? startDate, DateTime? endDate);
        Task<IList<Goal>> GetGoalsByPlanId(long planId);

    }
}
