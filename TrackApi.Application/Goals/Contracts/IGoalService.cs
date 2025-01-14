using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackApi.Application.Goals.Dtos;
using TrackItApi.Common;

namespace TrackApi.Application.Goals.Contracts
{
    public interface IGoalService
    {
        Task<OperationResult> InsertGoalToPlan(CreationGoalDto goal);
        Task<OperationResult> UpdateGoal(UpdateGoalDto goal);
        Task<OperationResult> RemoveGoal(long goalId);
        Task<GoalViewDto> GetGoal(long goalId);
        Task<IList<GoalViewDto>> GetGoalsByPlanId(long planId);
        Task<IList<GoalViewDto>> GetGoalsByDateFilter(DateTime? startDate , DateTime? endDate);
    }
}
