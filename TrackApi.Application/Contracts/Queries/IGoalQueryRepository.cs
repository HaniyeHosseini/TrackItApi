using TrackItApi.Domain.Models;

namespace TrackApi.Application.Contracts.Queries
{
    public interface IGoalQueryRepository : IBaseQueryRepository<Goal>
    {
        Task<IList<Goal>> GetGoalsByDateFilter(DateTime? startDate, DateTime? endDate);
        Task<IList<Goal>> GetGoalsByPlanId(long planId);
    }
}
