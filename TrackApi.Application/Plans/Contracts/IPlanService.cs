using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackApi.Application.Plans.Dtos;
using TrackItApi.Common;

namespace TrackApi.Application.Plans.Contracts
{
    public interface IPlanService
    {
        Task<OperationResult> Insert(CreationPlanDto plan);
        Task<OperationResult> Update(UpdatePlanDto plan);
        Task<OperationResult> Remove(long planId);
        Task<PlanViewDto?> GetPlanWithGoalsByPlanId(long planId);
        Task<IList<PlanViewDto>> GetAllPlansWithGoals();
    }
}
