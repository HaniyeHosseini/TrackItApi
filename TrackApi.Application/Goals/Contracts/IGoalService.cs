using TrackApi.Application.DTOs.Goal;
using TrackItApi.Common;

namespace TrackApi.Application.Goals.Contracts
{
    public interface IGoalService
    {
        Task<OutputGoalDto> Insert(InputCreationGoalDto goal);
        Task<IEnumerable<OutputGoalDto>> BulkInsert(IList<InputCreationGoalDto> goals);
        Task<OutputGoalDto> UpdateGoal(InputUpdateGoalDto goal);
        Task<bool> RemoveGoal(long goalId);
        Task<OutputGoalDto> GetGoal(long goalId);
        Task<IList<OutputGoalDto>> GetGoalsByPlanId(long planId);
        Task<IList<OutputGoalDto>> GetGoalsByDateFilter(DateTime? startDate , DateTime? endDate);
    }
}
