using TrackApi.Infrastructure.Repositories.Base;
using TrackItApi.Domain.Models;

namespace TrackApi.Infrastructure.Repositories.Plans
{
    public interface IPlanRepository : IBaseRepository<Plan>
    {
        Task<List<Plan>> GetAllPlansWithGoals();
        Task<Plan?> GetPlanWithGoalsByPlanId(long planId);
        Task RemovePlanWithGoals(long planId);
    }
}
