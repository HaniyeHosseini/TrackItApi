﻿using Microsoft.EntityFrameworkCore;
using TrackApi.Application.Contracts.Queries;
using TrackApi.Infrastructure.Context;
using TrackApi.Infrastructure.Repositories.Base.Queries;
using TrackItApi.Domain.Models;

namespace TrackApi.Infrastructure.Repositories.Jobs.Queries
{
    public class JobQueryRepository : BaseQueryRepository<Job> , IJobQueryRepository
    {
        public JobQueryRepository(TrackApiContext context) : base(context)
        {
        }
        public async Task<IList<Job>> GetJobsByDateFilter(DateTime? startDate, DateTime? endDate)
        {
            var filteredJobs = await (from job in _context.Jobs
                                      join goal in _context.Goals on job.GoalId equals goal.Id
                                      join plan in _context.Plans on goal.PlanId equals plan.Id
                                      where plan.StartDate >= startDate && plan.EndDate <= endDate
                                      select job
                         ).AsNoTracking().ToListAsync();
            return filteredJobs;

        }

        public async Task<IList<Job>> GetJobsByGoalId(long goalId)
        {
            return await _context.Jobs.Where(x => x.GoalId == goalId).AsNoTracking().ToListAsync();
        }
    }
}
