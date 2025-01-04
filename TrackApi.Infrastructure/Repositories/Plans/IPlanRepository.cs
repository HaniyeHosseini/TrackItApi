using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackApi.Infrastructure.Repositories.Base;
using TrackItApi.Domain.Models;

namespace TrackApi.Infrastructure.Repositories.Plans
{
    public interface IPlanRepository : IBaseRepository<Plan>
    {
        Task<List<Plan>> GetAllPlansWithGoals();
        Task<Plan> GetPlanWithGoalsByPlanId(long planId);
    }
}
