using Microsoft.EntityFrameworkCore;
using TrackApi.Infrastructure.Context;
using TrackApi.Infrastructure.Repositories.Base.Commands;
using TrackItApi.Domain.Models;

namespace TrackApi.Infrastructure.Repositories.Plans.Commands
{
    public class PlanCommandRepository : BaseCommandRepository<Plan>, IPlanCommandRepository
    {
        public PlanCommandRepository(TrackApiContext context) : base(context)
        {
        }
        public async Task RemovePlanWithGoals(long planId)
        {
            await _context.Goals.Where(x => x.PlanId == planId).ExecuteDeleteAsync();
            await RemoveAsync(planId);
        }
    }
}
