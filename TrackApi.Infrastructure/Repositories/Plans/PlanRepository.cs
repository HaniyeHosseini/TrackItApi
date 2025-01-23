using Microsoft.EntityFrameworkCore;
using TrackApi.Infrastructure.Context;
using TrackApi.Infrastructure.Repositories.Base;
using TrackItApi.Domain.Models;

namespace TrackApi.Infrastructure.Repositories.Plans
{
    public class PlanRepository : BaseRepository<Plan>, IPlanRepository
    {
        public PlanRepository(TrackApiContext context) : base(context)
        {
        }

        public Task<List<Plan>> GetAllPlansWithGoals()
        {
            return _context.Plans.Include(p => p.Goals).ToListAsync();
        }

        public Task<Plan?> GetPlanWithGoalsByPlanId(long planId)
        {
            return _context.Plans.Include(p => p.Goals).SingleOrDefaultAsync(p => p.Id == planId);
        }

        public async Task RemovePlanWithGoals(long planId)
        {
            await _context.Goals.Where(x => x.PlanId == planId).ExecuteDeleteAsync();
            await RemoveAsync(planId);
        }
    }
}
