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
        OperationResult Insert(CreationPlanDto plan); 
        OperationResult Update(UpdatePlanDto plan);
        OperationResult Remove(long planId);
        PlanViewDto GetPlanWithGoalsByPlanId(long planId);
        IList<PlanViewDto> GetAllPlansWithGoals();
    }
}
