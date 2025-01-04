using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public Task<Plan> GetPlanWithGoalsByPlanId(long planId)
        {
            return _context.Plans.Include(p=> p.Goals).SingleOrDefaultAsync(p=>p.ID==planId);
        }
        
    }
}
