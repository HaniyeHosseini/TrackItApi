using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackApi.Infrastructure.Repositories.Base.Queries;
using TrackApi.Infrastructure.Repositories.Goals.Commands;
using TrackItApi.Domain.Models;

namespace TrackApi.Infrastructure.Repositories.Goals.Queries
{
    public interface IGoalQueryRepository : IBaseQueryRepository<Goal>
    {
        Task<IList<Goal>> GetGoalsByDateFilter(DateTime? startDate, DateTime? endDate);
        Task<IList<Goal>> GetGoalsByPlanId(long planId);
    }
}
