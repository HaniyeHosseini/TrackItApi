﻿using Microsoft.EntityFrameworkCore;
using TrackApi.Application.Contracts.Queries;
using TrackApi.Infrastructure.Context;
using TrackApi.Infrastructure.Repositories.Base.Queries;
using TrackItApi.Domain.Models;

namespace TrackApi.Infrastructure.Repositories.Goals.Queries
{
    public class GoalQueryRepository : BaseQueryRepository<Goal>, IGoalQueryRepository
    {
        public GoalQueryRepository(TrackApiContext context) : base(context)
        {
        }
        public async Task<IList<Goal>> GetGoalsByDateFilter(DateTime? startDate, DateTime? endDate)
        {
            return await
                _context.Goals.Join(_context.Plans, g => g.PlanId, p => p.Id, (g, p) => new { Goal = g, Plan = p })
                .Where(x => x.Plan.StartDate >= startDate && x.Plan.EndDate <= endDate).Select(x => x.Goal).ToListAsync();
        }

        public async Task<IList<Goal>> GetGoalsByPlanId(long planId)
        {
            return await _context.Goals.Where(g => g.PlanId == planId).ToListAsync();
        }
    }
}
